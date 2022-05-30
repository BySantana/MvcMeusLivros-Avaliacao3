using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeusLivros_ProjetoMVC.Models
{
    public class Editora
    {
        public int EditoraId { get; set; }

        [Required(ErrorMessage = "Informe o nome da Editora")]
        [Display(Name = "Editora")]
        public string NomeEditora { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
