using GerenciadorLivro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetDetailsByIdAsync(int id);
        Task<Usuario?> GetByIdAsync(int id);
        Task<int> AddAsync(Usuario usuario);    
    }
}
