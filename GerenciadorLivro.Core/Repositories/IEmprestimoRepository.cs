using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> GetAllAsync(string search = "");
        Task<Emprestimo?> GetDetailsByIdAsync(int id);
        Task<Emprestimo?> GetByIdAsync(int id);
        Task<bool> Exists(int id);
        Task<int> AddAsync(Emprestimo emprestimo);
        Task UpdateAsync(Emprestimo emprestimo);
    }
}
