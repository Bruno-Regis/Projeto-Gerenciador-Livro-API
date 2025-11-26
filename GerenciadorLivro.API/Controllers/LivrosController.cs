using GerenciadorLivro.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        // GET api/livros?search=term
        [HttpGet]
        public IActionResult Get(string search ="")
        {
            return Ok();
        }

        // GET api/livros/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        // POST api/livros
        [HttpPost]
        public IActionResult Post(CreateLivroInputModel model)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        // DELETE api/livros/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }




        //// PUT api/livros/1234
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, UpdateLivroInputModel model)
        //{
        //    return NoContent();
        //}

    }
}
