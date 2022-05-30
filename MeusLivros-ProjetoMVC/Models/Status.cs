using System.ComponentModel.DataAnnotations;

namespace MeusLivros_ProjetoMVC.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [Required(ErrorMessage = "Informe o Status")]
        [Display(Name = "Status")]
        public string Mensagem { get; set; }
    }
}
