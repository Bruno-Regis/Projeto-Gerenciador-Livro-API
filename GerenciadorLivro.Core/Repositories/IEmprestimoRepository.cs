using GerenciadorLivro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> GetAllAsync(string search = "");
        Task<Emprestimo?> GetDetailsByIdAsync(int id);
        Task<Emprestimo?> GetByIdAsync(int id);
        Task<bool> Exists(int id);
        Task<int> AddAsync(Emprestimo livro);
        Task DeleteAsync(Emprestimo livro);
    }
}
