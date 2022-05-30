using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeusLivros_ProjetoMVC.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Informe o nome do Autor")]
        [Display(Name = "Autor")]
        public string NomeAutor { get; set; }
        public string Nacionalidade { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
