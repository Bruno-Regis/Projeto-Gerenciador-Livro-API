using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/emprestimos")]
    [ApiController]
    public class EmprestimosController : ControllerBase
    {
        private readonly LivrosDbContext _context;
        public EmprestimosController(LivrosDbContext context)
        {
            _context = context;
        }


        // GET api/emprestimos?search=term
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var emprestimo = _context.Emprestimos.ToList();

            var model = emprestimo.Select(e => EmprestimoItemViewModel.FromEntity(e)).ToList();
            return Ok(model);
        }

        // GET api/emprestimos/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var emprestimo = _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .SingleOrDefault(e => e.Id == id);

            var model = EmprestimoViewModel.FromEntity(emprestimo);

            return Ok(model);
        }


        [HttpPost]
        // POST api/emprestimos
        public IActionResult Post(CreateEmprestimoInputModel model)
        {
            
            var livro = _context.Livros.SingleOrDefault(l => l.Id == model.IdLivro);
            if (livro == null)
                return NotFound("Livro não encontrado.");

            var usuario = _context.Usuarios.Find(model.IdUsuario);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");

            livro.Emprestar();

            var emprestimo = model.ToEntity();
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = emprestimo.Id }, model);
        }

        // POST api/emprestimos/{id}/devolucao
        [HttpPost("{id}/devolucao")]
        public IActionResult RegistrarDevolucao(int id)
        {
            var emprestimo = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            var livro = _context.Livros.SingleOrDefault(l => l.Id == emprestimo.IdLivro);
            if (livro == null)
                return NotFound("Livro não encontrado.");

            livro.Devolver();

            emprestimo.RegistrarDevolucao();
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
