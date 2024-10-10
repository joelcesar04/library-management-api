using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required(ErrorMessage = "O nome do autor é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do autor deve ter entre 1 e 100 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O país de origem do autor é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O país de origem do autor deve ter entre 1 e 100 caracteres.")]
        [Display(Name = "País de Origem")]
        public string PaisOrigem { get; set; } = string.Empty;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida de nascimento.")]
        public DateTime DataNascimento { get; set; }

        [StringLength(500, ErrorMessage = "A biografia do autor não pode exceder 500 caracteres.")]
        [Display(Name = "Biografia")]
        public string Biografia { get; set; } = string.Empty;

        public IList<Livro>? Livros { get; set; }
    }
}
