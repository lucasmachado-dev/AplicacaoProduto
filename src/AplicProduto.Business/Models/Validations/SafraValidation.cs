using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class SafraValidation : AbstractValidator<Safra>
    {
        public SafraValidation()
        {
            RuleFor(s => s.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório")
                .Length(2, 200).WithMessage("O campo Descricao precisa contar entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
