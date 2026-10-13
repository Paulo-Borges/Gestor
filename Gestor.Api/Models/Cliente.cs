namespace Gestor.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        //Pode varias Ordens de Serviços----------------------------x---------------------
        public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();
    }
}
