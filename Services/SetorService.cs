using SistemaPesquisa.Data;
using SistemaPesquisa.Models;

namespace SistemaPesquisa.Services;

public class SetorService
{
    private readonly SistemaPesquisaContext _context;

    public SetorService(SistemaPesquisaContext context)
    {
        _context = context;
    }

    public List<Setor> FindAll()
    {
        return _context.Setor.ToList();
    }
      public List<Setor> FindByUser(string id)
    {
        return _context.Setor.Where(s => s.Usuario.Id == id).ToList();
    }
}
