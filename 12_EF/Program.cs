using System;
using System.Text;

namespace _12_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            // Entity Framework - ORM - Object Relational Maping, dapper
            // create
            // Database First
            // Model First
            // Code first !!
            Console.OutputEncoding = Encoding.UTF8;
            UniversityEntities context = new UniversityEntities();
            // Entity - сутність БД (запис таблички)
            foreach (var item in context.Student)
            {
                Console.WriteLine($"{item.Name} {item.Surname} ===> {item.Groups.Name}");
            }

            //Student st = new Student { Name = "Olia", Surname = "Blablabla", Groups = context.Groups.Find(2) };
            Student st = new Student { Name = "Olia", Surname = "Blablabla", Groups = new Groups { Name = "Step" } };
            context.Student.Add(st);
            //context.Student.Where(x => x.Name == "" && x.Surname == "");
            context.SaveChanges();
            Console.WriteLine();
            foreach (var item in context.Student)
            {
                Console.WriteLine($"{item.Name} {item.Surname} ===> {item.Groups.Name}");
            }
        }
    }
}
