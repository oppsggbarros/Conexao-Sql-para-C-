using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema; // Importa a biblioteca para usar a anotação Table , ou seja para definir o nome da tabela

// Aqui a gente mapeia a tabela do banco de dados
namespace Exemplo1_Entity
{
    [Table("usuario")]// Define explicitamente o nome da tabela
    public class Usuario
    {
        [Column("id")]// Define explicitamente o nome da coluna, ajuda mapear o nome da coluna no banco de dados
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; } = string.Empty; // Valor padrão que evitar o campo ser nulo, só para não dar erro de execução

        [Column("email")]
        public string Email { get; set; } = string.Empty;
    }
}