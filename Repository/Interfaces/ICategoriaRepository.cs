using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task<Categoria?> CreateAsync(Categoria categoria);
        Task<Categoria?> UpdateAsync(int id, Categoria categoria);
        Task<Categoria?> DeleteAsync(int id);
        Categoria? GetByName(string categoria);
    }
}
