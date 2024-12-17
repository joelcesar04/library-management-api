using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces;

public interface IAlunoRepository
{
    Task<IEnumerable<Aluno?>> GetAllAsync();
    Task<Aluno?> GetByMatriculaAsync(int matricula);
    Task<Aluno?> CreateAsync(Aluno aluno);
    Task<Aluno?> UpdateAsync(Aluno aluno);
    Task<Aluno?> DeleteAsync(Aluno aluno);
}
