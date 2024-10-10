using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace library_jc_API.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            var alunos = await _context.Alunos.ToListAsync();
            return alunos;
        }

        public async Task<Aluno?> GetByMatriculaAsync(int matricula)
        {
            var aluno = await _context.Alunos.FirstOrDefaultAsync(a => a.Matricula == matricula);

            if (aluno == null)
                return null;

            return aluno;
        }
        public async Task<Aluno?> CreateAsync(Aluno aluno)
        {
            var alunoModel = await _context.Alunos.FirstOrDefaultAsync(a => a.Matricula == aluno.Matricula);

            if (alunoModel != null)
                return null;

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno?> UpdateAsync(int matricula, Aluno aluno)
        {
            var alunoModel = _context.Alunos.FirstOrDefault(a => a.Matricula == matricula);

            if (alunoModel == null)
                return null;

            alunoModel.Telefone = aluno.Telefone;
            alunoModel.Curso = aluno.Curso;
            alunoModel.Email = aluno.Email;
            alunoModel.Nome =  aluno.Nome;
            alunoModel.Ativo = aluno.Ativo;

            await _context.SaveChangesAsync();

            return alunoModel;
        }

        public async Task<Aluno?> DeleteAsync(int matricula)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Matricula == matricula);

            if (aluno == null)
                return null;

            _context.Remove(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }
    }
}
