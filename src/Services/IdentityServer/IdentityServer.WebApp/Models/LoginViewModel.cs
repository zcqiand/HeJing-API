using System.ComponentModel.DataAnnotations;

namespace IdentityServer.WebApp.Models;

public class LoginViewModel
{
    [Display(Name = "用户名称")]
    public string? UserName { get; set; }

    [Display(Name = "用户密码")]
    public string? Password { get; set; }
}
