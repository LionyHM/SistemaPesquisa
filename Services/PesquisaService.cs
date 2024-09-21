using SistemaPesquisa.Data;

namespace SistemaPesquisa.Services
{
    public class PesquisaService
    {
        private readonly SistemaPesquisaContext _context;

        public PesquisaService(SistemaPesquisaContext context)
        {
            _context = context;
        }

        public bool GetPesquisaAtiva()
        {
            bool pesquisaAtiva = _context.Pesquisa.Where(pesq => pesq.Finalizado == false).ToList().Count() > 0;
            return pesquisaAtiva;
        }
    }
}

