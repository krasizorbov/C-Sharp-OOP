using System;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get
        {
            return this.name;
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

    public decimal Cost
    {
        get
        {
            return this.cost;
        }

        private set
        {
            if (value < 0)
            {
                Console.WriteLine("Money cannot be negative");
                Environment.Exit(0);
            }

            this.cost = value;
        }
    }
}