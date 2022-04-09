﻿using GroceryApp.Data.Data;
using GroceryApp.Models;
using GroceryApp.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GroceryApp.Data.Repositories
{
    public class RoleInitRepositry 
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplDbContext _context;

        public RoleInitRepositry(UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager, 
                                ApplDbContext context)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;

        }

        public async void RoleInit()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!_roleManager.RoleExistsAsync(WebSiteRole.Role_Admin).GetAwaiter().GetResult())
            {
               await _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Admin).GetAwaiter().GetResult());
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_User).GetAwaiter().GetResult());
                _roleManager.CreateAsync(new IdentityRole(WebSiteRole.Role_Staff).GetAwaiter().GetResult());

                _userManager.CreateAsync(new AppUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    Name = "Admin",
                    PhoneNumber = "08063935581",
                    Address = "Abc",
                    State = "Lagos",
                    PinCode = "112113"
                }, "Admin@123").GetAwaiter().GetResult();

                AppUser user = _context.AppUsers.FirstOrDefault(x => x.Email == "admin@gmail.com");
                _userManager.AddToRoleAsync(user, WebSiteRole.Role_Admin).GetAwaiter().GetResult();
            }
            return;

        }
    }
}
