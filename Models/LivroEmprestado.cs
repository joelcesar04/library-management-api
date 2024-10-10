using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Models
{
    public class LivroEmprestado
    {
        public LivroEmprestado()
        {
            DataEmprestimo = DateTime.Now;
            DataDevolucaoPrevista = DataEmprestimo.AddDays(5);
        }
        public int LivroEmprestadoId { get; set; }

        [Required(ErrorMessage = "O ID do livro é obrigatório.")]
        public int LivroId { get; set; }
        public Livro? Livro { get; set; }

        [Required(ErrorMessage = "O ID do aluno é obrigatório.")]
        public int AlunoId { get; set; }
        public Aluno? Aluno { get; set; }

        [Required(ErrorMessage = "A data de empréstimo é obrigatória.")]
        [Display(Name = "Data de Empréstimo")]
        [DataType(DataType.Date)]
        public DateTime DataEmprestimo { get; set; }

        [Required(ErrorMessage = "A data de devolução prevista é obrigatória.")]
        [Display(Name = "Data de Devolução Prevista")]
        [DataType(DataType.Date)]
        public DateTime DataDevolucaoPrevista { get; set; }

        [Display(Name = "Data de Devolução Real")]
        [DataType(DataType.Date)]
        public DateTime? DataDevolucaoReal { get; set; }
    }
}
