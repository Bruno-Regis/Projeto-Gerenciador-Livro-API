using System;
using System.Collections.Generic;
using System.Text;
using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Core.Repositories;
using Microsoft.EntityFrameworkCore;
namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivrosDbContext _context;

        public LivroRepository(LivrosDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();

            return livro.Id;
        }

        public async Task<List<Livro>> GetAllAsync(string search = "")
        {   
            return await _context.Livros.ToListAsync();  
        }

        public async Task<Livro?> GetByIdAsync(int id)
        {
            return await _context.Livros
                .SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro?> GetDetailsByIdAsync(int id)
        {
            var livro = await _context.Livros
                .Include(l => l.Emprestimos)
                    .ThenInclude(u => u.Usuario)
                .SingleOrDefaultAsync(l => l.Id == id);
            return livro;
        }

        public async Task DeleteAsync(Livro livro)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }
    }
}
