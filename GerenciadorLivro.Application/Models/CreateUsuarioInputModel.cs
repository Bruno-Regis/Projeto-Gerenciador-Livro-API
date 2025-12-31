using GerenciadorLivro.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GerenciadorLivro.Application.Models
{
    public class CreateUsuarioInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Usuario ToEntity()
            => new Usuario(Nome, Email);

    }
}
