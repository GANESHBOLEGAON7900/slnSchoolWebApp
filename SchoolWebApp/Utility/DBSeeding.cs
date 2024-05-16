﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Models.Entities;

namespace SchoolWebApp.Utility
{
    public class DBSeeding : IDBSeeding
    {

        private UserManager<AppUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private AppDBContext _context;

        public DBSeeding(UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AppDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public void Initialize()
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

            //Check if default Admin user exists or not
            if (!_roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult())
            {
                //Create User Roles in the database
                _roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Student")).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole("Instructor")).GetAwaiter().GetResult();

                //Note: Password should always have one Capital alphabet and one Special Character
                _userManager.CreateAsync(new AppUser
                {
                    UserName = "admin@123.com",
                    Email = "admin@gmail.com",
                    FirstName = "School",
                    LastName = "Admin",
                    Password = "Admin@7900"
                }, "Admin@123").GetAwaiter().GetResult();

                //Get the default Admin User, which is created above.
                var Appuser = _context.Users.FirstOrDefault(x => x.Email == "admin@gmail.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, "Admin").GetAwaiter().GetResult();
                }
            }
        }
    }


    public interface IDBSeeding
    {
        void Initialize();
    }
}
