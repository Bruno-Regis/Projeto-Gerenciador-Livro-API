using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorLivro.Application.Services;

namespace GerenciadorLivro.API.Controllers
{

    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;
        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        // GET api/livros?search=term
        [HttpGet]
        public IActionResult Get(string search ="")
        {
            var result = _service.GetAll(search);
            return Ok(result);
        }

        // GET api/livros/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        // POST api/livros
        [HttpPost]
        public IActionResult Post(CreateLivroInputModel model)
        {
            var result = _service.Insert(model);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

        // DELETE api/livros/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            
            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
