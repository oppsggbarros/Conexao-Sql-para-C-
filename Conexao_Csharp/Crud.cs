using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using System.Diagnostics;

namespace Conexao_Csharp
{
    public class Crud
    {
        string conexao = "Host=localhost; Username=postgres;Password=2605;Database=connection_1;";
        void InserirUsuario(int id, string nome, string email)
        {
            string query = $"Insert into public.usuario (id, nome, email) values ('{id}', '{nome}', '{email}')";
            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.Parameters.AddWithValue("email", email);
                    cmd.ExecuteNonQuery();
                }

            }
        }
        void LerUsuario()
        {
            string query = "Select * from public.usuario";
            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["id"] + " " + reader["nome"] + " " + reader ["email"]);
                        }
                    }
                }
            }
        }
        void AtualizarUsuario(int id, string nome)
        {
            string query = $"Update public.usuario set nome = '{nome}' where id = '{id}'";
            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("nome", nome);
                    cmd.ExecuteNonQuery();

                }
            }
        }
        void deleteUsuario(int id)
        {
            string query = $"Delete from public.usuario where id = '{id}'";
            using (NpgsqlConnection con = new NpgsqlConnection(conexao))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        static void Main(string[] args)
        {
            Crud crud = new Crud();
            Stopwatch sw = new Stopwatch();
            TimeSpan tempoTotal;
            sw.Start();
            crud.AtualizarUsuario(1, "Joãojiobbbkkjiojoi");
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoAtualizacao = sw.Elapsed;
            
            crud.LerUsuario();
            System.Console.WriteLine();
            sw.Restart();
            crud.deleteUsuario (2);
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoDelete = sw.Elapsed;
            crud.LerUsuario();
            System.Console.WriteLine();
            sw.Reset();
            crud.InserirUsuario(2, "João", "joao@gmail.com");
            sw.Stop();
            System.Console.WriteLine($"Tempo de execução: {sw.ElapsedMilliseconds}ms");
            TimeSpan tempoInsercao = sw.Elapsed;
            crud.LerUsuario();

            tempoTotal = tempoInsercao + tempoAtualizacao + tempoDelete;
            System.Console.WriteLine($"Tempo total de execução: {tempoTotal}ms");


        }
    }
}