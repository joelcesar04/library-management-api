using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            var categorias = await _context.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return null;

            return categoria;
        }

        public async Task<Categoria?> CreateAsync(Categoria categoria)
        {
            var categoryExists = GetByName(categoria.Nome);

            if (categoryExists != null)
            {
                return null;
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> UpdateAsync(int id, Categoria categoriaModel)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                return null;

            categoria.Nome = categoriaModel.Nome;
            categoria.Descricao = categoriaModel.Descricao;

            await _context.SaveChangesAsync();

            return categoria;
        }

        public async Task<Categoria?> DeleteAsync(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if(categoria == null) 
                return null;

            _context.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        public Categoria? GetByName(string categoriaModel)
        {
            var categoria = _context.Categorias
                .FirstOrDefault(c => c.Nome.ToLower().Contains(categoriaModel.ToLower()));

            if (categoria == null) 
                return null;

            return categoria;
        }
    }
}
