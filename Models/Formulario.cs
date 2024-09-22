namespace SistemaPesquisa.Models;

public class Formulario : DataBase
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public bool? Finalizado { get; set; } = false;

    public int? Nota { get; set; }
    public string? NotaDescricao { get; set; }
    public bool? NaoSeAplica { get; set; }
    public bool? Salvo { get; set; }
    public ICollection<ItemFormulario> ItemFormularios { get; set; } = new List<ItemFormulario>();

    public Pesquisa? Pesquisa { get; set; }

    public Setor Setor { get; set; }

    public Formulario() { }

    public Formulario(int id, string titulo, bool finalizado,
        Pesquisa pesquisa, int nota, string notaDescricao,
        bool naoSeAplica, bool salvo)
    {
        Id = id;
        Titulo = titulo;
        Finalizado = finalizado;
    }
}
