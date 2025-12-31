using GerenciadorLivro.Core.Entities;

namespace GerenciadorLivro.Application.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string email,List<EmprestimoViewModel> emprestimos)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Emprestimos = emprestimos;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<EmprestimoViewModel> Emprestimos { get; set; }


        public static UsuarioViewModel FromEntity(Usuario usuario)
        {
            return new UsuarioViewModel(
                usuario.Id,
                usuario.Nome,
                usuario.Email,
                usuario.Emprestimos?
                    .Select(e => EmprestimoViewModel.FromEntity(e))
                    .ToList() ?? new List<EmprestimoViewModel>()
            );
        }
    }
}
