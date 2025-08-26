namespace ManageSmallLibrary.Models
{
  public class Member
  {
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }
    public required int[] BorrowedBooks { get; set; }
  }
}
