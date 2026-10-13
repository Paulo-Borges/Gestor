using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gestor.Api.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da Categoria é obrigatório.")]
        [StringLength(200)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [StringLength(200)]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }
        [Required]
        [Display(Name = "Data de Abertura")]
        [DataType(DataType.Date)]
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        [Required]
        [Display(Name = "Data de Conclusão")]
        [DataType(DataType.Date)]
        public DateTime? DataConclusão { get; set; }
        [Display(Name = "Status")]
        public StatusOrdem Status { get; set; }
        [Required(ErrorMessage = "Informe o valor do serviço.")]
        [Display(Name = "Valor (R$)")]
        [Range(0, 999999.99, ErrorMessage = "O valor deve ser entre 0 e 999.999,99")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }
        //Só pode ter uma categoria----------------------------x---------------------
        public int? CategoriaServicoId { get; set; }
        public CategoriaServico? CategoriaServico { get; set; }
        //Só pode ter uma cliente----------------------------x---------------------
        public int? ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

    }
}
