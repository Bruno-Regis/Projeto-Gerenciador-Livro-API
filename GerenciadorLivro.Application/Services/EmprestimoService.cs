using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly LivrosDbContext _context;
        public EmprestimoService(LivrosDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<EmprestimoItemViewModel>> GetAll(string search = "")
        {
            var emprestimo = _context.Emprestimos.ToList();

            var model = emprestimo.Select(e => EmprestimoItemViewModel.FromEntity(e)).ToList();

            return ResultViewModel<List<EmprestimoItemViewModel>>.Success(model);
        }

        public ResultViewModel<EmprestimoViewModel> GetById(int id)
        {
            var emprestimo = _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .SingleOrDefault(e => e.Id == id);
            if(emprestimo is null)
                return ResultViewModel<EmprestimoViewModel>.Error("Empréstimo não encontrado.");

            var model = EmprestimoViewModel.FromEntity(emprestimo);

            return ResultViewModel<EmprestimoViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateEmprestimoInputModel model)
        {
            var livro = _context.Livros.SingleOrDefault(l => l.Id == model.IdLivro);
            if (livro is null)
                return ResultViewModel<int>.Error("Livro não encontrado");

            var usuario = _context.Usuarios.Find(model.IdUsuario);
            if (usuario is null)
                return ResultViewModel<int>.Error("Usuário não encontrado.");

            livro.Emprestar();

            var emprestimo = model.ToEntity();
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(emprestimo.Id);
        }

        public ResultViewModel Devolver(int id)
        {
            var emprestimo = _context.Emprestimos.SingleOrDefault(e => e.Id == id);

            if (emprestimo is null)
                return ResultViewModel.Error("Empréstimo não encontrado.");


            var livro = _context.Livros.SingleOrDefault(l => l.Id == emprestimo.IdLivro);
            if (livro is null)
                return ResultViewModel.Error("Empréstimo não encontrado.");

            livro.Devolver();

            emprestimo.RegistrarDevolucao();
            _context.Emprestimos.Update(emprestimo);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
