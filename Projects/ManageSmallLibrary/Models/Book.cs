namespace ManageSmallLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public int PublishedYear { get; set; }
    }
}
