using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SpecificationPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = new[]
            {
                new Product {Id = 1, Name = "Pen", Cost = 40, Units = 20},
                new Product {Id = 4, Name = "Hen", Cost = 70, Units = 80},
                new Product {Id = 6, Name = "Ten", Cost = 30, Units = 50},
                new Product {Id = 2, Name = "Den", Cost = 80, Units = 30},
            };

            products.Where(ProductCriteria.CostlyProductPredicate);
        }
    }

    public static class ProductCriteria
    {
        public static Func<Product, bool> CostlyProductPredicate = p => p.Cost > 50;
    }

    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
    }

    class CostlyProductSpecification : ISpecification<Product>
    {
        private readonly decimal _basePrice;

        public CostlyProductSpecification(decimal basePrice)
        {
            _basePrice = basePrice;
        }

        public bool IsSatisfiedBy(Product item)
        {
            return item.Cost > _basePrice;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Units { get; set; }
    }
}
