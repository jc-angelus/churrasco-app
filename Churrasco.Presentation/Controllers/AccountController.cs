using Churrasco.Application.Interfaces;
using Churrasco.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Churrasco.Domain.Helpers;

namespace Churrasco.Presentation.Controllers
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: AccountController
    /// </summary>
    public class AccountController: Controller
    {

        public readonly ILoginServices _loginServices;        

        public AccountController(ILoginServices loginServices)
        {
            _loginServices = loginServices;            
        }        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserModel userModel)
        {
            if (ModelState.IsValid)
            {

                var user = await _loginServices.Login(userModel.Email, StringHelpers.sha256_hash(userModel.Password));


                if (user != null)
                {                    

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.FirstName),
                        new Claim(ClaimTypes.Email, user.Email)                        
                    };

                    await SignIn(claims);

                    return RedirectToAction("Index", "Dashboard");

                }
                else
                {
                    ModelState.AddModelError("", "Login Error");
                    ViewBag.Message = "Login Error";
                    return View(userModel);
                }
               
            }
            else
            {
                ModelState.AddModelError("", "Please check the credentials");
                ViewBag.Message = "Please check the credentials";
            }

            return View(userModel);
        }        


        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        private async Task SignIn(List<Claim> claims)
        {
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }        
    }
}
