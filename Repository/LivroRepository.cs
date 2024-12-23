using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository;

public class LivroRepository : ILivroRepository
{
    private readonly AppDbContext _context;
    public LivroRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Livro>> GetAllAsync() => await _context.Livros
                                                                         .Include(l => l.Autor)
                                                                         .Include(l => l.Categoria)
                                                                         .AsNoTracking()
                                                                         .ToListAsync();

    public async Task<Livro?> GetByIdAsync(int id) => await _context.Livros
                                                                    .Include(l => l.Autor)
                                                                    .Include(l => l.Categoria)
                                                                    .FirstOrDefaultAsync(l => l.LivroId == id);

    public async Task<Livro?> CreateAsync(Livro livro)
    {
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();

        return livro;
    }

    public async Task<Livro?> UpdateAsync(Livro livro)
    {
        _context.Livros.Entry(livro).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return livro;
    }

    public async Task<Livro?> DeleteAsync(Livro livro)
    {
        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();

        return livro;
    }
    public async Task<Livro?> GetByTitleAsync(string titulo) => await _context.Livros
                                                                              .FirstOrDefaultAsync(l => l.Titulo.ToLower().Contains(titulo.ToLower()));
}
