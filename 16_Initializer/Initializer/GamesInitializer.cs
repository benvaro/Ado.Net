using _16_Initializer.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace _16_Initializer.Initializer
{
    public class GamesInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var genres = new List<Genre>(){
                new Genre{Name = "RPG"},
                new Genre{Name = "Sport Simulator"},
                new Genre{Name = "Strategy"},
                new Genre{Name = "Shooter"},
                new Genre{Name = "Action"}
            };

            var developers = new List<Developer>()
            {
                new Developer{Name = "EA"},
                new Developer{Name = "Ghost Games"},
                new Developer{Name = "RockStar"},
                new Developer{Name = "Bethesda"},
                new Developer{Name = "Ubisoft"},
                new Developer{Name = "Playrix"},
                new Developer{Name = "Valve"}
            };

            var games = new List<Game>()
            {
                new Game
                {
                    Name = "GTA 5",
                    Description = "",
                    Image = "",
                    Price = 57,
                    Year = 2018,
                    Genre = genres.FirstOrDefault(x=>x.Name.Equals("RPG")),
                    Developer = developers.FirstOrDefault(x=>x.Name.Equals("RockStar"))
                },
                new Game
                {
                    Name = "FIFA",
                    Description = "",
                    Image = "",
                    Price = 87,
                    Year = 2020,
                    Genre = genres.FirstOrDefault(x=>x.Name.Equals("Sport Simulator")),
                    Developer = developers.FirstOrDefault(x=>x.Name.Equals("EA"))
                },
                new Game
                {
                    Name = "FarCry",
                    Description = "",
                    Image = "",
                    Price = 100,
                    Year = 2017,
                    Genre = genres.FirstOrDefault(x=>x.Name.Equals("Action")),
                    Developer = developers.FirstOrDefault(x=>x.Name.Equals("Ubisoft"))
                }
            };

            context.Genres.AddRange(genres);
            context.Developers.AddRange(developers);
            context.Games.AddRange(games);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
