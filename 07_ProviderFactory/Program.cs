using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ProviderFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string provider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            // 1. 
            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                Console.WriteLine($"Connection: {connection.GetType().Name}");

                DbCommand command = factory.CreateCommand();
                command.CommandText = "Select * from Groups";
                command.Connection = connection;

                Console.WriteLine($"Command: {command.GetType().Name}");
                using (DbDataReader reader = command.ExecuteReader())
                {
                Console.WriteLine($"Reader: {reader.GetType().Name}");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write("{0, 25}", reader[i]);
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
