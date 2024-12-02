using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static OpenIddict.Abstractions.OpenIddictConstants;
using System.Globalization;
using System.Security.Claims;
using OpenIddict.Server.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using Polly;
using Microsoft.AspNetCore;

namespace IdentityServer.API.Pages
{
    public class AuthorizeModel : PageModel
    {
        private readonly ILogger<AuthorizeModel> _logger;

        public AuthorizeModel(ILogger<AuthorizeModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(HttpContext context, IOpenIddictScopeManager manager)
        {
            var request = context.GetOpenIddictServerRequest();

            var identifier = 1;

            if (identifier==1)
            {
                var identity = new ClaimsIdentity(
                    authenticationType: TokenValidationParameters.DefaultAuthenticationType,
                    nameType: Claims.Name,
                    roleType: Claims.Role);

                // Add the claims that will be persisted in the tokens.
                identity.AddClaim(new Claim(Claims.Subject, identifier.ToString(CultureInfo.InvariantCulture)));
                identity.AddClaim(new Claim(Claims.Name, identifier switch
                {
                    1 => "Alice",
                    2 => "Bob",
                    _ => throw new InvalidOperationException()
                }));
                identity.AddClaim(new Claim(Claims.PreferredUsername, identifier switch
                {
                    1 => "Alice",
                    2 => "Bob",
                    _ => throw new InvalidOperationException()
                }));

                // Note: in this sample, the client is granted all the requested scopes for the first identity (Alice)
                // but for the second one (Bob), only the "api1" scope can be granted, which will cause requests sent
                // to Zirku.Api2 on behalf of Bob to be automatically rejected by the OpenIddict validation handler,
                // as the access token representing Bob won't contain the "resource_server_2" audience required by Api2.
                identity.SetScopes(identifier switch
                {
                    1 => request.GetScopes(),
                    2 => new[] { "api1" }.Intersect(request.GetScopes()),
                    _ => throw new InvalidOperationException()
                });

                identity.SetResources(await manager.ListResourcesAsync(identity.GetScopes()).ToListAsync());

                // Allow all claims to be added in the access tokens.
                identity.SetDestinations(claim => [Destinations.AccessToken]);

                return SignIn(new ClaimsPrincipal(identity), properties: null, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            }

            return Challenge(
            authenticationSchemes: [OpenIddictServerAspNetCoreDefaults.AuthenticationScheme],
            properties: new AuthenticationProperties(new Dictionary<string, string>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidRequest,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] = "µÇÂ¼Ê§°Ü."
            }));
        }
    }
}
