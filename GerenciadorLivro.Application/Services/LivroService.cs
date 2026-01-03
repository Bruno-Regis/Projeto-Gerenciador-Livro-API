using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Application.Services
{
    public class LivroService : ILivroService
    {

        private readonly LivrosDbContext _context;
        
        public LivroService(LivrosDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<LivroItemViewModel>> GetAll(string search = "")
        {
            var livros = _context.Livros.ToList();

            var model = livros.Select(l => LivroItemViewModel.FromEntity(l)).ToList();
            return ResultViewModel<List<LivroItemViewModel>>.Success(model);
        }

        public ResultViewModel<LivroViewModel> GetById(int id)
        {
            var livro = _context.Livros
                .Include(l => l.Emprestimos)
                .SingleOrDefault(l => l.Id == id);

            if (livro is null)
                return ResultViewModel<LivroViewModel>.Error("Livro não encontrado");

            var model = LivroViewModel.FromEntity(livro);

            return ResultViewModel<LivroViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateLivroInputModel model)
        {
            var livro = model.ToEntity();
            _context.Livros.Add(livro);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(livro.Id);
        }

        public ResultViewModel Delete(int id)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id == id);
            if (livro is null)
                return ResultViewModel.Error("Livro não encontrado");

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
