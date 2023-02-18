﻿using Core.Entities.Identity;

namespace API.Dtos
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}