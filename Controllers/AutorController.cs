using library_jc_API.Dtos.Autor;
using library_jc_API.Mappers;
using library_jc_API.Models;
using library_jc_API.Repository;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers;

[Route("api/autor")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorService _service;
    public AutorController(IAutorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var autores = await _service.GetAllAsync();

        var autoresDto = autores.Select(a => a.ToAutorDto()).ToList();

        return Ok(autoresDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var autor = await _service.GetByIdAsync(id);

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
        var autorExists = await _service.GetByNameAsync(autorModel.Nome);

        if (autorExists is not null)
            return BadRequest(new { message = "Autor já existe." });

        await _service.CreateAsync(autorModel);

        return CreatedAtAction(nameof(GetById), new { id = autorModel.AutorId }, autorModel.ToAutorDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAutorDto autorDto)
    {
        var autorModel = autorDto.ToUpdateAutorDto(id);

        var autor = await _service.UpdateAsync(id, autorModel);

        if (autor == null)
            return NotFound();

        return Ok(autorModel.ToAutorDto());

    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var autorModel = await _service.DeleteAsync(id);

        if (autorModel == null)
            return NotFound();

        return NoContent();
    }
}
