using System.ComponentModel.DataAnnotations;

namespace MeusLivros_ProjetoMVC.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Informe o nome do livro")]
        [Display(Name = "Livro")]
        public string NomeLivro { get; set; }

        [Display(Name = "Editora")]
        public int EditoraId { get; set; }
        public Editora? Editora { get; set; }

        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

        [Range(1800, 2022, ErrorMessage = "Ano inválido")]
        [Display(Name = "Ano de lançamento")]
        public int AnoPublicacao { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        [Display(Name = "Gênero")]
        public string Genero { get; set; }

        [Range(0, 10, ErrorMessage = "A nota precisa ser entre 0 e 10")]
        public int? Nota { get; set; }
    }
}
