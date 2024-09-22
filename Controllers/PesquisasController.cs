using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Services;

namespace SistemaPesquisa.Controllers;

[Authorize]
public class PesquisasController : Controller
{
    private readonly SistemaPesquisaContext _context;

    private readonly SetorService _setorService;

    private readonly FormularioService _formularioService;
    private readonly PesquisaService _pesquisaService;

    public PesquisasController(SistemaPesquisaContext context, SetorService setorService, FormularioService formularioService, PesquisaService pesquisaService)
    {
        _context = context;
        _setorService = setorService;
        _formularioService = formularioService;
        _pesquisaService = pesquisaService;
    }


    // GET: Pesquisas
    public async Task<IActionResult> Index()
    {
        return View(await _context.Pesquisa.ToListAsync());
    }

    // GET: Pesquisas/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pesquisa = await _context.Pesquisa
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pesquisa == null)
        {
            return NotFound();
        }

        return View(pesquisa);
    }

    // GET: Pesquisas/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Pesquisas/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id,AnoPesquisa,Finalizado,DataCriacao,DataAtualizacao,Meta")] Pesquisa pesquisa)
    {


        // RedirectToAction("CreateForm", "FormulariosController");

        if (_pesquisaService.GetPesquisaAtiva())
        {

            ViewBag.ErrorMessage = "Já existe uma pesquisa ativa";
            ViewBag.StyleMessage = "text-danger";
            return View();
        }
        ViewBag.SuccessMessage = "Pesquisa criada com sucesso!";
        ViewBag.StyleMessage = "text-info";
        List<Setor> setores = _setorService.FindAll();
        _formularioService.AddFormularios(setores, pesquisa);
        

        if (ModelState.IsValid)
        {
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["message"] = "Pesquisa Criada com sucesso!";

        return View();
       
    }

    // GET: Pesquisas/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pesquisa = await _context.Pesquisa.FindAsync(id);
        if (pesquisa == null)
        {
            return NotFound();
        }
        return View(pesquisa);
    }

    // POST: Pesquisas/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,AnoPesquisa,Finalizado,DataCriacao,DataAtualizacao,Meta")] Pesquisa pesquisa)
    {
        if (id != pesquisa.Id)
        {
            return NotFound();
        }


            try
            {
                _context.Update(pesquisa);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PesquisaExists(pesquisa.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
    
    }

    // GET: Pesquisas/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pesquisa = await _context.Pesquisa
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pesquisa == null)
        {
            return NotFound();
        }

        return View(pesquisa);
    }

    // POST: Pesquisas/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
   //     var formulario

        var pesquisa = await _context.Pesquisa.FindAsync(id);
        if (pesquisa != null)
        {
            _context.Pesquisa.Remove(pesquisa);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PesquisaExists(int id)
    {
        return _context.Pesquisa.Any(e => e.Id == id);
    }
}
