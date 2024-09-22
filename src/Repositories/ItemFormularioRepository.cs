using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Repositories.Interfaces;

namespace SistemaPesquisa.Repositories;

public class ItemFormularioRepository : IItemFormularioRepository
{
    private readonly SistemaPesquisaContext _context;

    public ItemFormularioRepository(SistemaPesquisaContext context)
    {
        _context = context;
    }

    public IEnumerable<ItemFormulario> ItemsFormulario => _context.ItemFormulario;
}