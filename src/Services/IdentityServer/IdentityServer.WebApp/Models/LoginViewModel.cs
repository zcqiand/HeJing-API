using System.ComponentModel.DataAnnotations;

namespace IdentityServer.WebApp.Models;

public class LoginViewModel
{
    [Display(Name = "�û�����")]
    public string? UserName { get; set; }

    [Display(Name = "�û�����")]
    public string? Password { get; set; }
}
