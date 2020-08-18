using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_params
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine(connection.ConnectionString);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter name of group");
                string nameGroup = Console.ReadLine();

                SearchStudentsInGroup(nameGroup, connection);
            }

            #region using SqlConnectionStringBuilder
            //     SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //builder.DataSource = tb_ip.Text;
            //builder.UserID = tb_login.Text;

            //       SqlConnection connection = new SqlConnection(builder.ConnectionString); 
            #endregion
            //D - dont
            //R - repeat
            //Y - yourself

         
        }

        private static void SearchStudentsInGroup(string nameGroup, SqlConnection connection)
        {
            #region using parameters in command
            SqlParameter groupParameter = new SqlParameter();
            groupParameter.ParameterName = "@p1";
            groupParameter.SqlDbType = System.Data.SqlDbType.NVarChar;
            groupParameter.Size = 20;
            groupParameter.Value = nameGroup;
            #endregion

            SqlCommand command = new SqlCommand($"select Student.Name, Surname, IdGroup from Student join Groups " +
                $"On Student.IdGroup = Groups.Id Where Groups.Name = @p1;select * from Groups", connection);
        
            command.Parameters.Add(groupParameter);

            SqlDataReader reader = command.ExecuteReader();
            int line = 0;
            if (reader.HasRows)
            {
                do
                {
                    line = 0;
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"[{reader.GetName(i)}]\t\t");
                            }
                        }
                        Console.WriteLine(Environment.NewLine);
                        Console.ForegroundColor = ConsoleColor.White;
                        line++;
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"[{reader.GetValue(i)}]\t\t");
                        }

                    }
                    Console.WriteLine();
                } while (reader.NextResult());
            }
        }
    }
}
