using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Application.Services
{
    public class LivroService : ILivroService
    {

        private readonly ILivroRepository _repository;
        
        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel<List<LivroItemViewModel>>> GetAll(string search = "")
        {
            var livros = await _repository.GetAllAsync(search);

            var model = livros.Select(l => LivroItemViewModel.FromEntity(l)).ToList();
            return ResultViewModel<List<LivroItemViewModel>>.Success(model);
        }
    
        public async Task<ResultViewModel<LivroViewModel>> GetById(int id)
        {
            var livro = await _repository.GetByIdAsync(id);

            if (livro is null)
                return ResultViewModel<LivroViewModel>.Error("Livro não encontrado");

            var model = LivroViewModel.FromEntity(livro);

            return ResultViewModel<LivroViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Insert(CreateLivroInputModel model)
        {
            var livro = model.ToEntity();
            await _repository.AddAsync(livro);

            return ResultViewModel<int>.Success(livro.Id);
        }

        public async Task<ResultViewModel> Delete(int id)
        {
            var livro = await _repository.GetByIdAsync(id);  
            if (livro is null)
                return ResultViewModel.Error("Livro não encontrado");
      
            await _repository.DeleteAsync(livro);

            return ResultViewModel.Success();
        }
    }
}
