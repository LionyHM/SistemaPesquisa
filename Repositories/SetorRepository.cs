using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Data;
using SistemaPesquisa.Models;
using SistemaPesquisa.Repositories.Interfaces;

namespace SistemaPesquisa.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly SistemaPesquisaContext _context;

        public SetorRepository(SistemaPesquisaContext context)
        {
            _context = context;
        }

        public IEnumerable<Setor> Setores => _context.Setor.Include(s => s.Usuario);

        public IEnumerable<Setor> SetoresAtivos => _context.Setor.Where(s => s.Ativo == true).Include(s => s.Usuario);

        public Setor GetSetorUsuario(string id)
        {
            return _context.Setor.Where(s => s.Usuario.Id == id)
                            .Include(s => s.Usuario).FirstOrDefault();
        }

        
    }

}