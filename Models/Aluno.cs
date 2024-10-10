using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome do aluno deve ter entre 1 e 100 caracteres.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A matrícula do aluno é obrigatória.")]
        [Display(Name = "Matrícula")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "O curso do aluno é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O curso do aluno deve ter entre 1 e 100 caracteres.")]
        [Display(Name = "Curso")]
        public string Curso { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail do aluno é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail do aluno não é válido.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O número de telefone do aluno não pode exceder 20 caracteres.")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public IList<LivroEmprestado>? LivrosEmprestados { get; set; }
    }
}
