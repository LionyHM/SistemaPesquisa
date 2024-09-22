using SistemaPesquisa.Data;
using SistemaPesquisa.Models;

namespace SistemaPesquisa.Services;

public class ItemFormularioService
{
    private readonly SistemaPesquisaContext _context;

    public ItemFormularioService(SistemaPesquisaContext context)
    {
        _context = context;
    }

    public void AddItemFormulario(List<Formulario> formularios, Setor setor)
    {
        foreach (var form in formularios)
        {
            ItemFormulario itemFormulario = new ItemFormulario();
            itemFormulario.Formulario = form;
            itemFormulario.Setor = setor;
            _context.ItemFormulario.Add(itemFormulario);
            _context.SaveChanges();
        }
    }
}
