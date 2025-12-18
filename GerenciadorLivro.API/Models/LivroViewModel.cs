using GerenciadorLivro.API.Entities;

namespace GerenciadorLivro.API.Models
{
    public class LivroViewModel
    {
        public LivroViewModel(int id, string titulo, string autor, string iSBN, int anoDePublicacao, string status,
            DateTime? dataEmprestimo, DateTime? dataDevolucao, int diasDeAtraso, bool estaAtrasado)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoDePublicacao = anoDePublicacao;
            Status = status;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            DiasDeAtraso = diasDeAtraso;
            EstaAtrasado = estaAtrasado;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoDePublicacao { get; set; }
        public string Status { get; set; }
        public DateTime? DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int DiasDeAtraso { get; set; }
        public bool EstaAtrasado { get; set; }
        

        public static LivroViewModel FromEntity(Livro livro)
        {
            var emprestimoAtivo = livro.Emprestimos
                .Where(e => e.EstaAtivo)
                .OrderByDescending(e => e.DataEmprestimo)
                .FirstOrDefault();

            var dataEmprestimo = emprestimoAtivo?.DataEmprestimo;
            var dataDevolucao = emprestimoAtivo?.DataDevolucao;
            var diasDeAtraso = emprestimoAtivo?.DiasDeAtraso ?? 0;
            var estaAtrasado = emprestimoAtivo?.EstaAtrasado ?? false;


            return new LivroViewModel(
                livro.Id,
                livro.Titulo,
                livro.Autor,
                livro.ISBN,
                livro.AnoDePublicacao,
                livro.Status.ToString(),
                dataEmprestimo,
                dataDevolucao,
                diasDeAtraso,
                estaAtrasado
                );
        } 
    }
}
