﻿using System;

namespace api.calendar.DTO.UserAdmin
{
    public class UserAdminListDTO
    {
        public Guid UserIdentity { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
