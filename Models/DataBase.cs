namespace SistemaPesquisa.Models
{
    public class DataBase
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAtualizacao { get; set; } = new DateTime(2000, 1, 1, 0, 0, 0);

    }
}
