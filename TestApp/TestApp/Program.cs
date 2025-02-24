using System;
using System.Collections.Generic;

namespace ProductOfNumbers
{
    public class ProductOfNumbers
    {
        private List<int> prefixProduct;

        public ProductOfNumbers()
        {
            prefixProduct = new List<int>();
            prefixProduct.Add(1);
        }

        public void Add(int num)
        {
            if (num == 0)
            {
                prefixProduct.Clear();
                prefixProduct.Add(1);
            }
            else
            {
                int lastProduct = prefixProduct[prefixProduct.Count - 1];
                prefixProduct.Add(lastProduct * num);
            }
        }

        public int GetProduct(int k)
        {
            int n = prefixProduct.Count;
            if (k >= n)
            {
                return 0;
            }

            return prefixProduct[n - 1] / prefixProduct[n - k - 1];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProductOfNumbers obj = new ProductOfNumbers();

            obj.Add(3);
            obj.Add(4);
            Console.WriteLine(obj.GetProduct(2)); // Expected Output: 12 / 3 = 4

            obj.Add(0);
            obj.Add(2);
            Console.WriteLine(obj.GetProduct(1)); // Expected Output: 2
            Console.WriteLine(obj.GetProduct(2)); // Expected Output: 0

            obj.Add(5);
            obj.Add(4);
            Console.WriteLine(obj.GetProduct(2)); // Expected Output: 5 * 4 = 20
            Console.WriteLine(obj.GetProduct(3)); // Expected Output: 2 * 5 * 4 = 40
        }
    }
}
