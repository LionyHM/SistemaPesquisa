using SistemaPesquisa.Models;

namespace SistemaPesquisa.Repositories.Interfaces
{
    public interface IPesquisaRepository
    {
        IEnumerable<Pesquisa> Pesquisas { get; }
        Pesquisa PesquisaAtiva { get; }
    }
}