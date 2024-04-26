using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class CicloProducaoValidation : AbstractValidator<CicloProducao>
    {
        public CicloProducaoValidation()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório")
                .Length(2, 50).WithMessage("O campo Descricao precisa contar entre {MinLength} e {MaxLength} caracteres");


        }
    }
}
