using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;

namespace library_jc_API.Services;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _repository;
    public AutorService(IAutorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync() => await _repository.GetAllAsync();

    public async Task<Autor?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);

    public async Task<Autor?> CreateAsync(Autor autor) => await _repository.CreateAsync(autor);

    public async Task<Autor?> UpdateAsync(int id, Autor autor)
    {
        var autorModel = await _repository.GetByIdAsync(id);

        if (autorModel == null)
            return null;

        autorModel.Nome = autor.Nome;
        autorModel.DataNascimento = autor.DataNascimento;
        autorModel.Biografia = autor.Biografia;
        autorModel.PaisOrigem = autor.PaisOrigem;

        await _repository.UpdateAsync(autorModel);
        return autorModel;
    }

    public async Task<Autor?> DeleteAsync(int id)
    {
        var autor = await _repository.GetByIdAsync(id);

        if (autor == null) 
            return null;

        await _repository.DeleteAsync(autor);

        return autor;
    }

    public async Task<Autor?> GetByNameAsync(string nome) => await _repository.GetByNameAsync(nome);

}
