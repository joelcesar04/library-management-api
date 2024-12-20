using library_jc_API.Models;

namespace library_jc_API.Services.Interfaces;

public interface IAutorService
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task<Autor?> CreateAsync(Autor autor);
    Task<Autor?> GetByNameAsync(string nome);
    Task<Autor?> UpdateAsync(int id, Autor autor);
    Task<Autor?> DeleteAsync(int id);
}
