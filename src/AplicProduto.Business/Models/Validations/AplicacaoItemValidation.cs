using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class AplicacaoItemValidation : AbstractValidator<AplicacaoItem>
    {
        public AplicacaoItemValidation()
        {
            
            RuleFor(p => p.QuantidadeAplicada)
                .GreaterThan(0).WithMessage("O campo QuantidadeAplicada precisa ser maior que {ComparisonValue}");
        }
    }
}
