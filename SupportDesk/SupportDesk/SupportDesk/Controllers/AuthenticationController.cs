using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using SupportDesk.Models;

namespace SupportDesk.Controllers
{
    
    public class AuthenticationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        [HttpGet]
        [ActionName("SignIn")]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginViewModel model, string? returnURL = null)
        {

            ViewData["ReturnUrl"] = returnURL;
            returnURL = returnURL ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Projects", "Dashboard");

                }
                if (result.IsLockedOut)
                {
                    return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempts");
                    return View(model);
                }

            }
            return View(model);


        }

        [ActionName("PasswordReset")]     
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> PasswordReset(ForgotPasswordViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return RedirectToAction("ForgotPasswordConfirmation");
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

                await _emailSender.SendEmailAsync(model.Email, "Reset Password - Identity Manager",
                    "Please reset your password by clicking here: <a href=\"" + callbackurl + "\">link</a>");

                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View(model);
        }


        [ActionName("LockScreen")]
        public IActionResult LockScreen()
        {
            return View();
        }
        [ActionName("Logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
