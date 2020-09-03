using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _16_Initializer.Entities
{
    public class Game
    {
        [Key] // primary key
        public int Id { get; set; }

        [Required]   // обов'язкове поле 
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        [Range(1980, 2020)]
        public int Year { get; set; }

        public double? Price { get; set; }

        public string Image { get; set; }

        [MaxLength(300)]
        //[MinLength(2)]
        public string Description { get; set; }

        // Navigation props
        public int? GenreId { get; set; }

        [ForeignKey("Developer")]
        public int? DeveloperId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; }
        public virtual Developer Developer { get; set; }
    }
}
