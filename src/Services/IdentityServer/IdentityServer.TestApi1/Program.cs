using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Validation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(configuration["OpenIddict:IssuerUrl"]!);

        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String(configuration["OpenIddict:SecurityKey"]!)));

        options.UseSystemNetHttp();

        options.UseAspNetCore();
    });

services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapGet("api", [Authorize] (ClaimsPrincipal user) => $"{user.Identity!.Name} is allowed to access Api1.");

app.Run();
