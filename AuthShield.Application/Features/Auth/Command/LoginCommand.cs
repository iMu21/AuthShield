﻿namespace AuthShield.Application.Features.Auth.Command
{
    public class LoginCommand
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
