using System.ComponentModel.DataAnnotations;

namespace library_jc_API.Dtos.LivroEmprestado;

public class CreateLivroEmprestadoDto
{
    [Required(ErrorMessage = "O ID do livro é obrigatório.")]
    public int LivroId { get; set; }

    [Required(ErrorMessage = "O ID do aluno é obrigatório.")]
    public int AlunoId { get; set; }
}
