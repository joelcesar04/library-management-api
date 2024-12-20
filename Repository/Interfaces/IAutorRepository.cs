using library_jc_API.Dtos.Autor;
using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task<Autor?> CreateAsync(Autor autor);
    Task<Autor?> UpdateAsync(Autor autor);
    Task<Autor?> DeleteAsync(Autor autor);
    Task<Autor?> GetByNameAsync(string nome);
}
