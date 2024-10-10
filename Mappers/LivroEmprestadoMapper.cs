using library_jc_API.Dtos.LivroEmprestado;
using library_jc_API.Models;

namespace library_jc_API.Mappers
{
    public static class LivroEmprestadoMapper
    {
        public static LivroEmprestadoDto ToLivroEmprestadoDto(this LivroEmprestado livroEmprestado)
        {
            return new LivroEmprestadoDto
            {
                LivroEmprestadoId = livroEmprestado.LivroEmprestadoId,
                DataEmprestimo = livroEmprestado.DataEmprestimo,
                DataDevolucaoPrevista = livroEmprestado.DataDevolucaoPrevista,
                DataDevolucaoReal = livroEmprestado.DataDevolucaoReal,
                Livro = livroEmprestado.Livro!.ToLivroDtoPartial(),
                Aluno = livroEmprestado.Aluno!.ToAlunoDto()
            };
        }
    }
}
