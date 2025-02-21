
using Fornecedores_Model.Features;
using Fornecedores_ORM.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fornecedores_ORM
{
    public class FornecedorDBContext : DbContext
    {
        public string DbPath { get; }

        public FornecedorDBContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "FornecedoresDatabase.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorConfiguration());

            //Popula inicialmente o banco, somente 1 vez. Facilita nos meus testes e do avaliador
            modelBuilder.Entity<Fornecedor>().HasData(
                new Fornecedor(1, "Joao Silva", "joao.silva@email.com"),
                new Fornecedor(2, "Maria Oliveira", "maria.oliveira@email.com"),
                new Fornecedor(3, "Carlos Santos", "carlos.santos@email.com"),
                new Fornecedor(4, "Ana Souza", "ana.souza@email.com")
            );
        }
    }
}

