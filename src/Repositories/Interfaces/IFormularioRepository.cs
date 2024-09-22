using SistemaPesquisa.Models;

namespace SistemaPesquisa.Repositories.Interfaces;

public interface IFormularioRepository
{
    IEnumerable<Formulario> Formularios { get; }
    ItemFormulario GetFormularioById(int id, int idForm);
    string GetNomeSetor(int id);
}