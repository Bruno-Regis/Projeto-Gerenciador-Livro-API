using GerenciadorLivro.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET api/usuarios/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/usuarios
        [HttpPost]  
        public IActionResult Post(CreateUsuarioInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1234 }, model);
        }

        // PUT api/usuarios/1234
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateUsuarioInputModel model)
        {
            return NoContent();
        }

    }
}
