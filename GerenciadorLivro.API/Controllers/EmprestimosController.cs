using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Application.Models;
using Microsoft.AspNetCore.Mvc;
using GerenciadorLivro.Application.Services;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/emprestimos")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly IEmprestimoService _service;
        public EmprestimosController(IEmprestimoService service)
        {
            _service = service;
        }

        // GET api/emprestimos?search=term
        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            var result = await _service.GetAll(search);
            return Ok(result);
        }

        // GET api/emprestimos/1234
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpPost]
        // POST api/emprestimos
        public async Task<IActionResult> Post(CreateEmprestimoInputModel model)
        {
            
            var result = await _service.Insert(model);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        // POST api/emprestimos/{id}/devolucao
        [HttpPost("{id}/devolucao")]
        public async Task<IActionResult> RegistrarDevolucao(int id)
        {
            var result = await _service.Devolver(id);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return NoContent();
        }

    }
}
