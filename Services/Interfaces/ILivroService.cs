using library_jc_API.Models;

namespace library_jc_API.Services.Interfaces;

public interface ILivroService
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);
    Task<Livro?> CreateAsync(Livro livro);
    Task<Livro?> GetByTitleAsync(string titulo);
    Task<Livro?> UpdateAsync(int id, Livro livro);
    Task<Livro?> DeleteAsync(int id);
}
