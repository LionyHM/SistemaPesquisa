namespace SistemaPesquisa.Models;

public class ItemFormulario : DataBase
{
    public int Id { get; set; }
    public int? Nota { get; set; }
    public string? NotaDescricao { get; set; }
    public bool? NaoSeAplica { get; set; }
    public bool? Salvo { get; set; }

    public Setor? Setor { get; set; }

    public Formulario? Formulario { get; set; }

    public ItemFormulario() { }

    public ItemFormulario(int id, int nota, string notaDescricao, bool naoSeAplica, bool salvo, Setor setor, Formulario formulario)
    {
        Id = id;
        Nota = nota;
        NotaDescricao = notaDescricao;
        NaoSeAplica = naoSeAplica;
        Salvo = salvo;
        Setor = setor;
        Formulario = formulario;
    }
}
