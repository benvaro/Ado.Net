using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Initializer.Entities
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
