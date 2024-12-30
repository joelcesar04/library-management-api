using Microsoft.AspNetCore.Mvc;
using library_jc_API.Mappers;
using library_jc_API.Services.Interfaces;
using library_jc_API.Dtos.LivroEmprestado;

namespace library_jc_API.Controllers;

[Route("api/emprestimo")]
[ApiController]
public class LivroEmprestadoController : ControllerBase
{
    private readonly ILivroEmprestadoService _service;
    private readonly ILivroService _livroService;
    private readonly IAlunoService _alunoService;

    public LivroEmprestadoController(ILivroEmprestadoService service, ILivroService livroService, IAlunoService alunoService)
    {
        _service = service;
        _livroService = livroService;
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<ActionResult> GetLivrosEmprestados()
    {
        var emprestimos = await _service.GetAllAsync();
        var empretimosDto = emprestimos.Select(e => e.ToLivroEmprestadoDto());

        return Ok(empretimosDto.ToList());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetLivroEmprestado(int id)
    {
        var livroEmprestado = await _service.GetLivroEmprestadoByIdAsync(id);

        if (livroEmprestado == null)
            return NotFound();

        return Ok(livroEmprestado.ToLivroEmprestadoDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateLivroEmprestimo(CreateLivroEmprestadoDto livroEmprestadoDto)
    {
        var livro = await _livroService.GetByIdAsync(livroEmprestadoDto.LivroId);
        if (livro is null)
            return NotFound("Livro não encontrado.");
        if (!livro.Disponivel)
            return BadRequest("O livro selecionado não está disponível para empréstimo no momento.");

        var livrosEmprestados = await _service.PodeEmprestarLivroAsync(livroEmprestadoDto.AlunoId);
        if (livrosEmprestados == false)
            return BadRequest("O aluno já possui dois livros emprestados. É necessário devolver pelo menos um deles antes de solicitar um novo empréstimo.");

        var emprestimoModel = livroEmprestadoDto.ToLivroEmprestado();
        var emprestimo = await _service.CreateAsync(emprestimoModel, livro);

        return CreatedAtAction(nameof(GetLivroEmprestado), new { id = emprestimo!.LivroEmprestadoId }, emprestimo.ToLivroEmprestadoDto());
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLivroEmprestado(int id)
    {
        var livroEmprestado = await _service.UpdateLivroEmprestadoAsync(id);
        
        if (livroEmprestado == null)
            return NotFound();

        return Ok(livroEmprestado.ToLivroEmprestadoDto());
    }
}
