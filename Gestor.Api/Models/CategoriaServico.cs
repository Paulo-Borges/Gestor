using System.ComponentModel.DataAnnotations;

namespace Gestor.Api.Models
{
    public class CategoriaServico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da Categoria é obrigatório.")]
        [StringLength(80)]
        [Display(Name = "Categoria")]
        public string Nome { get; set; }
        [StringLength(200)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        //Pode varias Ordens de Serviços----------------------------x---------------------
        public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();
    }
}
