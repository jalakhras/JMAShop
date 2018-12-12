using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JMAShop.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Claims = new List<IdentityUserClaim<string>>();
        }
        public DateTime Birthdate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool? IsOwner { get; set; }

        public ICollection<IdentityUserClaim<string>> Claims { get; set; }
    }
}