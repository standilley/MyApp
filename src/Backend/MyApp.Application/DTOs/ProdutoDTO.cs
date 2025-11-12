
namespace MyApp.Application.DTOs
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
