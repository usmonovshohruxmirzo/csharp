using System;

namespace MyNamespace
{
    class Customer
    {
        public int Id;
        public string? Name;
    }

    class Order
    {
        public int Id;
        public int CustomerId;
        public decimal Amount;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // List<int> numbers = new List<int> { 4, 2, 3, 4, 5, 6 };
            //
            // var evenNumbers = from n in numbers
            //                   where n % 2 == 0
            //                   select n;
            //
            // foreach (var num in evenNumbers)
            // {
            //     Console.WriteLine(num);
            // }

            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Alice" },
                new Customer { Id = 2, Name = "Bob" },
                new Customer { Id = 3, Name = "Charlie" }
            };

            var orders = new List<Order>
            {
                new Order { Id = 101, CustomerId = 1, Amount = 120 },
                new Order { Id = 102, CustomerId = 1, Amount = 80 },
                new Order { Id = 103, CustomerId = 2, Amount = 200 }
            };


            var query =
                from c in customers                      // from
                join o in orders                         // join
                    on c.Id equals o.CustomerId
                    into orderGroup                      // into (group join)
                from og in orderGroup.DefaultIfEmpty()   // LEFT JOIN
                where og == null || og.Amount > 100      // filter
                let customerName = c.Name?.ToUpper()      // let
                orderby customerName                     // order
                group og by customerName                 // group by
                into g                                   // into (query continuation)
                select new                               // projection
                {
                    Customer = g.Key,
                    TotalOrders = g.Count(x => x != null),
                    TotalAmount = g.Sum(x => x?.Amount ?? 0)
                };

            foreach (var item in query)
            {
                Console.WriteLine($"Customer: {item.Customer}, Orders: {item.TotalOrders}, Total Amount: {item.TotalAmount}");
            }
        }
    }
}
