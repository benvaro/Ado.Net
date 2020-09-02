using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
       //     string connection = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

       //     SqlConnection conn = new SqlConnection(connection);
       ////     SqlDataAdapter adapter = new SqlDataAdapter($"Select * from Student", connection);
       //// SelectCommand

       //     //1) -> SelectCommand
       //     SqlDataAdapter adapter = new SqlDataAdapter($"Select * from Student", conn);

       //    // 2) Для ініціалізації команд Insert, Delete, Update
       //     SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

       //     // 3) визначаэмо dataset для локального зберігання даних з БД
       //     DataSet set = new DataSet();

       //     // 4) адаптер підключається до БД і виконує команду Select та зберігає дані у dataset локально
       //     // після чого закриває з'єднання
       //     adapter.Fill(set);

       //     // На етапi дебага виводить у вікно Output
       //     Debug.WriteLine($"Select command: {adapter.SelectCommand.CommandText}");
       //     Debug.WriteLine($"Insert command: {builder.GetInsertCommand().CommandText}");
       //     Debug.WriteLine($"Delete command: {builder.GetDeleteCommand().CommandText}");
       //     Debug.WriteLine($"Update command: {builder.GetUpdateCommand().CommandText}");

       //     PrintDataSet(set);
       //     InsertData(set.Tables[0]);

       //     // 5) настає момент, коли локальний датасет треба синхронізувати з сервером
       //     // тому виконуємо Update(set)
       //     adapter.Update(set);
          
       //     set = new DataSet();
       //     Console.WriteLine();
       //     adapter.Fill(set);
       //     PrintDataSet(set);


            TestRowState();
        }

        private static void TestRowState()
        {
            var table = new DataTable("Test");

            table.Columns.Add("Name", typeof(string));

            var row = table.NewRow();
            Console.WriteLine($"After NewRow() state = {row.RowState}");   // Detached
            table.Rows.Add(row);
            Console.WriteLine($"After Rows.Add() state = {row.RowState}");   // Added
            row["Name"] = "Hello";
            Console.WriteLine($"After assignment value state = {row.RowState}");   // Added
            table.AcceptChanges();
            Console.WriteLine($"After acceptChange value state = {row.RowState}");   // Unchanged
            row["Name"] = "Bye";
            Console.WriteLine($"After second assignment value state = {row.RowState}");   // Modified
            table.Rows[0].Delete();
            Console.WriteLine($"After delete state = {row.RowState}");   // Deleted

        }

        private static void InsertData(DataTable dataTable)
        {
            var row = dataTable.NewRow();

            row[1] = "Ivanka";
            row[2] = "Sorokina";
            row[3] = 1;

            dataTable.Rows.Add(row);
        }

        private static void PrintDataSet(DataSet set)
        {
            foreach (DataTable table in set.Tables)
            {
                Console.WriteLine($"======>{table.TableName}");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        Console.Write("{0, -15}", table.Rows[i][j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
          //varbinary 0..2gb
        }
    }
}
