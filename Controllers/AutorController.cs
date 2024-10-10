using library_jc_API.Dtos.Autor;
using library_jc_API.Mappers;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers
{
    [Route("api/autor")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;
        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var autores = await _autorRepository.GetAllAsync();

            var autoresDto = autores.Select(a => a.ToAutorDto()).ToList();

            return Ok(autoresDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var autor = await _autorRepository.GetByIdAsync(id);

            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor.ToAutorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAutorDto autorDto)
        {
            var autorModel = autorDto.ToCreateAutorDto();
            var autorExists = await _autorRepository.CreateAsync(autorModel);

            if (autorExists == null)
            {
                return BadRequest(new { message = "Autor já existe." });
            }

            return CreatedAtAction(nameof(GetById), new { id = autorModel.AutorId }, autorModel.ToAutorDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAutorDto autorDto)
        {
            var autorModel = await _autorRepository.UpdateAsync(id, autorDto);

            if (autorModel == null)
                return NotFound();

            return Ok(autorModel.ToAutorDto());

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var autorModel = await _autorRepository.DeleteAsync(id);

            if(autorModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
