﻿using Microsoft.AspNetCore.Identity;

namespace Assignment02Comp2139.Areas.Management.Models;

public class Account : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}