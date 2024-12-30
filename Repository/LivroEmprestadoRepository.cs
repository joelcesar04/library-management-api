using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository;

public class LivroEmprestadoRepository : ILivroEmprestadoRepository
{
    private readonly AppDbContext _context;
    public LivroEmprestadoRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<LivroEmprestado>> GetAllAsync() => await _context.LivrosEmprestados
                                                                                   .AsNoTracking()
                                                                                   .Include(l => l.Livro)
                                                                                   .Include(a => a.Aluno)
                                                                                   .ToListAsync();
    public async Task<LivroEmprestado?> CreateAsync(LivroEmprestado livroEmprestado)
    {
        await _context.LivrosEmprestados.AddAsync(livroEmprestado);
        await _context.SaveChangesAsync();

        return livroEmprestado;
    }

    public async Task<IEnumerable<LivroEmprestado?>> GetLivrosEmprestadosPorAlunoAsync(int alunoId) => await _context.LivrosEmprestados
                                                                                                                .Where(le => 
                                                                                                                    le.AlunoId == alunoId && 
                                                                                                                    le.DataDevolucaoReal == null)
                                                                                                                .ToListAsync();

    public async Task<LivroEmprestado?> UpdateLivroEmprestadoAsync(LivroEmprestado livroEmprestado, Livro livro)
    {
        _context.LivrosEmprestados.Entry(livroEmprestado).State = EntityState.Modified;
        _context.Livros.Entry(livro).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return livroEmprestado;
    }
    public async Task<LivroEmprestado?> GetLivroEmprestadoByIdAsync(int id) => await _context.LivrosEmprestados.FirstOrDefaultAsync(le => le.LivroEmprestadoId == id);
}