using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace aspLearning.Entities;

public class User
{
    [HiddenInput]
    public int Id { get; set; }

    [Remote(action: "CheckingUserName", controller: "Home", HttpMethod = "POST", ErrorMessage = "")]
    public string UserName { get; set; }

    [Compare(nameof(Password), ErrorMessage = "")]
    public string ConfirmPassword { get; set; }

    public string Password { get; set; }
}