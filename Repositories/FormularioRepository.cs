using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Repositories.Interfaces;

namespace SistemaPesquisa.Repositories;

public class FormularioRepository : IFormularioRepository
{
    private readonly SistemaPesquisaContext _context;

    public FormularioRepository(SistemaPesquisaContext context)
    {
        _context = context;
    }

    public IEnumerable<Formulario> Formularios => _context.Formulario
                                                           .Include(s => s.Setor)
                                                           .Include(f => f.ItemFormularios);

    public ItemFormulario GetFormularioById(int idSetor, int idForm)
    {

        Formulario form = _context.Formulario
                        .Where(s => s.Setor.Id == idForm)
                        .Include(i => i.ItemFormularios)
                        .Include(s => s.Setor)
                        .FirstOrDefault();
                        
                        
        ItemFormulario itemForm = _context.ItemFormulario.Where(i => i.Formulario.Id == form.Id && i.Setor.Id == idSetor).FirstOrDefault();

        return itemForm;

    }

    public string GetNomeSetor(int id)
    {
        return _context.Formulario.Include(s => s.Setor).Select(n => n.Setor.Nome).ToString();
    }
}