using System.ComponentModel.DataAnnotations;
using SistemaPesquisa.Models;

namespace SistemaPesquisa.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe um usuário")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }                 

    }
}