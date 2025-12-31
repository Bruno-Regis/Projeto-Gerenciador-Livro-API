using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly LivrosDbContext _context;
        public UsuariosController(LivrosDbContext context)
        {
            _context = context;
        }

        // GET api/usuarios?search=term
        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var usuarios = _context.Usuarios.ToList();

            var model = usuarios.Select(u => UsuarioItemViewModel.FromEntity(u)).ToList();
            return Ok(model);
        }


        // GET api/usuarios/1234
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Emprestimos)
                    .ThenInclude(e => e.Livro)
                .FirstOrDefault(u => u.Id == id);

            var model = UsuarioViewModel.FromEntity(usuario);

            return Ok(model);
        }

        // POST api/usuarios
        [HttpPost]  
        public IActionResult Post(CreateUsuarioInputModel model)
        {
            var usuario = model.ToEntity();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, model);
        }

    }
}
