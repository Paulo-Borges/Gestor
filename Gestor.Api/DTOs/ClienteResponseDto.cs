namespace Gestor.Api.DTOs
{
    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
