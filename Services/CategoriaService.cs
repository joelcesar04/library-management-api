using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;

namespace library_jc_API.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _repository;
    public CategoriaService(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Categoria>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Categoria?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Categoria?> CreateAsync(Categoria categoria) => await _repository.CreateAsync(categoria);

    public async Task<Categoria?> GetByNameAsync(string categoriaName) => await _repository.GetByNameAsync(categoriaName);

    public async Task<Categoria?> UpdateAsync(int id, Categoria categoriaModel)
    {
        var categoria = await _repository.GetByIdAsync(id);

        if (categoria is null)
            return null;

        categoria.Nome = categoriaModel.Nome;
        categoria.Descricao = categoriaModel.Descricao;

        await _repository.UpdateAsync(categoria);
        return categoria;
    }

    public async Task<Categoria?> DeleteAsync(int id)
    {
        var categoria = await _repository.GetByIdAsync(id);

        if (categoria is null)
            return null;

        await _repository.DeleteAsync(categoria);
        return categoria;
    }
}
