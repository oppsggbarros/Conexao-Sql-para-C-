using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore; // Importa a biblioteca para usar o DbContext

namespace Exemplo1_Entity
{
    public class Ligacao: DbContext // Aqui hera a classe principal do Entity Framework
    {
        public DbSet<Usuario> Usuarios {get; set;} // Aqui a gente define a tabela que a gente vai usar, o DbSet é uma coleção de objetos que a gente vai usar. A gente tratar como se fosse uma tabela, mas é uma coleção de objetos ou uma lista de objetos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Aqui a gente vai configurar a conexão com o banco de dados
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=connection_1;Username=postgres;Password=2605"); // Aqui a gente passa a string de conexão com o banco de dados
        }

        // Métdo para configura o mapeamento de entindades(tabelas) no banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario"); // Aqui a gente mapeia a tabela usuario
        } // Aqui a gente esta garantindo que a tabela usuario vai ser usada para a tabela usuario no banco de dados
    }
}