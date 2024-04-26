using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class FazendaValidation : AbstractValidator<Fazenda>
    {
        public FazendaValidation()
        {
            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório")
                .Length(2, 200).WithMessage("O campo Descricao precisa contar entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
