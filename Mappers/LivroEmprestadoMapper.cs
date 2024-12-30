using library_jc_API.Dtos.LivroEmprestado;
using library_jc_API.Models;

namespace library_jc_API.Mappers;

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
            LivroId = livroEmprestado.LivroId,
            AlunoId = livroEmprestado.AlunoId
        };
    }

    public static LivroEmprestado ToLivroEmprestado(this CreateLivroEmprestadoDto livroEmprestadoDto)
    {
        return new LivroEmprestado
        {
            AlunoId = livroEmprestadoDto.AlunoId,
            LivroId = livroEmprestadoDto.LivroId,
        };
    }
}
