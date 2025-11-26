namespace GerenciadorLivro.API.Entities
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int idUsuario, Usuario usuario, int idLivro, Livro livro)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
            IdLivro = idLivro;
            Livro = livro;
            DataEmprestimo = DateTime.Today;
            DataDevolucao = DataEmprestimo.AddDays(14); // prazo padrão de 14 dias
        }

        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; private set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }
        public DateTime DataDevolucao { get; private set; }
        
        // preciso emitir alerta de dias de atraso
    }


}
