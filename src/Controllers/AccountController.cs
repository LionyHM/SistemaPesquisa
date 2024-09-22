using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaPesquisa.Repositories.Interfaces;
using SistemaPesquisa.ViewModels;

namespace SistemaPesquisa.Controllers;

public class AccountController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signManager;
    private readonly ISetorRepository _setorRepository;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager, ISetorRepository setorRepository)
    {
        _userManager = userManager;
        _signManager = signManager;
        _setorRepository = setorRepository;
    }

    public IActionResult Login(string returnUrl = " ")
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginVM)
    {
        if (!ModelState.IsValid)
            return View(loginVM);

        var user = await _userManager.FindByNameAsync(loginVM.UserName);

        if (user != null)
        {
            var result = await _signManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (result.Succeeded)
            {

                var setor = _setorRepository.GetSetorUsuario(user.Id);
                if (setor != null)
                {
                    HttpContext.Session.SetString("SetorNome", setor.Nome);
                    HttpContext.Session.SetString("SetorId", setor.Id.ToString());
                }
                else if (user.Id != "0363e5b6-9837-439d-a526-281b21d989ed")
                {
                    HttpContext.Session.SetString("SetorNome", "Sem Setor Cadastrado");
                    HttpContext.Session.SetString("SetorId", "9999");
                }
                else
                {
                    HttpContext.Session.SetString("SetorNome", "Admin");
                    HttpContext.Session.SetString("SetorId", "0");
                }
                return RedirectToAction("Index", "Home");

            }
        }
        ModelState.AddModelError("", "Falha ao realizar o login!!");
        return View(loginVM);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(LoginViewModel registroVM)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = registroVM.UserName };
            var result = await _userManager.CreateAsync(user, registroVM.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Membro");
                return RedirectToAction("Login", "Account");
            }
            else
            {
                this.ModelState.AddModelError("Registro", "Falha ao registrar o usuário");
            }
        }
        return View(registroVM);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        HttpContext.Session.Clear();

        await _signManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

}