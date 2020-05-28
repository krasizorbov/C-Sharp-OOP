using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> b = new List<IBuyer>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];
                    b.Add(new Citizen(name, age, id, birthdate));
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];
                    b.Add(new Rebel(name, age, group));
                }
            }
            
            string command = Console.ReadLine();
            while (command != "End")
            {
                var buyer = b.SingleOrDefault(n => n.Name == command);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(b.Sum(f => f.Food));
        }
    }
}
