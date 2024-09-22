namespace SistemaPesquisa.Models;

public class Pesquisa : DataBase
{
    public int Id { get; set; }
    public string AnoPesquisa { get; set; } = DateTime.Now.Year.ToString();
    public bool Finalizado { get; set; } = false;

    public int Meta { get; set; }

    public ICollection<Formulario> Formularios { get; set; } = new List<Formulario>();
    public Pesquisa() { }

    public Pesquisa(int id, string anoPesquisa, bool finalizado, int meta)
    {
        Id = id;
        AnoPesquisa = anoPesquisa;
        Finalizado = finalizado;
        Meta = meta;
    }
}
