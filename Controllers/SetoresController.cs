using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Repositories.Interfaces;


namespace SistemaPesquisa.Controllers
{
    [Authorize("Admin")]
    public class SetoresController : Controller
    {
        private readonly SistemaPesquisaContext _context;
        private readonly IAccountRepository _accountRepository;

    
        public SetoresController(SistemaPesquisaContext context, IAccountRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
           
        }

        // GET: Setores
        public async Task<IActionResult> Index()
        {
            var setor = await _context.Setor.Include(u => u.Usuario).ToListAsync();
            return View(setor);
        }

        // GET: Setores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _context.Setor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setor == null)
            {
                return NotFound();
            }
        
            return View(setor);
        }

        // GET: Setores/Create
        public IActionResult Create()
        {
            var accounts = _accountRepository.GetUsuariosSemSetor();
            ViewBag.Accounts = accounts;

            return View();
        }

        // POST: Setores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Usuario,Ativo,DataCriacao,DataAtualizacao")] Setor setor, string Usuario)
        {
   
                var account = _context.Users.Where(u => u.Id == Usuario).FirstOrDefault();
                setor.Usuario = account;
                _context.Add(setor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
        }

        // GET: Setores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _context.Setor.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }

            var accounts = _accountRepository.GetUsuariosSemSetor();
            ViewBag.Accounts = accounts;

            return View(setor);
        }

        // POST: Setores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Usuario,Ativo,DataCriacao,DataAtualizacao")] Setor setor, string Usuario)
        {
            var account = _context.Users.Where(u => u.Id == Usuario).FirstOrDefault();
            setor.Usuario = account;

            if (id != setor.Id)
            {
                return NotFound();
            }


                try
                {
                    _context.Update(setor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorExists(setor.Id))
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

        // GET: Setores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _context.Setor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // POST: Setores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setor = await _context.Setor.FindAsync(id);
            if (setor != null)
            {
                _context.Setor.Remove(setor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetorExists(int id)
        {
            return _context.Setor.Any(e => e.Id == id);
        }
    }
}