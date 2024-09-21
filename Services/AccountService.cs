using Microsoft.AspNetCore.Identity;
using SistemaPesquisa.Data;
using SistemaPesquisa.Models;

namespace SistemaPesquisa.Services
{
    public class AccountService
    {
        private readonly SistemaPesquisaContext _context;

        public AccountService(SistemaPesquisaContext context)
        {
            _context = context;
        }

        public List<IdentityUser> GetAccounts()
        {
            List<IdentityUser> accounts = _context.Users.ToList();
            return accounts;
        }
    }
}

