using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Dtos.Categoria
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da categoria deve ter entre 1 e 100 caracteres.")]
        [Display(Name = "Categoria")]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "A descrição da categoria não pode exceder 500 caracteres.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
    }
}
