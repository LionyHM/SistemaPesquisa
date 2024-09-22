using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaPesquisa.Models;

namespace SistemaPesquisa.Data
{
    public class SistemaPesquisaContext : IdentityDbContext<IdentityUser>
    {
        public SistemaPesquisaContext (DbContextOptions<SistemaPesquisaContext> options)
            : base(options)
        {
        }

        public DbSet<Setor> Setor { get; set; } = default!;
        public DbSet<Formulario> Formulario { get; set; } = default!;
        public DbSet<ItemFormulario> ItemFormulario { get; set; } = default!;
        public DbSet<Pesquisa> Pesquisa { get; set; } = default!;
    }
}
