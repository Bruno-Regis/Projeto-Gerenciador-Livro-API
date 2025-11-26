namespace GerenciadorLivro.API.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }

        public void AtualizarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email não pode ser vazio.", nameof(email));
            if (!email.Contains("@"))
                throw new ArgumentException("Email inválido.", nameof(email));
            if(email == Email)
                throw new ArgumentException("O email precisa ser diferente do cadastrado.", nameof(email));
            Email = email;
        }

    }
}
