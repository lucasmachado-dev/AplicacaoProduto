using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class AtividadeValidation : AbstractValidator<Atividade>
    {
        public AtividadeValidation()
        {
            RuleFor(a => a.Descricao)
                .NotEmpty().WithMessage("O campo Descricao é obrigatório")
                .Length(2, 50).WithMessage("O campo Descricao precisa contar entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
