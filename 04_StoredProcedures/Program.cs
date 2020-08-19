using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _04_StoredProcedures
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
                    // 1. Створюємо команду, вказуємо назву процедури та з'єдання, в якому будемо її виконувати
                    SqlCommand command = new SqlCommand("sp_countStudOutput", connection);
                    // 2. вказуэмо, що наша команда - це збережена процедура
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    // 3. Створюэмо параметри
                    // вхідний параметр - назва групи
                    command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar, 10).Value = "Pr123";
                    // створюємо вихідний параметр
                    #region outputParameter = new SqlParameter().... 
                    //SqlParameter outputParameter = new SqlParameter
                    //{
                    //    ParameterName = "@countStud",
                    //    SqlDbType = System.Data.SqlDbType.Int,
                    //    // змінюємо напрям параметра - вказуємо, що це ВИХІДНИЙ параметр
                    //    Direction = System.Data.ParameterDirection.Output
                    //    // Value для вихідних параметрів НЕ ЗАДАЄТЬСЯ
                    //}; 
                    // Додаємо параметр в колекцію параметрів команди
                    // command.Parameters.Add(outputParameter);
                    #endregion
                    // Скорочений варіант створення вихідного параметра (анонімно) - без виділення пам'яті раніше
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@countStud",
                        SqlDbType = System.Data.SqlDbType.Int,
                        // змінюємо напрям параметра - вказуємо, що це ВИХІДНИЙ параметр
                        Direction = System.Data.ParameterDirection.Output
                    });

                    command.ExecuteNonQuery();
                    // Console.WriteLine($"Result: {outputParameter.Value}");
                    Console.WriteLine($"Result: {command.Parameters["@countStud"].Value.ToString()}");
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
