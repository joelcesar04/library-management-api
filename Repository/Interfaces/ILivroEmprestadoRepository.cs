using library_jc_API.Models;

namespace library_jc_API.Repository.Interfaces;

public interface ILivroEmprestadoRepository
{
    Task<IEnumerable<LivroEmprestado>> GetAllAsync();
    Task<LivroEmprestado?> GetLivroEmprestadoByIdAsync(int id);
    Task<LivroEmprestado?> CreateAsync(LivroEmprestado livroEmprestado);
    Task<LivroEmprestado?> UpdateLivroEmprestadoAsync(LivroEmprestado livroEmprestado, Livro livro);
    Task<IEnumerable<LivroEmprestado?>> GetLivrosEmprestadosPorAlunoAsync(int alunoId);
}
