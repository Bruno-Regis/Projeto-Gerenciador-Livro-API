using GerenciadorLivro.API.Entities;

namespace GerenciadorLivro.API.Models
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel(int id, int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime dataDevolucao,
                DateTime? dataDevolucaoReal, bool estaAtivo, bool estaAtrasado, int diasDeAtraso,
                string nomeDoLivro, string nomeDoUsuario, string emailDoUsuario, int anoDoLivro, string iSBNDoLivro, string mensagemStatus)
        {
            Id = id;
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            DataDevolucaoReal = dataDevolucaoReal;
            EstaAtivo = estaAtivo;
            EstaAtrasado = estaAtrasado;
            DiasDeAtraso = diasDeAtraso;
            NomeDoLivro = nomeDoLivro;
            NomeDoUsuario = nomeDoUsuario;
            EmailDoUsuario = emailDoUsuario;
            AnoDoLivro = anoDoLivro;
            ISBNDoLivro = iSBNDoLivro;
            MensagemStatus = mensagemStatus;
        }

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime? DataDevolucaoReal { get; set; }
        public bool EstaAtivo { get; set; }
        public bool EstaAtrasado { get; set; }
        public int DiasDeAtraso { get; set; }
        public string NomeDoLivro { get; set; }
        public string NomeDoUsuario { get; set; }
        public string EmailDoUsuario { get; set; }
        public int AnoDoLivro { get; set; }
        public string ISBNDoLivro { get; set; }
        public string MensagemStatus { get; set; }

        public static EmprestimoViewModel FromEntity(Emprestimo emprestimo)
        {


            return new EmprestimoViewModel(
                emprestimo.Id,
                emprestimo.IdUsuario,
                emprestimo.IdLivro,
                emprestimo.DataEmprestimo,
                emprestimo.DataDevolucao,
                emprestimo.DataDevolucaoReal,
                emprestimo.EstaAtivo,
                emprestimo.EstaAtrasado,
                emprestimo.DiasDeAtraso,
                emprestimo.Livro.Titulo,
                emprestimo.Usuario.Nome,
                emprestimo.Usuario.Email,
                emprestimo.Livro.AnoDePublicacao,
                emprestimo.Livro.ISBN,
                emprestimo.ObterMensagemStatus()
                );
        }
    }
}
