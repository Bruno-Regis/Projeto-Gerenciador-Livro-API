using GerenciadorLivro.API.Enums;

namespace GerenciadorLivro.API.Entities
{
    public class Livro : BaseEntity
    {
        private Livro()
        {
            Emprestimos = new List<Emprestimo>();
        }
        public Livro(string titulo, string autor, string isbn, int anoDePublicacao)
            :base()
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = isbn;
            AnoDePublicacao = anoDePublicacao;
            Emprestimos = new List<Emprestimo>() { };
            Status = StatusEmprestimoEnum.Disponivel;
        }

        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoDePublicacao { get; private set; }
        public List<Emprestimo> Emprestimos { get; private set; }

        public StatusEmprestimoEnum Status { get; private set; }

        public void Emprestar()
        {
            if (Status == StatusEmprestimoEnum.Emprestado)
                throw new InvalidOperationException("Livro já está emprestado.");
            Status = StatusEmprestimoEnum.Emprestado;
        }

        public void Devolver()
        {
            if (Status == StatusEmprestimoEnum.Disponivel)
                throw new InvalidOperationException("Livro já está disponível.");
            Status = StatusEmprestimoEnum.Disponivel;
        }
    }
}
