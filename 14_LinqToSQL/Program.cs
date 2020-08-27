using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_LinqToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            DataClassesDataContext context = new DataClassesDataContext(connectionString);

            Read(context);
            Console.ReadLine();
            //Create(context);
            //Console.WriteLine();
            //Read(context);

            //Console.ReadLine();
            //Delete(context);
            //Read(context);
            //Update(context);

            foreach (var item in context.Groups)
            {
                Console.WriteLine(item.Name);
                foreach (var st in item.Students)
                {
                    Console.WriteLine(st.Name + " " + st.Surname);
                }
                Console.WriteLine();
            }
        }

        private static void Update(DataClassesDataContext context)
        {
            string name="";
            name = Console.ReadLine();

            var student = context.Students.FirstOrDefault(x => x.Name == name);
            student.Name= Console.ReadLine();
            context.SubmitChanges();

        }

        private static void Delete(DataClassesDataContext context)
        {
            context.Students.DeleteOnSubmit(context.Students.FirstOrDefault());
            context.SubmitChanges();
        }

        private static void Create(DataClassesDataContext context)
        {
            Student st = new Student()
            {
                Name = Console.ReadLine(),
                Surname = Console.ReadLine(),
                IdGroup = Convert.ToInt32(Console.ReadLine())
            };

            context.Students.InsertOnSubmit(st);
           
            context.SubmitChanges();
        }

        private static void Read(DataClassesDataContext context)
        {
            foreach (var item in context.Students)
            {
                Console.WriteLine($"{item.Name} {item.Surname} ==> {item.Group.Name}");
            }
        }
    }
}
