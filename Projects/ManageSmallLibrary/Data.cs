namespace ManageSmallLibrary
{
    public static class Data
    {
        public static readonly object[] Books = new[]
        {
            new { Id = 1, Title = "C# Basics", Pages = 200, AuthorId = 1, PublishedYear = 2020 },
            new { Id = 2, Title = "Advanced C#", Pages = 450, AuthorId = 1, PublishedYear = 2022 },
            new { Id = 3, Title = "LINQ in Action", Pages = 300, AuthorId = 2, PublishedYear = 2021 },
            new { Id = 4, Title = "WPF Fundamentals", Pages = 350, AuthorId = 3, PublishedYear = 2019 },
            new { Id = 5, Title = "Async Programming", Pages = 250, AuthorId = 2, PublishedYear = 2022 }
        };

        public static readonly object[] Authors = new[]
        {
            new { Id = 1, Name = "Alice" },
            new { Id = 2, Name = "Bob" },
            new { Id = 3, Name = "Charlie" }
        };

        public static readonly object[] Members = new[]
        {
            new { Id = 1, Name = "John", Age = 25, BorrowedBookIds = new int[] { 1, 3 } },
            new { Id = 2, Name = "Emma", Age = 30, BorrowedBookIds = new int[] { 2, 5 } },
            new { Id = 3, Name = "Mike", Age = 22, BorrowedBookIds = new int[] { 4 } }
        };
    }
}
