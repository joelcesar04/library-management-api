using library_jc_API.Dtos.Aluno;
using library_jc_API.Mappers;
using library_jc_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers
{
    [Route("api/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alunos = await _alunoRepository.GetAllAsync();
            var alunosDto = alunos.Select(a => a.ToAlunoDto());

            return Ok(alunosDto);
        }

        [HttpGet("{matricula:int}")]
        public async Task<IActionResult> GetByMatricula(int matricula)
        {
            var aluno = await _alunoRepository.GetByMatriculaAsync(matricula);

            if (aluno == null)
                return NotFound();

            return Ok(aluno.ToAlunoDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAlunoDto alunoDto)
        {
            var alunoModel = alunoDto.ToCreateAlunoDto();
            
            var aluno = await _alunoRepository.CreateAsync(alunoModel);

            if (aluno == null)
                return BadRequest(new { message = "A matrícula informada já está em uso."});

            return CreatedAtAction(nameof(GetByMatricula), new { matricula = alunoModel.Matricula }, alunoModel.ToAlunoDto());
        }

        [HttpPut("{matricula:int}")]
        public async Task<IActionResult> Update(int matricula, [FromBody] UpdateAlunoDto alunoDto)
        {
            var alunoModel = alunoDto.ToUpdateAlunoDto(matricula);

            var aluno = await _alunoRepository.UpdateAsync(matricula, alunoModel);

            if (aluno == null)
                return BadRequest();

            return Ok(aluno.ToAlunoDto());
        }

        [HttpDelete("{matricula:int}")]
        public async Task<IActionResult> Delete(int matricula)
        {
            var aluno = await _alunoRepository.DeleteAsync(matricula);

            if (aluno == null)
                return BadRequest();

            return NoContent();
        }
    }
}
