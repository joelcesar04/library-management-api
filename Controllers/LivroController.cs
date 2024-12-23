using library_jc_API.Dtos.Livro;
using library_jc_API.Mappers;
using library_jc_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers;

[Route("api/livro")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;
    private readonly ICategoriaService _categoriaService;
    private readonly IAutorService _autorService;

    public LivroController(ILivroService livroService, ICategoriaService categoriaService, IAutorService autorService)
    {
        _livroService = livroService;
        _categoriaService = categoriaService;
        _autorService = autorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var livros = await _livroService.GetAllAsync();
        var livrosDto = livros.Select(a => a.ToLivroDto());

        return Ok(livrosDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var livro = await _livroService.GetByIdAsync(id);

        if (livro == null)
            return NotFound();

        return Ok(livro.ToLivroDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLivroDto livroDto)
    {
        var livroExists = _livroService.GetByTitleAsync(livroDto.Titulo);
        if (livroExists is not null)
            return BadRequest(new { message = "Já existe um livro com o título informado." });

        var categoria = await _categoriaService.GetByIdAsync(livroDto.CategoriaId);
        if (categoria == null)
            return NotFound(new { message = "Categoria não encontrada." });

        var autor = await _autorService.GetByIdAsync(livroDto.AutorId);
        if (autor == null)
            return NotFound(new { message = "Autor não encontrado." });

        var livro = livroDto.ToCreateLivroDto();
        await _livroService.CreateAsync(livro);

        return CreatedAtAction(nameof(GetById), new { id = livro.LivroId }, livro.ToLivroDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateLivroDto livroDto)
    {
        var livroModel = livroDto.ToUpdateLivroDto(id);
        
        var livro = await _livroService.UpdateAsync(id, livroModel);

        if (livro == null)
            return NotFound();

        return Ok(livroModel.ToLivroDtoPartial());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var livro = await _livroService.DeleteAsync(id);

        if (livro == null)
            return NotFound();

        return NoContent();
    }
}
