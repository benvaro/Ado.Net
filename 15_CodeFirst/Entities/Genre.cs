using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _15_CodeFirst.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Nav props
        public virtual ICollection<Game> Games { get; set; }

        public Genre()
        {
            Games = new List<Game>();
        }
    }
}
