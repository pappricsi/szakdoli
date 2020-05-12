using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Szakdoli.Models;

namespace Szakdoli.DAL
{
    public class DbInitializer
    {
        public static void Initialize(RaktarContext context, IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Alkalmazott>>();
            context.Database.Migrate();
            if (!context.Roles.Any())
            {
                string[] roleNames = { "Admin", "Raktar vezeto", "Raktaros" };
                IdentityResult roleResult;

                foreach (var roleName in roleNames)
                {
                    var roleExist =  RoleManager.RoleExistsAsync(roleName);

                    if (!roleExist.Result)
                    {

                        roleResult = RoleManager.CreateAsync(new IdentityRole(roleName)).Result;
                    }
                }
            }

            if (context.Alkalmazottak.Any())
            {
                return;   // DB már fel van töltve
            }
            else
            {
                var _user = UserManager.FindByEmailAsync("admin@admin.hu");


                if (_user == null)
                {

                    var poweruser = new Alkalmazott
                    {
                        UserName = "admin@admin.hu",
                        Email = "admin@admin.hu",
                        EmailConfirmed = true,
                        PhoneNumber = "01234567890",
                        PhoneNumberConfirmed = true,
                        TeljesNev = "Admin Felhasználó",

                    };
                    string adminPassword = "Qwe_123";

                    var createPowerUser = UserManager.CreateAsync(poweruser, adminPassword);
                    if (createPowerUser.Result.Succeeded)
                    {

                        UserManager.AddToRoleAsync(poweruser, "Admin");

                    }
                }


            }


        }
    }
}
