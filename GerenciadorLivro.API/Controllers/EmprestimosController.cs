using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorLivro.Application.Services;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/emprestimos")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly LivrosDbContext _context;
        private readonly IEmprestimoService _service;
        public EmprestimosController(LivrosDbContext context, IEmprestimoService service)
        {
            _context = context;
            _service = service;
        }


        // GET api/emprestimos?search=term
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var result = _service.GetAll(search);
            return Ok(result);
        }

        // GET api/emprestimos/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        // POST api/emprestimos
        public IActionResult Post(CreateEmprestimoInputModel model)
        {
            
            var result = _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        // POST api/emprestimos/{id}/devolucao
        [HttpPost("{id}/devolucao")]
        public IActionResult RegistrarDevolucao(int id)
        {
            var result = _service.Devolver(id);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }

    }
}
