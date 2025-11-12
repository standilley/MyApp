using FluentValidation;
using MyApp.Application.DTOs;

namespace MyApp.Application.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoValidator() {
            RuleFor(p => p.Nome)
                    .NotEmpty()
                    .WithMessage("O Nome é obrigatório")
                    .MaximumLength(100);
            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero");
        }
    }
}
