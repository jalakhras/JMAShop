using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace JMAShop.ViewModels
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Users = new List<IdentityUser>();
        }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public List<IdentityUser> Users { get; set; }

    }
}