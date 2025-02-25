using Microsoft.Data.SqlClient;
using System;
using System.Net.Mail;

namespace CrudConsole
{ 
   public class CrudConsole
    {
        private static readonly string connectionString = "Server=Higor;Database=AppCRUD;Integrated Security=True;TrustServerCertificate=True;";


        public static void Main(string[] args)
        {
            string resposta,nome;
            int idade, id;
            Console.WriteLine("Bem-vindo ao CRUD básico, Qual opção deseja? \n 1)Inserir Dados \n 2)Ler dados \n 3)Atualizar dados \n 4)Excluir dados");
            resposta = Console.ReadLine();

            switch (resposta)
            {
                case "1":
                    Console.WriteLine("Me diga seu nome:");
                    nome = Console.ReadLine();
                    Console.WriteLine("Me diga sua idade:");
                    idade = int.Parse(Console.ReadLine());
                    Console.Clear();
                    InserirDados(nome,idade);

                    break;
                case "2":
                    Console.WriteLine("Irei fazer uma leitura geral do banco de dados! ");
                    LerDados();
                    break;
                case "3":
                    Console.WriteLine("Vamos trocar de nome e idade? Digite seu novo nome");
                    nome = Console.ReadLine();
                    Console.WriteLine("Agora sua nova idade");
                    idade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Me diga qual é o ID. Obs: Você pode ver o ID na opção 2");
                    id = int.Parse(Console.ReadLine());

                    AtualizarDados(nome,idade,id);
                    break;
                case "4":
                    Console.WriteLine("Agora vamos deletar seu registro? Qual seu ID?");
                    id = int.Parse(Console.ReadLine());
                    DeletarDados(id);
                    break;
            }

            
        }

        static void DeletarDados(int id)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Pessoas WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
                Thread.Sleep(1000);
            }
        }

        static void AtualizarDados(string nome, int idade, int id)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE Pessoas SET Nome = @Nome, Idade = @Idade WHERE ID = @ID", conn))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@Idade", idade);
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.ExecuteNonQuery();

                }
                conn.Close();
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Aqui está os dados atualizados");
                LerDados();

            }
        }
        static void LerDados()
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Pessoas", conn))
                    {

                        using (SqlDataReader read = cmd.ExecuteReader())
                        {
                            if (read.HasRows) {
                                while (read.Read())
                                {
                                    Console.WriteLine($"ID: {read.GetInt32(0)} Nome: {read.GetString(1)} Idade: {read.GetInt32(2)}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("A Tabela não possui dados. ");
                            }
                            
                        }

                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Ocorreu um error no SQL: " + ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu algum error: " + ex);
                }
            }
        }
        


        
        static void InserirDados(string nome, int idade)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Pessoas(Nome,Idade) VALUES (@Nome, @Idade)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Idade", idade);

                        //só pra mim lembrar do quao importante isso daqui é
                        cmd.ExecuteNonQuery();

                    }
                }catch(SqlException ex)
                {
                    throw new Exception("Ocorreu um error no SQL: " + ex);
                }catch(Exception ex)
                {
                    throw new Exception("Ocorreu algum error: " + ex);
                }

                conn.Close();
                Console.WriteLine("Cadastro realizado com sucesso!!! ");
                Thread.Sleep(1500);
                Console.Clear();
                
            }
        }
    }

}
