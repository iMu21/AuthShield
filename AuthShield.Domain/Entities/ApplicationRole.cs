﻿using Microsoft.AspNetCore.Identity;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; } = string.Empty;
}
