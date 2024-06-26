﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace aspLearning.Entities;

public class User
{
    public int Id { get; set; }

    [Remote(action: "CheckingUserName", controller: "Home", HttpMethod = "POST", ErrorMessage = "")]
    [MaxLength(120,ErrorMessage = "")]
    public string UserName { get; set; }

    [Compare(nameof(Password), ErrorMessage = "")]
    public string ConfirmPassword { get; set; }

    public string Password { get; set; }
}