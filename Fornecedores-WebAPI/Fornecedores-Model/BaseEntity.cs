namespace Fornecedores_Model
{
    public abstract class BaseEntity
    {
        protected int id;

        public int Id { get => id; set => id = value; }
        public abstract string Validate();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
    }
}
