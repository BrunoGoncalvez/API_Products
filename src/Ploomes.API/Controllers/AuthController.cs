using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Ploomes.API.ViewModels;
using Ploomes.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Controllers
{
    [Route("api/)]
    public class AuthController : MainController
    {

        private readonly SignInManager<IdentityUser> _signManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotifier notifier, SignInManager<IdentityUser> signManager, UserManager<IdentityUser> userManager) 
            : base(notifier)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signManager.SignInAsync(user, false);
                return CustomResponse(registerUser);
            }
            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse();
            }

            if (result.IsLockedOut)
            {
                NotifyError("User blocked.");
                return CustomResponse(loginUser);
            }

            NotifyError("User or Password invalid.");
            return CustomResponse(loginUser);

        }


    }
}
