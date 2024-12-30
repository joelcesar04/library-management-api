using library_jc_API.Models;

namespace library_jc_API.Services.Interfaces;

public interface ILivroEmprestadoService
{
    Task<IEnumerable<LivroEmprestado>> GetAllAsync();
    Task<LivroEmprestado?> GetLivroEmprestadoByIdAsync(int id);
    Task<LivroEmprestado?> CreateAsync(LivroEmprestado emprestimoModel, Livro livro);
    Task<LivroEmprestado?> UpdateLivroEmprestadoAsync(int id);
    Task<bool> PodeEmprestarLivroAsync(int alunoId);
}
