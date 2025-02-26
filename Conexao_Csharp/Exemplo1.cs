// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Npgsql;
// namespace Conexao_Csharp
// {
//     public class Exemplo1
//     {
//         static void Main(string[] args)
//         {
//             string conexao = "Host=localhost;Database=Computador(procedure);Username=postgres;Password=2605";

//             string insertQuery = "Insert into maquina  (id_maquina, tipo) values (10, 'Desktop')";

//             string deleteQuery = "Delete from maquina where id_maquina = 10";

//             string updateQuery = "Update maquina set tipo = 'Laptop' where id_maquina = 10";


//             using (NpgsqlConnection con = new NpgsqlConnection(conexao))
//             {
//                 try
//                 {
//                     con.Open();
//                     System.Console.WriteLine("Conexão aberta Postgres");
//                     string query = "Select * from maquina";

//                     using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, con))
//                     {
//                         int row = cmd.ExecuteNonQuery();
//                         System.Console.WriteLine("Linhas afetadas: " + row);
//                     }


//                     using (NpgsqlCommand cmd = new NpgsqlCommand(deleteQuery, con))
//                     {
//                         int row = cmd.ExecuteNonQuery();
//                         System.Console.WriteLine("Linhas afetadas: " + row);
//                     }
//                     using (NpgsqlCommand cmd = new NpgsqlCommand(updateQuery, con))
//                     {
//                         int row = cmd.ExecuteNonQuery();
//                         System.Console.WriteLine("Linhas afetadas: " + row);
//                     }
//                     using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
//                     {
//                         using (NpgsqlDataReader dr = cmd.ExecuteReader())
//                         {
//                             System.Console.WriteLine("Tabelas do banco de dados: ");
//                             while (dr.Read())
//                             {
//                                 System.Console.WriteLine($"Id: {dr.GetInt32(0)} Tipo: {dr.GetString(1)}");
//                             }
//                         }
//                     }
//                 }
//                 catch (NpgsqlException ex)
//                 {
//                     System.Console.WriteLine("Erro: " + ex.Message);
//                 }

//             }
//         }
//     }
// }