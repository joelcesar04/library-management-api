using library_jc_API.Dtos.Aluno;
using library_jc_API.Dtos.Livro;

namespace library_jc_API.Dtos.LivroEmprestado
{
    public class LivroEmprestadoDto
    {
        public int LivroEmprestadoId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }
        public LivroDto? Livro { get; set; }
        public AlunoDto? Aluno { get; set; }
    }
}
