
namespace Fornecedores_Model.Features
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        //public Supplier() { }

        public Supplier(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public override string Validate()
        {
            var result = "";
            if (string.IsNullOrWhiteSpace(Name))
            {
                result += "* Attribute Name cannot be null or white space.\n";
            }
            if (string.IsNullOrEmpty(Email))        //todo: real email validation
            {
                result += "* Attribute Email cannot be null or white space.\n";
            }
            if (result == "")
                result = "VALID";
            return result;
        }


        public override bool Equals(object? obj)
        {
            return obj is Supplier supplier &&
                   Id == supplier.Id &&
                   Name == supplier.Name &&
                   Email == supplier.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Email);
        }

    }
}
