using GerenciadorLivro.API.Entities;

namespace GerenciadorLivro.API.Models
{
    public class CreateLivroInputModel
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePublicacao { get; set; }

        public Livro ToEntity()
            => new Livro(Titulo, Autor, ISBN, AnoDePublicacao);
    }
}
