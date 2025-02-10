using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Aluno?>> GetAllAsync() => await _context.Alunos.AsNoTracking().ToListAsync();

    public async Task<Aluno?> GetByMatriculaAsync(int matricula) => await _context.Alunos.FirstOrDefaultAsync(a => a.Matricula == matricula && a.Ativo);

    public async Task<Aluno?> CreateAsync(Aluno aluno)
    {
        await _context.Alunos.AddAsync(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<Aluno?> UpdateAsync(Aluno aluno)
    {
        _context.Alunos.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<Aluno?> DeleteAsync(Aluno aluno)
    {
        _context.Remove(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<Aluno?> GetByIdAsync(int id) => await _context.Alunos.FirstOrDefaultAsync(a => a.AlunoId == id);
}
