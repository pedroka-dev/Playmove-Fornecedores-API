
namespace Fornecedores_Model.Features
{
    [System.Serializable]
    public class Fornecedor : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Fornecedor() {}

        public Fornecedor(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Fornecedor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public override string Validate()
        {
            var result = "";
            if (string.IsNullOrWhiteSpace(Nome))
            {
                result += "Atributo Nome não pode ser nulo ou espaço em branco.\n";
            }
            if (string.IsNullOrEmpty(Email))        //todo: real email validation
            {
                result += "Atributo Email não pode ser nulo ou espaço em branco.\n";
            }
            if (result == "")
                result = "VALID";
            return result;
        }


        public override bool Equals(object? obj)
        {
            return obj is Fornecedor fornecedor &&
                   Id == fornecedor.Id &&
                   Nome == fornecedor.Nome &&
                   Email == fornecedor.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Email);
        }

    }
}
