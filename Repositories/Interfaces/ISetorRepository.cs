using SistemaPesquisa.Models;

namespace SistemaPesquisa.Repositories.Interfaces
{
    public interface ISetorRepository
    {
        IEnumerable<Setor> Setores { get; }
        IEnumerable<Setor> SetoresAtivos { get; }
        
        Setor GetSetorUsuario(string id);
    }
}