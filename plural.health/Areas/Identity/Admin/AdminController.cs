using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using plural.health.Infractures.Util;
using plural.health.Services;
using plural.health.ViewModels;
using System.Security.Claims;

namespace plural.health.Areas.Identity.Admin
{
    [Authorize]
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly UserService _service;

        public AdminController(UserService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login(string returnUrl)
        {
            LoginVM login = new LoginVM();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.signIn(login);
                if (result.Code.Equals(new ResponseStatusCode().SUCCESS))
                    return Redirect(login.ReturnUrl ?? "/");
                ModelState.AddModelError(nameof(login.Password), "Login Failed: Invalid Email or password");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await _service.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ConfirmEmail()
        {
            return View();
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
