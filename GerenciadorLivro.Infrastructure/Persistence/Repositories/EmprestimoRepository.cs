using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        public Task<int> AddAsync(Emprestimo livro)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Emprestimo livro)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Emprestimo>> GetAllAsync(string search = "")
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimo?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimo?> GetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
