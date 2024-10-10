using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository
{
    public class LivroEmprestadoRepository : ILivroEmprestado
    {
        private readonly AppDbContext _context;
        public LivroEmprestadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<LivroEmprestado>> GetAllAsync()
        {
            var emprestimo = await 
                _context.LivrosEmprestados
                .Include(l => l.Livro)
                .Include(a => a.Aluno)
                .ToListAsync();

            return emprestimo;
        }
    }
}
