
namespace Fornecedores_Model.Features
{
    internal class Supplier : BaseEntity
    {
        public string Name;
        public string Email;

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
                   id == supplier.id &&
                   Id == supplier.Id &&
                   Name == supplier.Name &&
                   Email == supplier.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(id, Id, Name, Email);
        }
    }
}
