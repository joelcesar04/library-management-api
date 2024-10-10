using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using library_jc_API.Data;
using library_jc_API.Models;
using library_jc_API.Repository.Interfaces;
using library_jc_API.Mappers;

namespace library_jc_API.Controllers
{
    [Route("api/emprestimo")]
    [ApiController]
    public class LivroEmprestadoController : ControllerBase
    {
        private readonly ILivroEmprestado _livroEmprestadoRepository;

        public LivroEmprestadoController(ILivroEmprestado livroEmprestadoRepository)
        {
            _livroEmprestadoRepository = livroEmprestadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLivrosEmprestados()
        {
            var emprestimos = await _livroEmprestadoRepository.GetAllAsync();
            var empretimosDto = emprestimos.Select(e => e.ToLivroEmprestadoDto());

            return Ok(empretimosDto.ToList());
        }
    }
}
