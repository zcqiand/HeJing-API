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

public class AuthorizationController : Controller
{
    private readonly IOpenIddictApplicationManager _applicationManager;
    private readonly IOpenIddictAuthorizationManager _authorizationManager;
    private readonly IOpenIddictScopeManager _scopeManager;

    private readonly string UserId = "zcq";
    private readonly string UserEmail = "zcq@163.com";
    private readonly string UserName = "zcqiand";
    private readonly ImmutableArray<string> UserRole = ["admin"];

    public AuthorizationController(
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

    //[HttpGet("~/authorize")]
    //[HttpPost("~/authorize")]
    //[IgnoreAntiforgeryToken]
    //public async Task<IActionResult> Authorize()
    //{
    //    var request = HttpContext.GetOpenIddictServerRequest() ??
    //        throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

    //    var result = await HttpContext.AuthenticateAsync();
    //    if (result == null || !result.Succeeded || request.HasPrompt(Prompts.Login) ||
    //       request.MaxAge != null && result.Properties?.IssuedUtc != null &&
    //        DateTimeOffset.UtcNow - result.Properties.IssuedUtc > TimeSpan.FromSeconds(request.MaxAge.Value))
    //    {
    //        if (request.HasPrompt(Prompts.None))
    //        {
    //            return Forbid(
    //                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
    //                properties: new AuthenticationProperties(new Dictionary<string, string>
    //                {
    //                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.LoginRequired,
    //                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "The user is not logged in."
    //                }));
    //        }

    //        var prompt = string.Join(" ", request.GetPrompts().Remove(Prompts.Login));

    //        var parameters = Request.HasFormContentType ?
    //            Request.Form.Where(parameter => parameter.Key != Parameters.Prompt).ToList() :
    //            Request.Query.Where(parameter => parameter.Key != Parameters.Prompt).ToList();

    //        parameters.Add(KeyValuePair.Create(Parameters.Prompt, new StringValues(prompt)));

//            return Challenge(new AuthenticationProperties
//            {
//                RedirectUri = Request.PathBase + Request.Path + QueryString.Create(parameters)
//});
    //    }

    //    //var user = await _userManager.GetUserAsync(result.Principal) ??
    //    //    throw new InvalidOperationException("The user details cannot be retrieved.");

    //    // Retrieve the application details from the database.
    //    var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
    //        throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

    //    // Retrieve the permanent authorizations associated with the user and the calling client application.
    //    var authorizations = await _authorizationManager.FindAsync(
    //        subject: UserId,
    //        client: await _applicationManager.GetIdAsync(application),
    //        status: Statuses.Valid,
    //        type: AuthorizationTypes.Permanent,
    //        scopes: request.GetScopes()).ToListAsync();

    //    switch (await _applicationManager.GetConsentTypeAsync(application))
    //    {
    //        case ConsentTypes.External when authorizations.Count is 0:
    //            return Forbid(
    //                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
    //                properties: new AuthenticationProperties(new Dictionary<string, string>
    //                {
    //                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.ConsentRequired,
    //                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
    //                        "The logged in user is not allowed to access this client application."
    //                }));
    //        case ConsentTypes.Implicit:
    //        case ConsentTypes.External when authorizations.Count is not 0:
    //        case ConsentTypes.Explicit when authorizations.Count is not 0 && !request.HasPrompt(Prompts.Consent):
    //            var identity = new ClaimsIdentity(
    //                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
    //                nameType: Claims.Name,
    //                roleType: Claims.Role);

    //            // Add the claims that will be persisted in the tokens.
    //            identity.SetClaim(Claims.Subject, UserId)
    //                    .SetClaim(Claims.Email, UserEmail)
    //                    .SetClaim(Claims.Name, UserName)
    //                    .SetClaim(Claims.PreferredUsername, UserName)
    //                    .SetClaims(Claims.Role, UserRole);

    //            identity.SetScopes(request.GetScopes());
    //            identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());

    //            var authorization = authorizations.LastOrDefault();
    //            authorization ??= await _authorizationManager.CreateAsync(
    //                identity: identity,
    //                subject: UserId,
    //                client: await _applicationManager.GetIdAsync(application),
    //                type: AuthorizationTypes.Permanent,
    //                scopes: identity.GetScopes());

    //            identity.SetAuthorizationId(await _authorizationManager.GetIdAsync(authorization));
    //            identity.SetDestinations(GetDestinations);

    //            return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

    //        case ConsentTypes.Explicit when request.HasPrompt(Prompts.None):
    //        case ConsentTypes.Systematic when request.HasPrompt(Prompts.None):
    //            return Forbid(
    //                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
    //                properties: new AuthenticationProperties(new Dictionary<string, string>
    //                {
    //                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.ConsentRequired,
    //                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
    //                        "Interactive user consent is required."
    //                }));

    //        // In every other case, render the consent form.
    //        default:
    //            return View(new AuthorizeViewModel
    //            {
    //                ApplicationName = await _applicationManager.GetLocalizedDisplayNameAsync(application),
    //                Scope = request.Scope
    //            });
    //    }
    //}

    [Authorize, FormValueRequired("submit.Accept")]
    [HttpPost("~/authorize"), ValidateAntiForgeryToken]
    public async Task<IActionResult> Accept()
    {
        var request = HttpContext.GetOpenIddictServerRequest() ??
            throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

        //// Retrieve the profile of the logged in user.
        //var user = await _userManager.GetUserAsync(User) ??
        //    throw new InvalidOperationException("The user details cannot be retrieved.");

        var application = await _applicationManager.FindByClientIdAsync(request.ClientId) ??
            throw new InvalidOperationException("Details concerning the calling client application cannot be found.");

        // Retrieve the permanent authorizations associated with the user and the calling client application.
        var authorizations = await _authorizationManager.FindAsync(
            subject: UserId,
            client: await _applicationManager.GetIdAsync(application),
            status: Statuses.Valid,
            type: AuthorizationTypes.Permanent,
            scopes: request.GetScopes()).ToListAsync();

        // Note: the same check is already made in the other action but is repeated
        // here to ensure a malicious user can't abuse this POST-only endpoint and
        // force it to return a valid response without the external authorization.
        if (authorizations.Count is 0 && await _applicationManager.HasConsentTypeAsync(application, ConsentTypes.External))
        {
            return Forbid(
                authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
                properties: new AuthenticationProperties(new Dictionary<string, string>
                {
                    [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.ConsentRequired,
                    [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                        "The logged in user is not allowed to access this client application."
                }));
        }

        var identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        identity.SetClaim(Claims.Subject, UserId)
                .SetClaim(Claims.Email, UserEmail)
                .SetClaim(Claims.Name, UserName)
                .SetClaim(Claims.PreferredUsername, UserName)
                .SetClaims(Claims.Role, UserRole);

        identity.SetScopes(request.GetScopes());
        identity.SetResources(await _scopeManager.ListResourcesAsync(identity.GetScopes()).ToListAsync());

        var authorization = authorizations.LastOrDefault();
        authorization ??= await _authorizationManager.CreateAsync(
            identity: identity,
            subject: UserId,
            client: await _applicationManager.GetIdAsync(application),
            type: AuthorizationTypes.Permanent,
            scopes: identity.GetScopes());

        identity.SetAuthorizationId(await _authorizationManager.GetIdAsync(authorization));
        identity.SetDestinations(GetDestinations);

        // Returning a SignInResult will ask OpenIddict to issue the appropriate access/identity tokens.
        return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }

    [Authorize, FormValueRequired("submit.Deny")]
    [HttpPost("~/authorize"), ValidateAntiForgeryToken]
    public IActionResult Deny() => Forbid(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

    [HttpGet("~/logout")]
    public IActionResult Logout() => View();

    [ActionName(nameof(Logout)), HttpPost("~/logout"), ValidateAntiForgeryToken]
    public async Task<IActionResult> LogoutPost()
    {
        //await _signInManager.SignOutAsync();

        return SignOut(
            authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
            properties: new AuthenticationProperties
            {
                RedirectUri = "/"
            });
    }

    [HttpPost("~/token"), IgnoreAntiforgeryToken, Produces("application/json")]
    public async Task<IActionResult> Exchange()
    {
        var request = HttpContext.GetOpenIddictServerRequest() ??
            throw new InvalidOperationException("The OpenID Connect request cannot be retrieved.");

        if (request.IsAuthorizationCodeGrantType() || request.IsRefreshTokenGrantType())
        {
            var result = await HttpContext.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            // Retrieve the user profile corresponding to the authorization code/refresh token.
            //var user = await _userManager.FindByIdAsync(result.Principal.GetClaim(Claims.Subject));
            //if (user is null)
            //{
            //    return Forbid(
            //        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
            //        properties: new AuthenticationProperties(new Dictionary<string, string>
            //        {
            //            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
            //            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "The token is no longer valid."
            //        }));
            //}

            // Ensure the user is still allowed to sign in.
            //if (!await _signInManager.CanSignInAsync(user))
            //{
            //    return Forbid(
            //        authenticationSchemes: OpenIddictServerAspNetCoreDefaults.AuthenticationScheme,
            //        properties: new AuthenticationProperties(new Dictionary<string, string>
            //        {
            //            [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
            //            [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "The user is no longer allowed to sign in."
            //        }));
            //}

            var identity = new ClaimsIdentity(result.Principal.Claims,
                authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                nameType: Claims.Name,
                roleType: Claims.Role);

            identity.SetClaim(Claims.Subject, UserId)
                    .SetClaim(Claims.Email, UserEmail)
                    .SetClaim(Claims.Name, UserName)
                    .SetClaim(Claims.PreferredUsername, UserName)
                    .SetClaims(Claims.Role, UserRole);

            identity.SetDestinations(GetDestinations);

            return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        throw new InvalidOperationException("The specified grant type is not supported.");
    }

    private static IEnumerable<string> GetDestinations(Claim claim)
    {        
        switch (claim.Type)
        {
            case Claims.Name or Claims.PreferredUsername:
                yield return Destinations.AccessToken;

                if (claim.Subject.HasScope(Scopes.Profile))
                    yield return Destinations.IdentityToken;

                yield break;

            case Claims.Email:
                yield return Destinations.AccessToken;

                if (claim.Subject.HasScope(Scopes.Email))
                    yield return Destinations.IdentityToken;

                yield break;

            case Claims.Role:
                yield return Destinations.AccessToken;

                if (claim.Subject.HasScope(Scopes.Roles))
                    yield return Destinations.IdentityToken;

                yield break;

            // Never include the security stamp in the access and identity tokens, as it's a secret value.
            case "AspNet.Identity.SecurityStamp": yield break;

            default:
                yield return Destinations.AccessToken;
                yield break;
        }
    }
}
