namespace ManageSmallLibrary.Models
{
    public class Member
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Age { get; set; }
        public int[] BorrowedBookIds { get; set; } = Array.Empty<int>();
    }
}
