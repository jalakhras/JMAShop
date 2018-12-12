using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JMAShop.Auth
{
    public class ApplicationUser : IdentityUser
    {
    
        public DateTime Birthdate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool? IsOwner { get; set; }
    }
}