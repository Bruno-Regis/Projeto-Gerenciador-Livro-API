using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Application.Models
{
    public class LivroItemViewModel
    {
        public LivroItemViewModel(int id, string titulo, string autor, string iSBN, int anoDePublicacao)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;           
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePublicacao { get; set; }

        public static LivroItemViewModel FromEntity(Livro livro)
            => new LivroItemViewModel(
                livro.Id,
                livro.Titulo,
                livro.Autor,
                livro.ISBN,
                livro.AnoDePublicacao
                );
    } 
}
