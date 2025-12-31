using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Application.Models
{
    public class CreateEmprestimoInputModel
    {
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public int PrazoDevolucao { get; set; }

        public Emprestimo ToEntity()
        {
            return new Emprestimo(IdUsuario, IdLivro, PrazoDevolucao);
        }
    }
}
