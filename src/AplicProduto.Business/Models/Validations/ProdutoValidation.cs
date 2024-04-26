using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class ProdutoValidation : AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {
            RuleFor(p => p.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório")
                .Length(2, 200).WithMessage("O campo Descricao precisa contar entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(p => p.ValorProduto)
                .GreaterThan(0).WithMessage("O campo valor precisa ser maior que {ComparisonValue}");
        }
    }
}
