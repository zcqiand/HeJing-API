using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

//配置 OpenIddict 使用 Entity Framework Core 存储
services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
            .UseDbContext<IdentityServerDbContext>();
    });

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
    .AddEntityFrameworkStores<IdentityServerDbContext>();
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
