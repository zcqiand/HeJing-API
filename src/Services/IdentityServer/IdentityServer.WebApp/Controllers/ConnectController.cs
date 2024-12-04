using IdentityServer.WebApp.Helpers;
using IdentityServer.WebApp.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using Polly;
using System.Collections.Immutable;
using System.Globalization;
using System.Security.Claims;
using static OpenIddict.Abstractions.OpenIddictConstants;
using static OpenIddict.Client.WebIntegration.OpenIddictClientWebIntegrationConstants;

namespace IdentityServer.WebApp.Controllers;

public class ConnectController : Controller
{
    private readonly IOpenIddictApplicationManager _applicationManager;
    private readonly IOpenIddictAuthorizationManager _authorizationManager;
    private readonly IOpenIddictScopeManager _scopeManager;

    private readonly string UserId = "zcq";
    private readonly string UserEmail = "zcq@163.com";
    private readonly string UserName = "zcqiand";
    private readonly ImmutableArray<string> UserRole = ["admin"];

    public ConnectController(
        IOpenIddictApplicationManager applicationManager,
        IOpenIddictAuthorizationManager authorizationManager,
        IOpenIddictScopeManager scopeManager)
    {
        _applicationManager = applicationManager;
        _authorizationManager = authorizationManager;
        _scopeManager = scopeManager;
    }

    [HttpGet("~/authorize")]
    [HttpPost("~/authorize")]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> Authorize()
    {
        var request = HttpContext.GetOpenIddictServerRequest() ??
                throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

        var principal = (await HttpContext.AuthenticateAsync())?.Principal;
        if (principal is null)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = HttpContext.Request.GetEncodedUrl()
            };

            return Challenge(properties);
        }

        var identifier = principal.FindFirst(ClaimTypes.NameIdentifier)!.Value;

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
