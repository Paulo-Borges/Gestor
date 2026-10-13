using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Gestor.Api.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
        [JsonIgnore] // Impede que o Swagger exija esse campo na criação
        //Pode varias Ordens de Serviços----------------------------x---------------------
        public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();
    }
}
