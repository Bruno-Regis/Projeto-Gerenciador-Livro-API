namespace GerenciadorLivro.API.Entities
{
    public class Livro : BaseEntity
    {
        public Livro(string titulo, string autor, string isbn, int anoDePublicacao)
            :base()
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoDePublicacao = anoDePublicacao;
            Emprestimos = new List<Emprestimo>() { };
        }

        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }
    }
}
