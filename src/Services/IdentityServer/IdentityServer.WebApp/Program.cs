using IdentityServer.Infrastructure;
using IdentityServer.WebApp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quartz;
using static OpenIddict.Server.OpenIddictServerEvents;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("IdentityServerDbConnection") ?? throw new InvalidOperationException("Connection string 'IdentityServerDbConnection' not found.");

// 配置 Entity Framework Core 在模型中注册 OpenIddict 实体：
services.AddDbContext<IdentityServerDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("IdentityServer.WebApp"));

    // 注册 OpenIddict 所需的实体集。
    options.UseOpenIddict();
});
services.AddDatabaseDeveloperPageExceptionFilter();

services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityServerDbContext>();

// 注册 Quartz.NET 服务并将其配置为使用依赖注入和内存存储：
services.AddQuartz(options =>
{
    options.UseMicrosoftDependencyInjectionJobFactory();
    options.UseSimpleTypeLoader();
    options.UseInMemoryStore();
});

// 注册 Quartz.NET 托管服务并将其配置为阻止关闭，直到所有作业完成：
services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

//配置 OpenIddict 
services.AddOpenIddict()
    .AddCore(options =>
    {
        // 使用 Entity Framework Core 存储
        options.UseEntityFrameworkCore()
            .UseDbContext<IdentityServerDbContext>();

        // 使用 Quartz.NET 集成：
        options.UseQuartz();
    })
    .AddServer(options =>
     {
         // Enable the authorization, token, introspection and userinfo endpoints.
         options.SetAuthorizationEndpointUris(configuration["OpenIddict:Endpoints:Authorization"]!)
                .SetTokenEndpointUris(configuration["OpenIddict:Endpoints:Token"]!)
                .SetIntrospectionEndpointUris(configuration["OpenIddict:Endpoints:Introspection"]!)
                .SetUserinfoEndpointUris(configuration["OpenIddict:Endpoints:Userinfo"]!)
                .SetLogoutEndpointUris(configuration["OpenIddict:Endpoints:Logout"]!);

         // Enable the authorization code, implicit and the refresh token flows.
         options.AllowAuthorizationCodeFlow()
                .AllowImplicitFlow()
                .AllowRefreshTokenFlow();

         // Expose all the supported claims in the discovery document.
         options.RegisterClaims(configuration.GetSection("OpenIddict:Claims").Get<string[]>()!);

         // Expose all the supported scopes in the discovery document.
         options.RegisterScopes(configuration.GetSection("OpenIddict:Scopes").Get<string[]>()!);

         // Register the encryption credentials. This sample uses a symmetric
         // encryption key that is shared between the server and the Api2 sample
         // (that performs local token validation instead of using introspection).
         //
         // Note: in a real world application, this encryption key should be
         // stored in a safe place (e.g in Azure KeyVault, stored as a secret).
         options.AddEncryptionKey(new SymmetricSecurityKey(
             Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

         // Register the signing credentials.
         options.AddDevelopmentSigningCertificate();

         // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
         //
         // Note: the pass-through mode is not enabled for the token endpoint
         // so that token requests are automatically handled by OpenIddict.
         options.UseAspNetCore()
                .EnableAuthorizationEndpointPassthrough()
                .EnableAuthorizationRequestCaching()
                .EnableLogoutEndpointPassthrough();

     })
    .AddValidation(options =>
    {
        // Import the configuration from the local OpenIddict server instance.
        options.UseLocalServer();

        // Register the ASP.NET Core host.
        options.UseAspNetCore();

        // Enable authorization entry validation, which is required to be able
        // to reject access tokens retrieved from a revoked authorization code.
        options.EnableAuthorizationEntryValidation();
    });

// Register the worker responsible for creating and seeding the SQL database.
// Note: in a real world application, this step should be part of a setup script.
services.AddHostedService<Worker>();

services.AddCors();

services.AddAuthorization();
services.AddAuthentication().AddGoogle(googleOptions =>
{
    IConfigurationSection googleAuthNSection =
       configuration.GetSection("Authentication:Google");
    googleOptions.ClientId = googleAuthNSection["ClientId"];
    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
});

services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
