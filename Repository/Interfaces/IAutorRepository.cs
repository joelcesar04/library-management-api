using library_jc_API.Dtos.Autor;
using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces
{
    public interface IAutorRepository
    {
        Task<List<Autor>> GetAllAsync();
        Task<Autor?> GetByIdAsync(int id);
        Task<Autor?> CreateAsync(Autor autor);
        Task<Autor?> UpdateAsync(int id, UpdateAutorDto updateDto);
        Task<Autor?> DeleteAsync(int id);
        Autor? GetByName(string nome);
    }
}
