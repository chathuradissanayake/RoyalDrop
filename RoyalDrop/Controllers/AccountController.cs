using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyalDrop.Data;
using RoyalDrop.Models;
using System.Security.Claims;

namespace RoyalDrop.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoyalDropContext _context;

        public AccountController(RoyalDropContext context) 
        {
            _context = context;
        }

        public IActionResult Login(string returnUrl="/")
        {
            Login loginModel = new Login();
            loginModel.ReturnUrl = returnUrl;
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginModel)
        {
            //RentalSystemContext userContext = new RentalSystemContext();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginModel.UserName && u.Password == loginModel.Password);
            if(user!=null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("Admin", "Code")

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,
                    new AuthenticationProperties()
                    {
                        IsPersistent = loginModel.RememberLogin
                    });
                return LocalRedirect(loginModel.ReturnUrl);
            }
            else
            {
                ViewBag.Message = "Invalid Credential";
                return View(loginModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
    }
}
