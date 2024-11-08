﻿using DesafioFrequencia.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DesafioFrequencia.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedUsers()
        {
            if(_userManager.FindByEmailAsync("usuario@localhost.com").Result is null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@localhost.com";
                user.Email = "usuario@localhost.com";
                user.NormalizedUserName = "USUARIO@LOCALHOST.COM";
                user.NormalizedEmail = "USUARIO@LOCALHOST.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "U$3r2023").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Participante").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost.com").Result is null
                )
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@localhost.com";
                user.Email = "admin@localhost.com";
                user.NormalizedUserName = "ADMIN@LOCALHOST.COM";
                user.NormalizedEmail = "ADMIN@LOCALHOST.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Adm1n#2023").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if(!_roleManager.RoleExistsAsync("Participante").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Participante";
                role.NormalizedName = "PARTICIPANTE";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "Admin";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
