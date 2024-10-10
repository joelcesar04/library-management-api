using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro?> GetByIdAsync(int id);
        Task<Livro?> CreateAsync(Livro livro);
        Task<Livro?> UpdateAsync(int id, Livro livro);
        Task<Livro?> DeleteAsync(int id);
    }
}
