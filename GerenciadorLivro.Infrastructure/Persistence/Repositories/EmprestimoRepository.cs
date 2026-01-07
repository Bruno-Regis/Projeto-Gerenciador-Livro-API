using GerenciadorLivro.Core.Entities;
using GerenciadorLivro.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly LivrosDbContext _context;
        public EmprestimoRepository(LivrosDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Emprestimo emprestimo)
        {
            await _context.Emprestimos.AddAsync(emprestimo);
            await _context.SaveChangesAsync();
            return emprestimo.Id;
        }

        public async Task UpdateAsync(Emprestimo emprestimo)
        {
            _context.Emprestimos.Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Emprestimo>> GetAllAsync(string search = "")
        {
            return await _context.Emprestimos.ToListAsync();
        }

        public async Task<Emprestimo?> GetByIdAsync(int id)
        {
            return await _context.Emprestimos.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Emprestimo?> GetDetailsByIdAsync(int id)
        {
            var emprestimo = await _context.Emprestimos
                .Include(e => e.Livro)
                .Include(e => e.Usuario)
                .SingleOrDefaultAsync(e => e.Id == id);
            return emprestimo;
        }
    }
}
