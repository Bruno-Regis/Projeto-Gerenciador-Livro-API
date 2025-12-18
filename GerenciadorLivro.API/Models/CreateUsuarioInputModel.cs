using GerenciadorLivro.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace GerenciadorLivro.API.Models
{
    public class CreateUsuarioInputModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Usuario ToEntity()
            => new Usuario(Nome, Email);

    }
}
