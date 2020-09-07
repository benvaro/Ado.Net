using System.ComponentModel.DataAnnotations;

namespace BookLibrary.DAL.Entities
{
    //   [Table("tblBook")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public float Price { get; set; }
        //Nav props
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Author Author { get; set; }

    }
}
