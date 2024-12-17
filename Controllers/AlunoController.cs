using library_jc_API.Dtos.Aluno;
using library_jc_API.Mappers;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers;

[Route("api/aluno")]
[ApiController]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _service;

    public AlunoController(IAlunoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alunos = await _service.GetAllAsync();
        var alunosDto = alunos.Select(a => a.ToAlunoDto());

        return Ok(alunosDto);
    }

    [HttpGet("{matricula:int}")]
    public async Task<IActionResult> GetByMatricula(int matricula)
    {
        var aluno = await _service.GetByMatriculaAsync(matricula);

        if (aluno == null)
            return NotFound();

        return Ok(aluno.ToAlunoDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlunoDto alunoDto)
    {
        var alunoModel = alunoDto.ToCreateAlunoDto();
        var alunoExists = await _service.GetByMatriculaAsync(alunoModel.Matricula);

        if (alunoExists is not null)
            return BadRequest(new { message = "A matrícula informada já está em uso." });

        await _service.CreateAsync(alunoModel);

        return CreatedAtAction(nameof(GetByMatricula), new { matricula = alunoModel.Matricula }, alunoModel.ToAlunoDto());
    }

    [HttpPut("{matricula:int}")]
    public async Task<IActionResult> Update(int matricula, [FromBody] UpdateAlunoDto alunoDto)
    {
        var alunoModel = alunoDto.ToUpdateAlunoDto(matricula);

        var aluno = await _service.UpdateAsync(matricula, alunoModel);

        if (aluno == null)
            return NotFound();

        return Ok(aluno.ToAlunoDto());
    }

    [HttpDelete("{matricula:int}")]
    public async Task<IActionResult> Delete(int matricula)
    {
        var aluno = await _service.DeleteAsync(matricula);

        if (aluno == null)
            return NotFound();

        return NoContent();
    }
}
