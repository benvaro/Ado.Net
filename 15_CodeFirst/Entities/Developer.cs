using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _15_CodeFirst.Entities
{
    public class Developer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Nav props
        public virtual ICollection<Game> Games { get; set; }

        public Developer()
        {
            Games = new List<Game>();
        }
    }
}
