using library_jc_API.Data;
using library_jc_API.Dtos.Autor;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository;

public class AutorRepository : IAutorRepository
{
    private readonly AppDbContext _context;

    public AutorRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Autor>> GetAllAsync() => await _context.Autores.AsNoTracking().ToListAsync();

    public async Task<Autor?> GetByIdAsync(int id) => await _context.Autores.FirstOrDefaultAsync(c => c.AutorId == id);

    public async Task<Autor?> CreateAsync(Autor autorModel)
    {
        await _context.Autores.AddAsync(autorModel);
        await _context.SaveChangesAsync();

        return autorModel;
    }

    public async Task<Autor?> UpdateAsync(Autor autor)
    {
        _context.Autores.Entry(autor).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return autor;
    }

    public async Task<Autor?> DeleteAsync(Autor autor)
    {
        _context.Remove(autor);
        await _context.SaveChangesAsync();

        return autor;
    }

    public async Task<Autor?> GetByNameAsync(string nome) => await _context.Autores.FirstOrDefaultAsync(a => a.Nome.ToLower().Contains(nome.ToLower()));
}
