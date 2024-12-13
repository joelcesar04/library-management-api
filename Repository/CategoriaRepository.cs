using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;
    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> GetAllAsync() => await _context.Categorias.AsNoTracking().ToListAsync();

    public async Task<Categoria?> GetByIdAsync(int id) => await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id);

    public async Task<Categoria?> CreateAsync(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<Categoria?> UpdateAsync(Categoria categoriaModel)
    {
        _context.Entry(categoriaModel).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return categoriaModel;
    }

    public async Task<Categoria?> DeleteAsync(Categoria categoria)
    {
        _context.Remove(categoria);
        await _context.SaveChangesAsync();

        return categoria;
    }
    public async Task<Categoria?> GetByNameAsync(string categoriaName) => await _context.Categorias.FirstOrDefaultAsync(c => c.Nome.ToLower().Contains(categoriaName.ToLower()));
}
