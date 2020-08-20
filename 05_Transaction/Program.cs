using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace _05_Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    // good variant
                    //      TestTransaction(connection);
                
                    
                    // 2 варіант, для того щоб штучно показати ролбек тразакції,
                    // бо в нас гарно спроектована БД, і перевірки відбуваються ще на етапі вставки
                    SqlTransaction tran = connection.BeginTransaction();
                    try
                    {
                        TestTransaction(connection, tran, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        tran.Rollback();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void TestTransaction(SqlConnection connection)
        {
            // begin transaction
            SqlTransaction tran = connection.BeginTransaction();
            SqlCommand command1 = new SqlCommand("insert into Student values ('Kolia', 'Androshchuk', 7)", connection);
            SqlCommand command2 = new SqlCommand("insert into Groups values ('newGroup', 1)", connection);

            // вказую, що команди будуть виконуватись в межах однєї транзакції
            command1.Transaction = tran;
            command2.Transaction = tran;

            //
            int res = command1.ExecuteNonQuery();
            int res2 = command2.ExecuteNonQuery();

            if (res < 1 || res2 < 1)
                tran.Rollback();

            tran.Commit();
            //commit
        }

        // штучний варіант, щоб продемонструвати rollback транзакції
        private static void TestTransaction(SqlConnection connection, SqlTransaction tran, bool flag)
        {
            // begin transaction

            string nameGroup = "badTest";

            SqlCommand command1 = new SqlCommand("insert into Student values ('Ivanka', 'Avdeeva', 1)", connection);
            SqlCommand command2 = new SqlCommand($"insert into Groups values ('{nameGroup}', 1)", connection);

            // вказую, що команди будуть виконуватись в межах однєї транзакції
            command1.Transaction = tran;
            command2.Transaction = tran;

            //
            int res = command1.ExecuteNonQuery();
            int res2 = command2.ExecuteNonQuery();

            // Перевіряємо, чи група вже існує в таблиці

            // Для цього читаємо всі назви груп
            SqlCommand read = new SqlCommand("Select Name From Groups", connection);
            // включаємо команду в поточну транзакцію
            read.Transaction = tran;
            using(SqlDataReader reader = read.ExecuteReader())
            {
                var names = new List<string>();
                while(reader.Read())
                {
                    names.Add(reader.GetValue(0).ToString());
                }

                // перевіряємо, чи група існує в таблиці
                if (names.Contains(nameGroup))
                    // якщо існує - генеруємо виключення та робимо ролбек в catch вище
                    throw new Exception("Name of group already exists");
            }


            // якщо зайшло false, то відміняємо транзакцію
            if (!flag)
                throw new Exception("Transaction end in TestTransaction");

            tran.Commit();

            //update balanse - 100
            // internet break  -> rollback
            // update balanse + 100
            // 
            //commit
        }
    }
}
