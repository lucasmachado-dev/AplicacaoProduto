using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class TalhaoValidation : AbstractValidator<Talhao>
    {
        public TalhaoValidation()
        {
            RuleFor(p => p.Identificacao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório")
                .Length(2, 200).WithMessage("O campo Descricao precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(p => p.Area)
                .GreaterThan(0).WithMessage("O campo Area precisa ser maior que {ComparisonValue}");
        }
    }
}
