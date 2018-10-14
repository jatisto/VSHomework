using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LoginRelease.Data
{
    public static class Initializer
    {
        public static async Task Initial(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var users = new IdentityRole("Admin");
                var responsRole = await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("user"))
            {
                var users = new IdentityRole("user");
                var responsRole = await roleManager.CreateAsync(users);
            }
            if (!await roleManager.RoleExistsAsync("manager"))
            {
                var users = new IdentityRole("manager");
                var responsRole = await roleManager.CreateAsync(users);
            }
        }
    }
}
