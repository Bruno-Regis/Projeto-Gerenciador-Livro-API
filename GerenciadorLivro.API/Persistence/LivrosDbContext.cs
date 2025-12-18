using GerenciadorLivro.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorLivro.API.Persistence
{
    public class LivrosDbContext : DbContext
    {

        public LivrosDbContext(DbContextOptions<LivrosDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Livro>(e =>
                {
                    e.HasKey(l => l.Id);

                    e.HasMany(l => l.Emprestimos)
                        .WithOne(emp => emp.Livro)
                        .OnDelete(DeleteBehavior.Cascade);
                });


            builder
                .Entity<Usuario>(e =>
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.Emprestimos)
                        .WithOne(emp => emp.Usuario)
                        .HasForeignKey(emp => emp.IdUsuario)
                        .OnDelete(DeleteBehavior.Cascade);
                });


            builder
                .Entity<Emprestimo>(e =>
                {                     
                    e.HasKey(emp => emp.Id);

                    e.HasOne(emp => emp.Usuario)
                        .WithMany(u => u.Emprestimos)
                        .HasForeignKey(emp => emp.IdUsuario)
                        .OnDelete(DeleteBehavior.Cascade);

                    e.HasOne(emp => emp.Livro)
                        .WithMany(l => l.Emprestimos)
                        .HasForeignKey(emp => emp.IdLivro)
                        .OnDelete(DeleteBehavior.Cascade);
                });

        }

    }
}

