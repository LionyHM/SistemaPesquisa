using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Repositories.Interfaces;

namespace SistemaPesquisa.Repositories;

public class PesquisaRepository : IPesquisaRepository 
{
    private readonly SistemaPesquisaContext _context;

    public PesquisaRepository(SistemaPesquisaContext context)
    {
        _context = context;
    }

    public IEnumerable<Pesquisa> Pesquisas => _context.Pesquisa;

    public Pesquisa PesquisaAtiva => _context.Pesquisa.Where(p => p.Finalizado == false).FirstOrDefault();
}