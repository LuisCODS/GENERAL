namespace BooksAPI.DTOs
{
    //Un DTO est un objet qui est conçu uniquement pour transmettre les données.
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}