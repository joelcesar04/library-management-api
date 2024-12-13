using library_jc_API.Models;

namespace library_jc_API.Services.Interfaces;

public interface ICategoriaService
{
    Task<IEnumerable<Categoria>> GetAllAsync();
    Task<Categoria?> GetByIdAsync(int id);
    Task<Categoria?> CreateAsync(Categoria categoria);
    Task<Categoria?> GetByNameAsync(string categoriaName);
    Task<Categoria?> UpdateAsync(int id, Categoria categoria);
    Task<Categoria?> DeleteAsync(int id);
}
