using AplicProduto.Api.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace AplicProduto.Business.Models
{
    public class AplicacaoViewModel : EntityViewModel
    {
        
        [Required(ErrorMessage ="É obrigatório informar o campo {0}")]
        public Guid FazendaId { get; set; }
        
        [Required(ErrorMessage = "É obrigatório informar o campo {0}")]
        public Guid SafraId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o campo {0}")]
        public Guid TalhaoId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o campo {0}")]
        public Guid CicloProducaoId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o campo {0}")]
        public Guid AtividadeId { get; set; }
        
        public DateOnly DataInicio { get; set; }
        
        public DateOnly DataFinal { get; set; }
        
        public bool Executada { get; set; } = false;
    }
}
