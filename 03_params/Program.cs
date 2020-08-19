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
            groupParameter.SqlDbType = System.Data.SqlDbType.NVarChar; // N -unicode  varchar(10) char(10)
            groupParameter.Size = 20;
            groupParameter.Value = nameGroup;
            #endregion

            // Test
         //   string pattern = "%[Ii]van%";
            // 1. Створюємо новий параметр @p2 із значенням Іван
        //    SqlParameter nameParameter = new SqlParameter("@p2", pattern);
            //SqlParameter nameParameter = new SqlParameter("@p2", System.Data.SqlDbType.NVarChar, 20);
            //nameParameter.Value = pattern;

            // 3. В тексті команд підставляємо імена параметрів в ті місця, де мають бути дані введені користувачем
            SqlCommand command = new SqlCommand($"select Student.Name, Surname, IdGroup from Student join Groups " +
                $"On Student.IdGroup = Groups.Id Where Groups.Name = @p1 and Student.Surname Like @p2;select * from Groups", connection);
        
            command.Parameters.Add(groupParameter);
            // 2. Додаємо параметр в колекцію параметрів нашої команди
            //  command.Parameters.Add(nameParameter);
            // варіант 2
            // command.Parameters.Add(new SqlParameter("@p2", "%[Ii]van%"));
            // варіант 3 - найкоротший
            command.Parameters.AddWithValue("@p2", "%[Ii]van%");

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
