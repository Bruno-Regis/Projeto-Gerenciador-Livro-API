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

        public async Task<ResultViewModel<List<UsuarioItemViewModel>>> GetAll(string search = "")
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            var model = usuarios.Select(u => UsuarioItemViewModel.FromEntity(u)).ToList();
            return ResultViewModel<List<UsuarioItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<UsuarioViewModel>> GetById(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Emprestimos)
                    .ThenInclude(e => e.Livro)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (usuario is null)
                return ResultViewModel<UsuarioViewModel>.Error("Usuário não encontrado");

            var model = UsuarioViewModel.FromEntity(usuario);
            return ResultViewModel<UsuarioViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Insert(CreateUsuarioInputModel model)
        {
            var usuario = model.ToEntity();
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return ResultViewModel<int>.Success(usuario.Id);
        }
    }
}
