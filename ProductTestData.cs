using RazorMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RazorMVC.Tests
{
    public class ProductTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { GetPricesUnder50() };
            yield return new object[] { GetPricesOver50 };
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        private IEnumerable<Product> GetPricesUnder50()
        {
            decimal[] prices = new decimal[] { 275M, 49.95M, 19.50M, 24.95M };
            for (int i = 0; i < prices.Length; i++)
            {
                yield return new Product { Name = $"P{i + 1}", Price = prices[i], Description = $"D{i + 1}", Category = $"C{i + 1}" };
            }
        }
        private Product[] GetPricesOver50 => new Product[] {
        new Product { Name = "P1", Price = 5M, Description="D1",Category="C1"  },
        new Product { Name = "P2", Price = 48.95M, Description="D2",Category="C2" },
        new Product { Name = "P3", Price = 19.50M, Description="D3",Category="C3" },
        new Product { Name = "P4", Price = 24.95M, Description="D4",Category="C4" }};
    }

}