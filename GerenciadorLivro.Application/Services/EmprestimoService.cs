using GerenciadorLivro.Application.Models;
using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Infrastructure.Persistence;
using GerenciadorLivro.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.Application.Services
{
    public class EmprestimoService : IEmprestimoService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public EmprestimoService(IEmprestimoRepository emprestimoRepository, ILivroRepository livroRepository, IUsuarioRepository usuarioRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _livroRepository = livroRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ResultViewModel<List<EmprestimoItemViewModel>>> GetAll(string search = "")
        {
            var emprestimo = await _emprestimoRepository.GetAllAsync(search);

            var model = emprestimo.Select(e => EmprestimoItemViewModel.FromEntity(e)).ToList();

            return ResultViewModel<List<EmprestimoItemViewModel>>.Success(model);
        }

        public async Task<ResultViewModel<EmprestimoViewModel>> GetById(int id)
        {
            var emprestimo = await _emprestimoRepository.GetDetailsByIdAsync(id);
            if(emprestimo is null)
                return ResultViewModel<EmprestimoViewModel>.Error("Empréstimo não encontrado.");

            var model = EmprestimoViewModel.FromEntity(emprestimo);

            return ResultViewModel<EmprestimoViewModel>.Success(model);
        }

        public async Task<ResultViewModel<int>> Insert(CreateEmprestimoInputModel model)
        {
            var livro = await _livroRepository.GetByIdAsync(model.IdLivro);
            if (livro is null)
                return ResultViewModel<int>.Error("Livro não encontrado");

            var usuario = await _usuarioRepository.GetByIdAsync(model.IdUsuario);
            if (usuario is null)
                return ResultViewModel<int>.Error("Usuário não encontrado.");

            livro.Emprestar();

            var emprestimo = model.ToEntity();

            await _emprestimoRepository.AddAsync(emprestimo);  

            return ResultViewModel<int>.Success(emprestimo.Id);
        }

        public async Task<ResultViewModel> Devolver(int id)
        {
            var emprestimo = await _emprestimoRepository.GetByIdAsync(id);

            if (emprestimo is null)
                return ResultViewModel.Error("Empréstimo não encontrado.");


            var livro = await _livroRepository.GetByIdAsync(emprestimo.IdLivro);
            if (livro is null)
                return ResultViewModel.Error("Empréstimo não encontrado.");

            livro.Devolver();

            emprestimo.RegistrarDevolucao();

            await _emprestimoRepository.UpdateAsync(emprestimo);

            return ResultViewModel.Success();
        }
    }
}
