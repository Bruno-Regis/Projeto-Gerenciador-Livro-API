using GerenciadorLivro.API.Entities;
using GerenciadorLivro.API.Models;
using GerenciadorLivro.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.API.Controllers
{

    [Route("api/livros")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrosDbContext _context;
        public LivrosController(LivrosDbContext context)
        {
            _context = context;
        }

        // GET api/livros?search=term
        [HttpGet]
        public IActionResult Get(string search ="")
        {
            var livros = _context.Livros.ToList();

            var model = livros.Select(l => LivroItemViewModel.FromEntity(l)).ToList(); 
            return Ok(model);
        }

        // GET api/livros/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livro = _context.Livros
                .Include(l => l.Emprestimos)
                .SingleOrDefault(l => l.Id == id);

            var model = LivroViewModel.FromEntity(livro);

            return Ok(model);
        }

        // POST api/livros
        [HttpPost]
        public IActionResult Post(CreateLivroInputModel model)
        {
            var livro = model.ToEntity();
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = livro.Id }, model);
        }

        // DELETE api/livros/1234
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id == id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
