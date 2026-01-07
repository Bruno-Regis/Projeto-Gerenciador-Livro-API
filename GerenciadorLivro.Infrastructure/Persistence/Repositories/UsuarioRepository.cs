using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LivrosDbContext _context;

        public UsuarioRepository(LivrosDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Usuario usuario)
        {
           
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> GetDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
