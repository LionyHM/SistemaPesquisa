using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Repositories.Interfaces;
using SistemaPesquisa.Services;

namespace SistemaPesquisa.Controllers;

public class FormulariosController : Controller
{
    private readonly SistemaPesquisaContext _context;
    private readonly IFormularioRepository _formularioRepository;
    private readonly FormularioService _formularioService;

    public FormulariosController(SistemaPesquisaContext context, FormularioService formularioservice, IFormularioRepository formularioRepository)
    {
        _context = context;
        _formularioService = formularioservice;
        _formularioRepository = formularioRepository;
    }

    // GET: Formularios
    public IActionResult Index()
    {
        var formularios = _formularioRepository.Formularios.ToList();
        return View(formularios);
    }

    // GET: Formularios/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var formulario = await _context.Formulario
            .FirstOrDefaultAsync(m => m.Id == id);
        if (formulario == null)
        {
            return NotFound();
        }

        return View(formulario);
    }

    // GET: Formularios/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Formularios/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,Finalizado,DataCriacao,DataAtualizacao")] Formulario formulario)
    {
        if (ModelState.IsValid)
        {
            _context.Add(formulario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(formulario);
    }

    // GET: Formularios/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var formulario = await _context.Formulario.FindAsync(id);
        if (formulario == null)
        {
            return NotFound();
        }
        return View(formulario);
    }

    // POST: Formularios/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<IActionResult> Edit(int id, [FromBody] ItemFormulario formulario)
    {
        if (formulario == null || !ModelState.IsValid)
        {
            return BadRequest("Dados inválidos ou objeto nulo");
        }

        // Verifica se o ID no URL corresponde ao ID no objeto JSON
        if (formulario.Id <= 0)
        {
            return BadRequest("ID inválido");
        }

        ItemFormulario formularioRepos = _formularioRepository.GetFormularioById(id, formulario.Id);
        if (formularioRepos == null)
        {
            return NotFound();
        }
        // Atualiza o formulário com os novos dados
        formularioRepos.Nota = formulario.Nota;
        formularioRepos.Salvo = formulario.Salvo;
        formularioRepos.NaoSeAplica = formulario.NaoSeAplica;
        formularioRepos.NotaDescricao = formulario.NotaDescricao;
        formularioRepos.DataAtualizacao = DateTime.Now;

        try
        {
            _context.Update(formularioRepos);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FormularioExists(formularioRepos.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Json(formularioRepos.DataAtualizacao); // Retorna uma resposta bem-sucedida
    }

    // GET: Formularios/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var formulario = await _context.Formulario
            .FirstOrDefaultAsync(m => m.Id == id);
        if (formulario == null)
        {
            return NotFound();
        }

        return View(formulario);
    }

    // POST: Formularios/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var formulario = await _context.Formulario.FindAsync(id);
        if (formulario != null)
        {
            _context.Formulario.Remove(formulario);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FormularioExists(int id)
    {
        return _context.Formulario.Any(e => e.Id == id);
    }
}
