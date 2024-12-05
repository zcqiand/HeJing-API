using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

//���� OpenIddict ʹ�� Entity Framework Core �洢
services.AddOpenIddict()
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
            .UseDbContext<IdentityServerDbContext>();
    });

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("IdentityServerDbConnection") ?? throw new InvalidOperationException("Connection string 'IdentityServerDbConnection' not found.");

// ���� Entity Framework Core ��ģ����ע�� OpenIddict ʵ�壺
services.AddDbContext<IdentityServerDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("IdentityServer.WebApp"));

    // ע�� OpenIddict �����ʵ�弯��
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
