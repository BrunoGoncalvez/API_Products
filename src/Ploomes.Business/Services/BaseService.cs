using FluentValidation;
using FluentValidation.Results;
using Ploomes.Business.Interfaces;
using Ploomes.Business.Models;
using Ploomes.Business.Notifications;

namespace Ploomes.Business.Services
{
    public abstract class BaseService
    {

        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            validationResult.Errors.ForEach((error) =>
            {
                Notify(error.ErrorMessage);
            });
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool RunValidation<TValidation, TEntity>(TValidation validation, TEntity entity) 
            where TValidation : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);
            return false;

        }

    }
}
