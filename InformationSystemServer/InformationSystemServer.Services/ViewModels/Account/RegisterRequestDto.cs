﻿namespace InformationSystemServer.Services.ViewModels.Account
{
    public class RegisterRequestDto
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ReCaptchaToken { get; set; }
    }
}
