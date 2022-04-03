using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        private readonly INotifier _notifier;

        public MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidateOperation()
        {
            return !_notifier.ExistNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidateOperation()) return Ok(new
            {
                success = true,
                data = result
            });
            return BadRequest(new { success = false, errors = _notifier.GetNotifications().Select(e => e.Message) });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                NotifyErrorModelInvalid(modelState);               
            }
            return CustomResponse();
        }

        protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMsg);
            }
        }


        protected void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
