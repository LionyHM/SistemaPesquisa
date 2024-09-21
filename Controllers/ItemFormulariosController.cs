using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Data;
using SistemaPesquisa.Repositories.Interfaces;
using SistemaPesquisa.Services;

namespace SistemaPesquisa.Controllers
{
    public class ItemFormulariosController : Controller
    {
        private readonly SistemaPesquisaContext _context;
        private readonly IFormularioRepository _formularioRepository;
        private readonly FormularioService _formularioService;

        public ItemFormulariosController(SistemaPesquisaContext context, FormularioService formularioservice, IFormularioRepository formularioRepository)
        {
            _context = context;
            _formularioService = formularioservice;
            _formularioRepository = formularioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetJustificativa(int? idSetorItemFormulario, int? idSetorFormulario)
        {
 
            var formulario = await _context.ItemFormulario
                .Where(m => m.Formulario.Setor.Id == idSetorFormulario && m.Setor.Id == idSetorItemFormulario)
                .FirstOrDefaultAsync();
            if (formulario == null)
            {
                return NotFound();
            }

            return Json(formulario);
        }
    }
}
