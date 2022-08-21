﻿namespace Blog.Models
{
    public class User : BaseModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public User(string? name, string? password, string? email)
        {
            Name = name;
            Password = password;
            Email = email;
        }

    }
}
