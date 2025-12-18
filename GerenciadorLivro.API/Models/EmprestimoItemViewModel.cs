using GerenciadorLivro.API.Entities;

namespace GerenciadorLivro.API.Models
{
    public class EmprestimoItemViewModel
    {
        public EmprestimoItemViewModel(int id, int idUsuario, int idLivro, DateTime dataEmprestimo, DateTime dataDevolucao, 
            DateTime? dataDevolucaoReal, bool estaAtivo, bool estaAtrasado, int diasDeAtraso)
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

        public static EmprestimoItemViewModel FromEntity(Emprestimo emprestimo)
        {

            return new EmprestimoItemViewModel(
                emprestimo.Id,
                emprestimo.IdUsuario,
                emprestimo.IdLivro,
                emprestimo.DataEmprestimo,
                emprestimo.DataDevolucao,
                emprestimo.DataDevolucaoReal,
                emprestimo.EstaAtivo,
                emprestimo.EstaAtrasado,
                emprestimo.DiasDeAtraso
                );
        }

    }
}
