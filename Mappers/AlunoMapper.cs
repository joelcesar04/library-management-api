using library_jc_API.Dtos.Aluno;
using library_jc_API.Models;

namespace library_jc_API.Mappers
{
    public static class AlunoMapper
    {
        public static AlunoDto ToAlunoDto(this Aluno aluno)
        {
            return new AlunoDto
            {
                AlunoId = aluno.AlunoId,
                Curso = aluno.Curso,
                Email = aluno.Email,
                Matricula = aluno.Matricula,
                Nome = aluno.Nome,
                Telefone = aluno.Telefone,
                Ativo = aluno.Ativo,
            };
        }
        public static Aluno ToCreateAlunoDto(this CreateAlunoDto alunoDto)
        {
            return new Aluno
            {
                Curso = alunoDto.Curso,
                Email = alunoDto.Email,
                Matricula = alunoDto.Matricula,
                Nome = alunoDto.Nome,
                Telefone = alunoDto.Telefone,
                Ativo = true,
            };
        }

        public static Aluno ToUpdateAlunoDto(this UpdateAlunoDto alunoDto, int matricula)
        {
            return new Aluno
            {
                Matricula = matricula,
                Curso = alunoDto.Curso,
                Email = alunoDto.Email,
                Nome = alunoDto.Nome,
                Telefone = alunoDto.Telefone,
                Ativo = alunoDto.Ativo
            };
        }
    }
}
