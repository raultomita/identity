using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityProvider.Models;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace IdentityProvider.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly TestUserStore userStore;

        public HomeController(TestUserStore userStore)
        {
            this.userStore = userStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            TestUser user = userStore.FindByUsername(loginModel.Username);
            if(user == null)
            {
                ModelState.AddModelError("UserName", "User name does not exist");
                return View(loginModel);
            }

            AuthenticationProperties props = null;
            await HttpContext.SignInAsync(user.SubjectId, user.Username, props);

            return RedirectToAction("Index");
        }    
    }
}
