using library_jc_API.Models;

namespace library_jc_API.Services.Interfaces;

public interface IAlunoService
{
    Task<IEnumerable<Aluno?>> GetAllAsync();
    Task<Aluno?> GetByMatriculaAsync(int matricula);
    Task<Aluno?> GetByIdAsync(int id);
    Task<Aluno?> CreateAsync(Aluno aluno);
    Task<Aluno?> UpdateAsync(int matricula, Aluno aluno);
    Task<Aluno?> DeleteAsync(int matricula);
}
