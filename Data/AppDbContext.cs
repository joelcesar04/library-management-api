using library_jc_API.Models;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroEmprestado> LivrosEmprestados{ get; set; }
    }
}
