using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{


    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;   // obiekt który zarządza wszystkimi użytkownikami 
        private SignInManager<IdentityUser> signInManager;  
        public AccountController(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            IdentitySeedData.EnsurePopulated(userMgr).Wait();


        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)  // autoryzacja użytkownika 
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();      // najpierw jesli jest ktos zalogowany to go wylogowywujemy 
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }

            ModelState.AddModelError(" ", "Nieprawidłowa nazwa lub hasło");
                return View(loginModel);
         }
                public async Task<RedirectResult> Logout(string returnUrl = "/")
                {
                       await signInManager.SignOutAsync();
                       return Redirect(returnUrl);
                }
     }



}
