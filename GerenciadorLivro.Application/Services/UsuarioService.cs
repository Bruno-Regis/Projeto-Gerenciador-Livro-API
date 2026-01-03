using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly LivrosDbContext _context;

        public UsuarioService(LivrosDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<UsuarioItemViewModel>> GetAll(string search = "")
        {
            var usuarios = _context.Usuarios.ToList();

            var model = usuarios.Select(u => UsuarioItemViewModel.FromEntity(u)).ToList();
            return ResultViewModel<List<UsuarioItemViewModel>>.Success(model);
        }

        public ResultViewModel<UsuarioViewModel> GetById(int id)
        {
            var usuario = _context.Usuarios
                .Include(u => u.Emprestimos)
                    .ThenInclude(e => e.Livro)
                .FirstOrDefault(u => u.Id == id);

            if (usuario is null)
                return ResultViewModel<UsuarioViewModel>.Error("Usuário não encontrado");

            var model = UsuarioViewModel.FromEntity(usuario);
            return ResultViewModel<UsuarioViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateUsuarioInputModel model)
        {
            var usuario = model.ToEntity();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            
            return ResultViewModel<int>.Success(usuario.Id);
        }
    }
}
