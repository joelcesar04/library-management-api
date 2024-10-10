using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> GetAllAsync();
        Task<Aluno?> GetByMatriculaAsync(int matricula);
        Task<Aluno?> CreateAsync(Aluno aluno);
        Task<Aluno?> UpdateAsync(int matricula, Aluno aluno);
        Task<Aluno?> DeleteAsync(int matricula);
    }
}
