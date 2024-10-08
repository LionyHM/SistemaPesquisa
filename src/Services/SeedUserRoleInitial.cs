using Microsoft.AspNetCore.Identity;
using SistemaPesquisa.Services.Interfaces;

namespace SistemaPesquisa.Services;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("Membro").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Membro";
            role.NormalizedName = "MEMBRO";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
        if (!_roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }

    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "12345678").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Membro").Wait();
            }
        }

        if (_userManager.FindByEmailAsync("admin").Result == null)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = "admin";
            user.NormalizedUserName = "ADMIN";
            user.NormalizedEmail = "ADMIN";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Teste.123").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
}