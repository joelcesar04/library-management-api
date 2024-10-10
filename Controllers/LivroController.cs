using library_jc_API.Dtos.Livro;
using library_jc_API.Mappers;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace library_jc_API.Controllers
{
    [Route("api/livro")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroController(ILivroRepository livroRepository
            , ICategoriaRepository categoriaRepository
            , IAutorRepository autorRepository)
        {
            _livroRepository = livroRepository;
            _categoriaRepository = categoriaRepository;
            _autorRepository = autorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var livros = await _livroRepository.GetAllAsync();
            var livrosDto = livros.Select(a => a.ToLivroDto());

            return Ok(livrosDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);

            if (livro == null)
                return NotFound();

            return Ok(livro.ToLivroDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLivroDto livroDto)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(livroDto.CategoriaId);
            if (categoria == null)
                return NotFound();

            var autor = await _autorRepository.GetByIdAsync(livroDto.AutorId);
            if (autor == null)
                return NotFound();

            var livro = livroDto.ToCreateLivroDto();
            
            var livroExists = await _livroRepository.CreateAsync(livro);

            if (livroExists == null)
            {
                return BadRequest(new { message = "Livro já existe." });
            }

            return CreatedAtAction(nameof(GetById), new { id = livro.LivroId }, livro.ToLivroDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateLivroDto livroDto)
        {
            var livroModel = await _livroRepository.GetByIdAsync(id);

            if (livroModel == null)
                return NotFound();

            livroModel = livroDto.ToUpdateLivroDto(id);
            
            await _livroRepository.UpdateAsync(id, livroModel);

            return Ok(livroModel.ToLivroDtoPartial());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _livroRepository.DeleteAsync(id);

            if (livro == null)
                return NotFound();

            return NoContent();
        }
    }
}
