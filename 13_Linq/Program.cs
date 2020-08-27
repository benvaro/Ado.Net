using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
namespace _13_Linq
{
    public static class Ext
    {
        public static int CountLetters(this string str)
        {
            return str.Count(x => char.IsLetter(x));
        }
    }


    public class Product
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public override string ToString()
        {
            return $"{Name} =====> {Price} ==> {Category}";
        }
    }
    internal class Program
    {
        // Lanquage integrated query
        private static void Main(string[] args)
        {
            var games = new string[] { "FIFA", "GTA 5", "CS:GO", "NFS", "Cyberpank", "World of Tank", "Far Cry", "Fallout", "GTA 5", "NFS", "FIFA" };
            var numbers = new[] { 4, 7, 34, 2, -8, 5 };
            //Console.WriteLine(games.Count());
            //Console.WriteLine(numbers.Min());
            //string test = "he23llo";
            //Console.WriteLine(test.CountLetters());

            var res = (from obj in games
                       where obj.StartsWith("C") || obj.EndsWith("S")
                       //  orderby obj
                       select obj).Distinct();

            Print(res);

            var products = new List<Product>()
            {
                new Product{Name = "Coffe", Price = 15, Category = "Drinks"},
                new Product{Name = "Apple", Price = 13, Category = "fruits"},
                new Product{Name = "Water", Price = 35, Category = "Drinks"},
                new Product{Name = "Bread", Price = 10, Category = "Bakery"},
                new Product{Name = "Banana", Price = 33, Category = "fruits"},
                new Product{Name = "Cake", Price = 100, Category = "Bakery"},
                new Product{Name = "Cherry", Price = 45, Category = "fruits"}
            };


            // синтаксис запитів
            //var prods = (from p in products
            //             where p.Price > 20
            //             select p);//.FirstOrDefault();

            // linq method
            // Func<Product, bool> predicate
            // predicate - logical function

            // синтаксис методів
            // var prods = products.Where(x => x.Price > 20).FirstOrDefault();
            // var prods = products.Where(x => x.Price > 20).Select(x=>x.Name);
            //   var prods = products.Where(x => x.Price > 10).Select(x=>new { x.Name, x.Price });
           // var prods = products.Where(x => x.Price > 10).OrderBy(x => x.Price);
            Console.Clear();
            //    System.Console.WriteLine(prods);

            // group by

            //var groupsProducts = from p in products
            //                     group p by p.Category // Key
            //                     into groupedProducts
            //                     select groupedProducts;

            // {{fruits: {apple, 13, friits}, {banana, 13, friits}, {apple, 13, friits}}
            // {bakery: {}{}}
            // {drinks: {}{}}}

            //var groupsProducts = products.GroupBy(x => x.Category);

            //foreach (var item in groupsProducts)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var  info in item)
            //    {
            //        Console.WriteLine("\t\t\t" + info);
            //    }
            //}

            var prods = products.Take(2);
            Print(prods);
            Console.WriteLine();

            prods = products.Skip(2).Take(2);
            Print(prods);
            Console.Clear();
            prods = products.Skip(1).Take(3).Skip(1).Take(2).Skip(1);
            Print(prods);
        }

        private static void Print(IEnumerable res)
        {
            foreach (var item in res)
            {
                System.Console.WriteLine(item);
            }
        }
    }
}
