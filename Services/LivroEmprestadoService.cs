using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;

namespace library_jc_API.Services;

public class LivroEmprestadoService : ILivroEmprestadoService
{
    private readonly ILivroEmprestadoRepository _repository;
    private readonly ILivroRepository _livroRepository;
    public LivroEmprestadoService(ILivroEmprestadoRepository repository, ILivroRepository livroRepository)
    {
        _repository = repository;
        _livroRepository = livroRepository;
    }

    public async Task<IEnumerable<LivroEmprestado>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<LivroEmprestado?> CreateAsync(LivroEmprestado livroEmprestado, Livro livro)
    {
        livroEmprestado.DataEmprestimo = DateTime.Now;
        livroEmprestado.DataDevolucaoPrevista = livroEmprestado.DataEmprestimo.AddDays(7);
        livro.Disponivel = false;

        await _livroRepository.UpdateAsync(livro);
        var emprestimo = await _repository.CreateAsync(livroEmprestado);

        return emprestimo;
    }
    public async Task<LivroEmprestado?> GetLivroEmprestadoByIdAsync(int id) => await _repository.GetLivroEmprestadoByIdAsync(id);
    public async Task<LivroEmprestado?> UpdateLivroEmprestadoAsync(int id)
    {
        var livroEmprestado = await _repository.GetLivroEmprestadoByIdAsync(id);

        if (livroEmprestado is null)
            return null;

        var livro = await _livroRepository.GetByIdAsync(livroEmprestado.LivroId);

        livro!.Disponivel = true;
        livroEmprestado.DataDevolucaoReal = DateTime.Now;

        await _repository.UpdateLivroEmprestadoAsync(livroEmprestado, livro);
        return livroEmprestado;
    }
    public async Task<bool> PodeEmprestarLivroAsync(int alunoId)
    {
        var livrosEmprestados = await _repository.GetLivrosEmprestadosPorAlunoAsync(alunoId);
        return livrosEmprestados.Count() < 2;
    }
}
