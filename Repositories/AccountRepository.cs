using Microsoft.AspNetCore.Identity;
using SistemaPesquisa.Data;
using SistemaPesquisa.Repositories.Interfaces;

namespace SistemaPesquisa.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly SistemaPesquisaContext _context;
        private readonly ISetorRepository _setorRepository;

        public AccountRepository(SistemaPesquisaContext context, ISetorRepository setorRepository)
        {
            _context = context;
            _setorRepository = setorRepository;
        }

        public IEnumerable<IdentityUser> Accounts => _context.Users;

        public List<IdentityUser> GetUsuariosSemSetor()
        {
            List<IdentityUser> usersSemSetor = new List<IdentityUser>();
            List<IdentityUser> users = _context.Users.ToList();
            foreach (IdentityUser user in users)
            {
                if(_setorRepository.GetSetorUsuario(user.Id) == null && !user.UserName.Contains("admin"))
                {
                     usersSemSetor.Add(user);
                }
            }

            return usersSemSetor;
        }
    }
}