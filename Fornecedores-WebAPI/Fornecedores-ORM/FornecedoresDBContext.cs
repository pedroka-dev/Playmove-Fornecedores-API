
using Fornecedores_ORM.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores_ORM
{
    public class FornecedoresDBContext : DbContext
    {
        public string DbPath { get; }

        public FornecedoresDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "fornecedores.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
        }
    }
}
