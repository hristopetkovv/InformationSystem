﻿using InformationSystemServer.Infrastructure.Enums;

namespace InformationSystemServer.ViewModels.Account
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Token { get; set; }

        public Role Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
