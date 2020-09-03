using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _16_Initializer.Entities;

namespace _16_Initializer
{
    class Program
    {
            static ApplicationContext context = new ApplicationContext();
        static void Main(string[] args)
        {
                //   context.Database.Log = Logger;
                // Жадібна загрузка (eager loading)
                // якщо є virtual - то це lazy loading
                //foreach (var item in context.Games.Include(x => x.Developer).Include(x => x.Genre))
                //{
                //    Console.WriteLine($"{item.Name} == > {item.Developer.Name}  ==> {item.Genre.Name}");
                //}

                //var genreName = context.Games.Include(x=>x.Genre).FirstOrDefault().Genre.Name;
                //Console.WriteLine(genreName);

                Developer dev = new Developer { Name = "Epic" };
                context.Entry(dev).State = EntityState.Added;
                context.SaveChanges();

                foreach (var item in context.Developers)
                {
                    Console.WriteLine(item.Name);
                }

                CheckState(dev);
                Console.WriteLine();
                foreach (var item in context.Developers)
                {
                    Console.WriteLine(item.Name);
                }
        }

        private static void CheckState(Developer dev)
        {
            //ApplicationContext context = new ApplicationContext();
            Console.WriteLine("Enter new name: ");
            string name = Console.ReadLine();
            dev.Name = name;
            context.SaveChanges();
            //Console.WriteLine(context.Entry(dev).State);
          
            ////   context.Developers.Add(dev);
            //context.Entry(context.Games.FirstOrDefault()).State = EntityState.Deleted;
            //Console.WriteLine(context.Entry(dev).State);
            //context.SaveChanges();
            //Console.WriteLine(context.Entry(dev).State);
            //dev.Name = "AbGames";
            //Console.WriteLine(context.Entry(dev).State);
            //context.SaveChanges();


        }

        private static void Logger(string obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(obj);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
