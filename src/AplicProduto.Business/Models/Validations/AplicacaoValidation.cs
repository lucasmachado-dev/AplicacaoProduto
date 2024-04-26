using FluentValidation;

namespace AplicProduto.Business.Models.Validations
{
    public class AplicacaoValidation : AbstractValidator<Aplicacao>
    {
        public AplicacaoValidation()
        {
            
            RuleFor(a => a.FazendaId)
                .NotEmpty().WithMessage("O campo FazendaId é obrigatório");
            RuleFor(a => a.SafraId)
                            .NotEmpty().WithMessage("O campo SafraId é obrigatório");
            RuleFor(a => a.TalhaoId)
                            .NotEmpty().WithMessage("O campo TalhaoId é obrigatório");
            RuleFor(a => a.CicloProducaoId)
                            .NotEmpty().WithMessage("O campo CicloProducaoId é obrigatório");
            RuleFor(a => a.AtividadeId)
                            .NotEmpty().WithMessage("O campo AtividadeId é obrigatório");
        }
    }
}
