﻿namespace AuthShield.Application.Model
{
    public class Email
    {
        public string To { get; set; } = string.Empty;
        public string Cc { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; }
    }
}
