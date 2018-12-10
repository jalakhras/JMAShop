using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JMAShop.Models
{
    public class JMAShopUser : IdentityUser
    {
        public bool IsOwner { get; set; }
    }
}
