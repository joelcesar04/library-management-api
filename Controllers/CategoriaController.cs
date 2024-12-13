using library_jc_API.Dtos.Categoria;
using library_jc_API.Mappers;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers;

[Route("api/categoria")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _service;
    public CategoriaController(ICategoriaService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categoriaModel = await _service.GetAllAsync();

        var categoriaDto = categoriaModel.Select(a => a.ToCategoriaDto());

        return Ok(categoriaDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var categoriaModel = await _service.GetByIdAsync(id);

        if (categoriaModel == null)
            return NotFound();

        return Ok(categoriaModel.ToCategoriaDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoriaDto categoriaDto)
    {
        var categoriaModel = categoriaDto.ToCreateCategoriaDto();
        var categoriaExists = await _service.GetByNameAsync(categoriaModel.Nome);

        if (categoriaExists is not null)
        {
            return BadRequest(new { message = "Categoria já existe." });
        }

        await _service.CreateAsync(categoriaModel);

        return CreatedAtAction(nameof(GetById), new { id = categoriaModel.CategoriaId }, categoriaModel.ToCategoriaDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoriaDto categoriaDto)
    {
        var categoriaModel = categoriaDto.ToUpdateCategoriaDto(id);

        var categoria = await _service.UpdateAsync(id, categoriaModel);

        if (categoria == null)
            return NotFound();

        return Ok(categoriaModel.ToCategoriaDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var categoria = await _service.DeleteAsync(id);

        if (categoria == null)
            return NotFound();

        return NoContent();
    }
}
