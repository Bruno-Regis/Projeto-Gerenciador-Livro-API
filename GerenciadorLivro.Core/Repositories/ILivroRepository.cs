using GerenciadorLivro.Core.Entities;


namespace GerenciadorLivro.Core.Repositories
{
    public interface ILivroRepository
    {
        // COLOCAR SUFIXO ASYNC NOS MÉTODOS
        Task<List<Livro>> GetAllAsync(string search = "");
        Task<Livro?> GetDetailsByIdAsync(int id);
        Task<Livro?> GetByIdAsync(int id);
        Task<int> AddAsync(Livro livro);
        Task DeleteAsync(Livro livro);
    }
}
