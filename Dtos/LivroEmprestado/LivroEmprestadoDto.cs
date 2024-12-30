namespace library_jc_API.Dtos.LivroEmprestado
{
    public class LivroEmprestadoDto
    {
        public int LivroEmprestadoId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }
        public int LivroId { get; set; }
        public int AlunoId { get; set; }
    }
}
