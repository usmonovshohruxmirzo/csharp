using ManageSmallLibrary.Models;

namespace ManageSmallLibrary
{
    public static class Data
    {
        public static readonly Book[] Books = new Book[]
        {
            new Book { Id = 1, Title = "C# Basics", Pages = 200, AuthorId = 1, PublishedYear = 2020 },
            new Book { Id = 2, Title = "Advanced C#", Pages = 200, AuthorId = 1, PublishedYear = 2020 },
            new Book { Id = 3, Title = "LINQ in Action", Pages = 300, AuthorId = 2, PublishedYear = 2021 },
            new Book { Id = 4, Title = "WPF Fundamentals", Pages = 350, AuthorId = 3, PublishedYear = 2019 },
            new Book { Id = 5, Title = "Async Programming", Pages = 250, AuthorId = 2, PublishedYear = 2022 }
        };

        public static readonly Author[] Authors = new Author[]
        {
            new Author { Id = 1, Name = "Alice" },
            new Author { Id = 2, Name = "Bob" },
            new Author { Id = 3, Name = "Charlie" }
        };

        public static readonly Member[] Members = new Member[]
        {
            new Member { Id = 1, Name = "John", Age = 25, BorrowedBookIds = new int[] { 1, 3 } },
            new Member { Id = 2, Name = "Emma", Age = 30, BorrowedBookIds = new int[] { 2, 5 } },
            new Member { Id = 3, Name = "Mike", Age = 22, BorrowedBookIds = new int[] { 4 } }
        };
    }
}
