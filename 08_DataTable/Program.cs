using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // DbDataAdapter
            // DataSet
            DataTable table = new DataTable(); // empty

            table.Columns.Add("id"); 
            table.Columns.Add("FirstName"); 
            table.Columns.Add("Surname");

            DataRow row = table.NewRow();

            row[0] = 1;
            row[1] = "Alex";
            row[2] = "Tymeichuk";

            table.Rows.Add(row);

            row = table.NewRow();
            row[0] = 2;
            row[1] = "Ivanka";
            row[2] = "Sorokina";

            table.Rows.Add(row);
            // DataColumn
            // DataRow

            PrintTable(table);
        }

        private static void PrintTable(DataTable table)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    Console.Write("{0, -15}", table.Rows[i][j]);
                }
                Console.WriteLine();
            }            
        }
    }
}
