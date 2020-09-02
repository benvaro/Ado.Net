using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UniversityContextContainer context = new UniversityContextContainer())
            {
                //context.Database.Log = Loger;
                context.Kinds.AddRange(new[]
                {
                    new Kind{Name = "Beard"},
                    new Kind{Name = "Fish"},
                    new Kind{Name = "Snake"}
                });

                context.SaveChanges();

                context.Animals.AddRange(new[] {

                new Animal
                {
                    Name = "Parrot", Kind = context.Kinds.FirstOrDefault(x=>x.Name.Equals("Beard"))

                },
                new Animal{ Name = "Pirania", Kind = context.Kinds.FirstOrDefault(x=>x.Name.Equals("Fish"))}
                });

                context.SaveChanges();
                foreach (var item in context.Animals)
                {
                    Console.WriteLine($"{item.Name} ==> {item.Kind.Name}");
                }
            }


        }
        static void Loger(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
