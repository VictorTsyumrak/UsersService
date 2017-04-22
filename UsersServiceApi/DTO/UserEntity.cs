﻿using System;

namespace DTO
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
