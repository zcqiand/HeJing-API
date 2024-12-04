using CommonServer.Infrastructure;
using IdentityServer.WebApp.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Collections.Immutable;
using System.Globalization;
using System.Security.Claims;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace IdentityServer.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOpenIddictScopeManager _scopeManager;
        private readonly CommonServerDbContext _context;
        private readonly ILogger<AccountController> _logger;

        private readonly string UserId = "zcq";
        private readonly string UserEmail = "zcq@163.com";
        private readonly string UserName = "zcqiand";
        private readonly ImmutableArray<string> UserRole = ["admin"];

        public AccountController(IOpenIddictScopeManager scopeManager, CommonServerDbContext context, ILogger<AccountController> logger)
        {
            _scopeManager = scopeManager;
            _context = context;
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName,Password")] LoginViewModel input, string returnUrl = null)
        {
            var request = HttpContext.GetOpenIddictServerRequest() ??
                throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.IsLocalUrl(returnUrl) ? returnUrl : "/Account/Login"
            };

            var identifier = "abc";

            var identity = new ClaimsIdentity(
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: Claims.Name,
                roleType: Claims.Role);

            identity.AddClaim(new Claim(Claims.Subject, identifier));
            identity.AddClaim(new Claim(Claims.Name, identifier));
            identity.AddClaim(new Claim(Claims.PreferredUsername, identifier));

            identity.SetScopes(new[] { "api1" }.Intersect(request.GetScopes()));

            identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());

            identity.SetDestinations(claim => [Destinations.AccessToken]);

            return SignIn(new ClaimsPrincipal(identity), properties: null, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

        }
    }
}
