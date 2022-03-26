﻿namespace Inlamning2Mvc.Models
{
    public class UserProfile
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string Email { get; set; } = "";

        public string Address { get; set; } = "";
        public string ZipCode { get; set; } = "";
        public string City { get; set; } = "";
        public string Country { get; set; } = "";

    }
}
