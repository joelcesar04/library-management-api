using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;

namespace library_jc_API.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<Aluno?>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Aluno?> GetByMatriculaAsync(int matricula) => await _repository.GetByMatriculaAsync(matricula);
    public async Task<Aluno?> CreateAsync(Aluno aluno) => await _repository.CreateAsync(aluno);
    public async Task<Aluno?> UpdateAsync(int matricula, Aluno aluno)
    {
        var alunoModel = await _repository.GetByMatriculaAsync(matricula);

        if (alunoModel is null)
            return null;

        alunoModel.Telefone = aluno.Telefone;
        alunoModel.Curso = aluno.Curso;
        alunoModel.Email = aluno.Email;
        alunoModel.Nome = aluno.Nome;
        alunoModel.Ativo = aluno.Ativo;

        await _repository.UpdateAsync(alunoModel);
        return alunoModel;
    }
    public async Task<Aluno?> DeleteAsync(int matricula)
    {
        var aluno = await _repository.GetByMatriculaAsync(matricula);

        if (aluno is null)
            return null;

        await _repository.DeleteAsync(aluno);
        return aluno;
    }
}
