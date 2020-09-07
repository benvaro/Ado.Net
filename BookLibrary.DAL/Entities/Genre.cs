using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibrary.DAL.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        // Nav props
        public virtual ICollection<Book> Books { get; set; }

        public Genre()
        {
            Books = new List<Book>();
        }
    }
}
