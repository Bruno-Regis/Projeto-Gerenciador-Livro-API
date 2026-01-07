using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<UsuarioItemViewModel>>> GetAll(string search = "")
        {
            var usuarios = await _repository.GetAllAsync();

            var model = usuarios.Select(u => UsuarioItemViewModel.FromEntity(u)).ToList();
            return ResultViewModel<List<UsuarioItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<UsuarioViewModel>> GetById(int id)
        {
            var usuario = await _repository.GetDetailsByIdAsync(id);

            if (usuario is null)
                return ResultViewModel<UsuarioViewModel>.Error("Usuário não encontrado");

            var model = UsuarioViewModel.FromEntity(usuario);
            return ResultViewModel<UsuarioViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Insert(CreateUsuarioInputModel model)
        {
            var usuario = model.ToEntity();
            await _repository.AddAsync(usuario);

            return ResultViewModel<int>.Success(usuario.Id);
        }
    }
}
