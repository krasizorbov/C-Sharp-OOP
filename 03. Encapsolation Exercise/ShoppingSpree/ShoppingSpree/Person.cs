using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        string name;
        decimal money;
        List<Product> products;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Name cannot be empty");
                    Environment.Exit(0);
                }

                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    Environment.Exit(0);
                }

                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return products.AsReadOnly();
            }
        }
        public bool BuyProduct(Product product)
        {
            if (this.money >= product.Cost)
            {
                this.money -= product.Cost;
                this.products.Add(product);
                return true;
            }

            return false;
        }
    }
}
