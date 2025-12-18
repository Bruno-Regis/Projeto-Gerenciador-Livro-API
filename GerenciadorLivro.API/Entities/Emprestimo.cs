namespace GerenciadorLivro.API.Entities
{
    public class Emprestimo : BaseEntity
    {
        private Emprestimo() { }

        public Emprestimo(int idUsuario , int idLivro, int? diasParaDevolver = null) 
            : base()
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = DateTime.Today;

            var prazo = diasParaDevolver ?? 14; // prazo padrão de 14 dias
            DataDevolucao = DataEmprestimo.AddDays(prazo); 
        }

        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        public DateTime? DataDevolucaoReal { get; private set; }
        public bool EstaAtivo => DataDevolucaoReal == null;
        public bool EstaAtrasado => EstaAtivo && DateTime.Today > DataDevolucao;
        public int DiasDeAtraso => EstaAtrasado ? (DateTime.Today - DataDevolucao).Days : 0;

        public string ObterMensagemStatus()
        {
            if(EstaAtivo)
                return "Empréstimo ativo.";
            if(EstaAtrasado)
                return $"Empréstimo atrasado por {DiasDeAtraso} dias.";
            
            var diasRestantes = (DataDevolucao - DateTime.Today).Days;

            if (diasRestantes == 0)
                return "Devolução prevista para hoje!";

            if (!EstaAtivo)
                return "Emprestimo finalizado";

            return $"Empréstimo em dia. Faltam {diasRestantes} dia(s) para devolução.";
        }

        public void RegistrarDevolucao()
        {
            if (DataDevolucaoReal != null)
                throw new InvalidOperationException("Devolução já registrada.");

            DataDevolucaoReal = DateTime.Today;
        }

    }

}
