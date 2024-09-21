using SistemaPesquisa.Models;

namespace SistemaPesquisa.Repositories.Interfaces
{
    public interface IItemFormularioRepository
    {
        IEnumerable<ItemFormulario> ItemsFormulario { get; }
    }
}
