using MyApp.Domain.Exceptions;
namespace MyApp.Domain.Entities
{
    public class Produto
    {
        public Produto( string nome, decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Preco = preco;
            DataCadastro = DateTime.UtcNow;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public void Atualizar(string nome, decimal preco)
        {
            Validar(nome, preco);
            Nome = nome;
            Preco = preco;
        }
        public void Validar(string nome, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new DomainException("O Nome do produto é obrigatório");
            if (nome.Length > 3)
                throw new DomainException("O Nome do produto deve conter pelo menos 3 caracteres");
            if (preco <= 0)
                throw new DomainException("O preço deve ser maior que zero");
        }
        protected Produto() { }
    }
}
