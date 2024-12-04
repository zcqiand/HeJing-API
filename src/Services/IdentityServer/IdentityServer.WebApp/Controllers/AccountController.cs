using CommonServer.Infrastructure;
using IdentityServer.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly CommonServerDbContext _context;

        public AccountController(CommonServerDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] LoginViewModel input)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }
            return View();
        }
    }
}
