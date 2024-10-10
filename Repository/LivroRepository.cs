using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly AppDbContext _context;
        public LivroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> GetAllAsync()
        {
            var livros = await _context
                .Livros
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .ToListAsync();

            return livros;
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            var livro = await _context
                .Livros
                .Include(l => l.Autor)
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(l => l.LivroId == id);

            if (livro == null)
                return null;

            return livro;
        }

        public async Task<Livro?> CreateAsync(Livro livro)
        {
            var livroExists = await _context.Livros.FirstOrDefaultAsync(l => l.Titulo.ToLower().Contains(livro.Titulo.ToLower()));

            if (livroExists != null)
            {
                return null;
            }

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            return livro;
        }

        public async Task<Livro?> UpdateAsync(int id, Livro livroModel)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(c => c.LivroId == id);

            if (livro == null)
                return null;

            livro.ISBN = livroModel.ISBN;
            livro.Titulo = livroModel.Titulo;
            livro.DataPublicacao = livroModel.DataPublicacao;
            livro.AutorId = livroModel.AutorId;
            livro.Edicao = livroModel.Edicao;
            livro.CategoriaId = livroModel.CategoriaId;
            livro.Descricao = livroModel.Descricao;
            livro.Disponivel = livroModel.Disponivel;
            livro.Editora = livroModel.Editora;
            livro.Idioma = livroModel.Idioma;
            livro.Paginas = livroModel.Paginas;

            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro?> DeleteAsync(int id)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(l => l.LivroId == id);

            if (livro == null)
                return null;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return livro;
        }
    }
}
