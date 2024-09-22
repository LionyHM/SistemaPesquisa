using Microsoft.AspNetCore.Identity;

namespace SistemaPesquisa.Repositories.Interfaces;

public interface IAccountRepository
{
    IEnumerable<IdentityUser> Accounts { get; }
    List<IdentityUser> GetUsuariosSemSetor();
}