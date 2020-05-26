using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShop
{
    public class Book
    {
        string title;
        string author;
        decimal price;
        public virtual string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                else
                {
                    title = value;
                }
            }
        }
        public virtual string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (value.Split().Length > 1 && Char.IsDigit(value.Split().Skip(1).First().First()))
                {
                    throw new ArgumentException("Author not valid!");
                }
                else
                {
                    author = value;
                }
            }
        }
        public virtual decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                else
                {
                    price = value;
                }
            }
        }
        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }
        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {GetType().Name}")
                .AppendLine($"Title: {Title}")
                .AppendLine($"Author: {Author}")
                .AppendLine($"Price: {Price:f2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

    }
}
