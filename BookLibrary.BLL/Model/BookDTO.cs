namespace BookLibrary.BLL.Model
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}
