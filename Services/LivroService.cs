using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;

namespace library_jc_API.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _repository;
    public LivroService(ILivroRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Livro>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Livro?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task<Livro?> CreateAsync(Livro livro) => await _repository.CreateAsync(livro);
    public async Task<Livro?> UpdateAsync(int id, Livro livro)
    {
        var livroModel = await _repository.GetByIdAsync(id);

        if (livroModel is null)
            return null;

        livroModel.ISBN = livro.ISBN;
        livroModel.Titulo = livro.Titulo;
        livroModel.DataPublicacao = livro.DataPublicacao;
        livroModel.AutorId = livro.AutorId;
        livroModel.Edicao = livro.Edicao;
        livroModel.CategoriaId = livro.CategoriaId;
        livroModel.Descricao = livro.Descricao;
        livroModel.Disponivel = livro.Disponivel;
        livroModel.Editora = livro.Editora;
        livroModel.Idioma = livro.Idioma;
        livroModel.Paginas = livro.Paginas;

        await _repository.UpdateAsync(livroModel);
        return livroModel;
    }
    public async Task<Livro?> DeleteAsync(int id)
    {
        var livro = await _repository.GetByIdAsync(id);

        if (livro == null)
            return null;

        await _repository.DeleteAsync(livro);
        return livro;
    }

    public async Task<Livro?> GetByTitleAsync(string titulo) => await _repository.GetByTitleAsync(titulo);

}
