using library_jc_API.Data;
using library_jc_API.Dtos.Autor;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;

        public AutorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Autor>> GetAllAsync()
        {
            var autores = await _context.Autores.ToListAsync();
            return autores;
        }

        public async Task<Autor?> GetByIdAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);

            if (autor == null)
                return null!;

            return autor!;
        }

        public async Task<Autor?> CreateAsync(Autor autorModel)
        {
            var autorExists = GetByName(autorModel.Nome);

            if (autorExists != null)
            {
                return null;
            }

            await _context.Autores.AddAsync(autorModel);
            await _context.SaveChangesAsync();

            return autorModel;
        }

        public async Task<Autor?> UpdateAsync(int id, UpdateAutorDto updateDto)
        {
            var existsAutor = await _context.Autores.FirstOrDefaultAsync(a => a.AutorId == id);

            if (existsAutor == null)
            {
                return null;
            }

            existsAutor.Nome = updateDto.Nome;
            existsAutor.DataNascimento = updateDto.DataNascimento;
            existsAutor.Biografia = updateDto.Biografia;
            existsAutor.PaisOrigem = updateDto.PaisOrigem;

            await _context.SaveChangesAsync();

            return existsAutor;
        }

        public async Task<Autor?> DeleteAsync(int id)
        {
            var autor = await _context.Autores.FirstOrDefaultAsync(a => a.AutorId == id);

            if (autor == null)
                return null;

            _context.Remove(autor);

            await _context.SaveChangesAsync();

            return autor;
        }

        public Autor? GetByName(string nome)
        {
            var autor = _context.Autores.FirstOrDefault(a => a.Nome.ToLower().Contains(nome.ToLower()));

            if (autor == null)
                return null;

            return autor;
        }
    }
}
