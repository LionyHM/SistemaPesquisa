using System.ComponentModel.DataAnnotations;

namespace SistemaPesquisa.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Informe um usuário")]
    [Display(Name = "Usuário")]
    public required string UserName { get; set; }

    [Required(ErrorMessage = "Informe a senha")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public required string Password { get; set; }
}