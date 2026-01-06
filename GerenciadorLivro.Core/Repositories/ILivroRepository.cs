using GerenciadorLivro.Core.Entities;


namespace GerenciadorLivro.Core.Repositories
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAll(string search = "");
        Task<Livro?> GetDetailsById(int id);
        Task<Livro?> GetById(int id);
        Task<bool> Exists(int id);
        Task<int> Add(Livro livro);
        Task Delete(Livro livro);
    }
}
