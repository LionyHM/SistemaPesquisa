using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SistemaPesquisa.Models;

public class Setor : DataBase
{
    [Key]
    public int Id { get; set; }
    [StringLength(150, ErrorMessage = "O nome do setor deve conter no máximo 150 caracteres")]
    [Required(ErrorMessage = "Informe o nome do setor")]
    [Display(Name = "Nome do setor")]
    public string Nome { get; set; }
    public bool Ativo { get; set; } = true;

    public ICollection<Formulario>? Formularios { get; set;} = new List<Formulario>();
    public IdentityUser Usuario { get; set;}

    public Setor() { }

    public Setor(int id, string nome, bool ativo, IdentityUser usuario)
    {
        Id = id;
        Nome = nome;
        Ativo = ativo;
        Usuario = usuario;
    }
}
