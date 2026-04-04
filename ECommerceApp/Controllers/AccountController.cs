using ECommerceApp.DTO; 
using ECommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> manager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> manager, SignInManager<ApplicationUser> signInManager)
        {
            this.manager = manager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View("Login");
        }
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserDto registerUserFromRequest)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = registerUserFromRequest.UserName,
                   
                    Email = registerUserFromRequest.Email,

                };

                var result = await manager.CreateAsync(user, registerUserFromRequest.Password);
                if (result.Succeeded)
                {
                    await manager.AddClaimAsync(user, new Claim("IsAdmin", "false"));

                    return RedirectToAction("Login");

                }
                //!
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }

            return View("Register", registerUserFromRequest);

        }
        [HttpPost]
        public async Task<IActionResult> SaveLogin(LoginUserDto LoginUserFromRequest)
        {

            if (ModelState.IsValid)
            {
                var user = await manager.FindByNameAsync(LoginUserFromRequest.UserName);
                if (user != null)
                {
                    //check password
                    bool isvalid = await manager.CheckPasswordAsync(user, LoginUserFromRequest.Password);
                    if (isvalid)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Product");

                    }

                }
                ModelState.AddModelError("", "Invalid username or password");

            }
            return View("Login", LoginUserFromRequest);

        }
    }
}
