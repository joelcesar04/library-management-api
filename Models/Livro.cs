using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage = "O título do livro é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O título do livro deve ter entre 1 e 100 caracteres.")]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição do livro não pode exceder 500 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A editora do livro é obrigatória.")]
        [Display(Name = "Editora")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da editora deve ter entre 1 e 100 caracteres.")]
        public string Editora { get; set; } = string.Empty;

        [StringLength(50, ErrorMessage = "O campo edição deve ter no máximo 50 caracteres.")]
        [Display(Name = "Edição")]
        public string Edicao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ISBN do livro é obrigatório.")]
        [Display(Name = "ISBN")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O ISBN do livro deve ter entre 10 e 50 caracteres.")]
        public string ISBN { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "O número de páginas deve ser maior que zero.")]
        [Display(Name = "Número de Páginas")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "O idioma do livro é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O idioma do livro deve ter entre 1 e 50 caracteres.")]
        [Display(Name = "Idioma")]
        public string Idioma { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de publicação do livro é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida para a publicação do livro.")]
        [Display(Name = "Data de Publicação")]
        public DateTime DataPublicacao { get; set; }
        public bool Disponivel { get; set; }
        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public IList<LivroEmprestado>? LivrosEmprestados { get; set; }
    }
}
