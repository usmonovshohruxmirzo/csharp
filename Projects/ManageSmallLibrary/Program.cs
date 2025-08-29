using ManageSmallLibrary.Models;

namespace ManageSmallLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books = Data.Books;
            Author[] authors = Data.Authors;
            Member[] members = Data.Members;

            void H(string t) => Console.WriteLine($"\n======= {t} =======");
            void Print<T>(IEnumerable<T> xs)
            {
                foreach (var x in xs)
                {
                    Console.WriteLine("  " + x);
                }
            }

            // 1) Filtering
            H("1) Filtering");
            var recentBooks = books.Where(b => b.PublishedYear > 2020);
            var olderMembers = members.Where(m => m.Age > 25);
            Console.WriteLine("Books after 2020:"); Print(recentBooks.Select(b => $"{b.Title} ({b.PublishedYear})"));
            Console.WriteLine("Members older than 25:"); Print(olderMembers.Select(m => $"{m.Name} ({m.Age})"));

            // 2) Projection
            H("2) Projection");
            var bookTitles = books.Select(b => b.Title);
            var borrowedBookIds = members.SelectMany(m => m.BorrowedBookIds);
            Console.WriteLine("Book titles:"); Print(bookTitles);
            Console.WriteLine("All borrowed book IDs (flat):"); Print(borrowedBookIds);

            H("3) Ordering");
            var orderedBooks = books.OrderBy(book => book.Pages).ThenBy(book => book.Title);
            Print(orderedBooks.Select(book => $"{book.Title} - {book.Pages}"));

            // 4) Grouping
            H("4) Grouping");
            var byYear = books.GroupBy(book => book.PublishedYear);
            foreach (var g in byYear)
            {
                Console.WriteLine($"Year: {g.Key}");
                Print(g.Select(b => $"- {b.Title}"));
            }
            var membersByBorrowCount = members.GroupBy(m => m.BorrowedBookIds.Length);
            foreach (var g in membersByBorrowCount)
            {
                Console.WriteLine($"Borrow count {g.Key}");
                Print(g.Select(m => $"- {m.Name}"));
            }

            // 5) Quantifiers
            H("5) Quantifiers");
            bool anyOver400 = books.Any(b => b.Pages > 400);
            bool allOver20 = members.All(m => m.Age > 20);
            bool hasLinqInAction = books.Select(b => b.Title).Contains("LINQ in Action");
            Console.WriteLine($"Any book > 400 pages? {anyOver400}");
            Console.WriteLine($"All members > 20? {allOver20}");
            Console.WriteLine($"Contains 'LINQ in Action'? {hasLinqInAction}");

            // 6) Element operators
            H("6) Element Operators");
            var firstPublished = books.OrderBy(b => b.PublishedYear).First();
            var lastMemberAlpha = members.OrderBy(m => m.Name).Last();
            var singleId3 = books.Single(b => b.Id == 3);
            Console.WriteLine($"First published: {firstPublished.Title} ({firstPublished.PublishedYear})");
            Console.WriteLine($"Last member (alphabetical): {lastMemberAlpha.Name}");
            Console.WriteLine($"Single book with Id=3: {singleId3.Title}");

            // 7) Aggregation
            H("7) Aggregation");
            int totalBooks = books.Count();
            int totalPages = books.Sum(b => b.Pages);
            double avgPages = books.Average(b => b.Pages);
            int maxPages = books.Max(b => b.Pages);
            var bookWithMax = books.OrderByDescending(b => b.Pages).First();
            long productYears = books.Select(b => (long)b.PublishedYear).Aggregate(1L, (acc, y) => acc * y);
            Console.WriteLine($"Count: {totalBooks}");
            Console.WriteLine($"Sum pages: {totalPages}");
            Console.WriteLine($"Average pages: {avgPages:F2}");
            Console.WriteLine($"Max pages: {maxPages} ({bookWithMax.Title})");
            Console.WriteLine($"Product of all PublishedYear (long): {productYears}");

            // 8) Set operations
            H("8) Set Operations");
            var distinctBorrowed = members.SelectMany(m => m.BorrowedBookIds).Distinct();
            var commonBorrowedAll = members
                .Select(m => m.BorrowedBookIds.AsEnumerable())
                .Aggregate((prev, next) => prev.Intersect(next));
            var member1Ids = members.First(m => m.Id == 1).BorrowedBookIds;
            var notBorrowedBy1 = books.Where(b => !member1Ids.Contains(b.Id)).Select(b => b.Title);
            Console.WriteLine("Distinct borrowed IDs:"); Print(distinctBorrowed);
            Console.WriteLine("Common borrowed IDs among ALL members:"); Print(commonBorrowedAll);
            Console.WriteLine("Books NOT borrowed by member #1:"); Print(notBorrowedBy1);

            // 9) Conversion
            H("9) Conversion");
            var booksList = books.ToList();
            var authorDict = authors.ToDictionary(a => a.Id, a => a.Name);
            Console.WriteLine($"Books list count: {booksList.Count}");
            Console.WriteLine("Author dictionary (Id -> Name):");
            foreach (var kv in authorDict) Console.WriteLine($"{kv.Key} -> {kv.Value}");

            // 10) Joining
            H("10) Joining");
            var bookWithAuthor = books.Join(
                authors,
                b => b.AuthorId,
                a => a.Id,
                (b, a) => new { b.Title, AuthorName = a.Name }
            );
            Console.WriteLine("Book + Author:");
            Print(bookWithAuthor.Select(x => $"{x.Title} — {x.AuthorName}"));

            var authorsWithBooks = authors.GroupJoin(
                books,
                a => a.Id,
                b => b.AuthorId,
                (a, bs) => new { a.Name, Titles = bs.Select(b => b.Title).ToList() }
            );
            foreach (var x in authorsWithBooks)
            {
                Console.WriteLine($"{x.Name}: {x.Titles.Count} book(s)");
                Print(x.Titles.Select(t => $"- {t}"));
            }

            // 11) Partitioning
            H("11) Partitioning");
            var first3Books = books.Take(3);
            var skip2Members = members.Skip(2);
            var takeWhileUnder400 = books.TakeWhile(b => b.Pages < 400).Select(b => b.Title);
            Console.WriteLine("First 3 books:"); Print(first3Books.Select(b => b.Title));
            Console.WriteLine("Skip first 2 members:"); Print(skip2Members.Select(m => m.Name));
            Console.WriteLine("Take while pages < 400 (stops at first >= 400):"); Print(takeWhileUnder400);

            // 12) Misc
            H("12) Misc");
            var reversedTitles = books.Reverse().Select(b => b.Title);
            Console.WriteLine("Reversed book titles:");
            Print(reversedTitles);
            var titlePart1 = books.Take(2).Select(b => b.Title);
            var titlePart2 = books.Take(2).Select(b => b.Title);
            var concatenated = titlePart1.Concat(titlePart2);
            Console.WriteLine("Concatenated titles:");
            Print(concatenated);
            var safeDefault = books
              .Where(b => b.PublishedYear < 1900)
              .DefaultIfEmpty(new Book { Id = 0, Title = "(None)", Pages = 0, AuthorId = 0, PublishedYear = 0 });
            Console.WriteLine("DefaultIfEmpty demo:");
            Print(safeDefault.Select(b => $"{b.Title} ({b.PublishedYear})"));

            // 13)
            H("13) Challenge (combined)");
            var challenge = members
                .Where(m => m.Age > 20)
                .Select(m => new
                {
                    m.Name,
                    m.Age,
                    Titles = m.BorrowedBookIds
                        .Join(books, id => id, b => b.Id, (id, b) => b)
                        .Where(b => b.Pages > 300)
                        .Select(b => b.Title)
                        .ToList()
                })
                .Where(x => x.Titles.Any())
                .OrderBy(x => x.Age);

            foreach (var x in challenge)
            {
                Console.WriteLine($"{x.Name} ({x.Age}) -> {string.Join(", ", x.Titles)}");
            }
        }
    }
}
