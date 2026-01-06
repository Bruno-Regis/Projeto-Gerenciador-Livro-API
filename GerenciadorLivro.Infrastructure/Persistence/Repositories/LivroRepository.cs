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

        public async Task<int> Add(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();

            return livro.Id;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Livros.AnyAsync(l => l.Id == id);
        }

        public async Task<List<Livro>> GetAll(string search = "")
        {
            var livros = await _context.Livros.ToListAsync();

            return livros;  
        }

        public async Task<Livro?> GetById(int id)
        {
            return await _context.Livros
                .SingleOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Livro?> GetDetailsById(int id)
        {
            var livro = await _context.Livros
                .Include(l => l.Emprestimos)
                .SingleOrDefaultAsync(l => l.Id == id);
            return livro;
        }

        public async Task Delete(Livro livro)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }
    }
}
