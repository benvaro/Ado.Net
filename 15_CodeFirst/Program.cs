using _15_CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();
            context.Database.Log = Logger;
            Genre genre = new Genre { Name = "RPG" };
            Developer dev = new Developer { Name = "Ubisoft" };
           // Game game = new Game { Name = "FarCry", Year = 2017, Developer = dev, Genre = genre };
       //     context.Games.Add(game);
         //   context.SaveChanges();

       //     Print(context.Games.ToList());
            var game = new Game { Name = "Read dead redemption", Year = 2020,
                Developer = new Developer { Name = "Rockstar"},
                Genre = context.Genres.FirstOrDefault(x => x.Name.Equals("Action")) };
            context.Games.Add(game);

            context.SaveChanges();
            Print(context.Games.ToList());
        }

        private static void Print(ICollection<Game> games)
        {
            foreach (var item in games)
            {
                try
                {
                    Console.WriteLine($"{item.Name}, {item.Year}," +
                        $" Genre - {item.Genre.Name}, Devs - {item.Developer.Name}");
                }
                catch { }
            }
        }

        private static void Logger(string obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(obj);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
