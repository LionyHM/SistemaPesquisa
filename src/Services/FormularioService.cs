using SistemaPesquisa.Data;
using SistemaPesquisa.Models;

namespace SistemaPesquisa.Services;

public class FormularioService
{
    private readonly SistemaPesquisaContext _context;
    private readonly ItemFormularioService _itemformularioService;

    public FormularioService(SistemaPesquisaContext context, ItemFormularioService itemformularioService)
    {
        _context = context;
        _itemformularioService = itemformularioService;
    }

    public void AddFormularios(List<Setor> setores, Pesquisa pesquisa)
    {
        List<Formulario> listFormulario = new List<Formulario>();
        foreach (var setor in setores)
        {
            Formulario formulario = new Formulario();
            formulario.Titulo = setor.Nome;
            formulario.Setor = setor;
            formulario.Pesquisa = pesquisa;

            _context.Add(formulario);
            _context.SaveChanges();

            listFormulario.Add(formulario);

        }
        SaveItemsFormularios(listFormulario);
    }

    public void SaveItemsFormularios(List<Formulario> listFormulario)
    {
        foreach (var list in listFormulario)
        {
            List<Formulario> formularios = _context.Formulario.Where(form => form.Id != list.Id && form.Finalizado == false).ToList();
            _itemformularioService.AddItemFormulario(formularios, list.Setor);
        }
    }
}
