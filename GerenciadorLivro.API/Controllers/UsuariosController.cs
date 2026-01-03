using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorLivro.Application.Services;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        // GET api/usuarios?search=term
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var result = _service.GetAll(search);
            return Ok(result);
        }


        // GET api/usuarios/1234
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

        // POST api/usuarios
        [HttpPost]   
        public IActionResult Post(CreateUsuarioInputModel model)
        {
            var result = _service.Insert(model);
            return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
        }

    }
}
