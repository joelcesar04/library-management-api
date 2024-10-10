using library_jc_API.Models;
using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Dtos.Aluno
{
    public class AlunoDto
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Matricula { get; set; }
        public string Curso { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public bool Ativo { get; set; }
    }
}
