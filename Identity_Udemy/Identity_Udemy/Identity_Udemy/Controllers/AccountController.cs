using Identity_Udemy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Udemy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Register(string? returnURL = null)
        {
            ViewData["ReturnUrl"] = returnURL;
            RegisterViewModel registerViewModel = new RegisterViewModel();           
            return View(registerViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string? returnURL = null)
        {
            ViewData["ReturnUrl"] = returnURL;
            returnURL = returnURL ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnURL);
                }
                AddErrors(result);
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index),"Home");
        }



        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        [HttpGet]
        public IActionResult Login(string? returnURL = null)
        {
            ViewData["ReturnUrl"] = returnURL;
            returnURL = returnURL ?? Url.Content("~/");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnURL = null)
        {

            ViewData["ReturnUrl"] = returnURL;
            returnURL = returnURL ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure:true);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnURL);

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


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[AllowAnonymous]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user == null)
        //        {
        //            return RedirectToAction("ForgotPasswordConfirmation");
        //        }

        //        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        //        var callbackurl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);

        //        await _emailSender.SendEmailAsync(model.Email, "Reset Password - Identity Manager",
        //            "Please reset your password by clicking here: <a href=\"" + callbackurl + "\">link</a>");

        //        return RedirectToAction("ForgotPasswordConfirmation");
        //    }

        //    return View(model);
        //}


    }
}
