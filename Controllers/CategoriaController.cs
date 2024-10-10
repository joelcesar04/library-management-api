using library_jc_API.Dtos.Categoria;
using library_jc_API.Mappers;
using library_jc_API.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoriaModel = await _categoriaRepository.GetAllAsync();

            var categoriaDto = categoriaModel.Select(a => a.ToCategoriaDto());

            return Ok(categoriaDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoriaModel = await _categoriaRepository.GetByIdAsync(id);

            if (categoriaModel == null)
                return NotFound();

            return Ok(categoriaModel.ToCategoriaDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaDto categoriaDto)
        {
            var categoriaModel = categoriaDto.ToCreateCategoriaDto();
            var categoriaExists = await _categoriaRepository.CreateAsync(categoriaModel);

            if (categoriaExists == null)
            {
                return BadRequest(new { message = "Categoria já existe." });
            }


            return CreatedAtAction(nameof(GetById), new { id = categoriaModel.CategoriaId }, categoriaModel.ToCategoriaDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoriaDto categoriaDto)
        {
            var categoriaModel = categoriaDto.ToUpdateCategoriaDto(id);

            var categoria = await _categoriaRepository.UpdateAsync(id, categoriaModel);

            if (categoria == null)
                return NotFound();

            return Ok(categoriaModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaRepository.DeleteAsync(id);

            if (categoria == null)
                return NotFound();

            return NoContent();
        }
    }
}
