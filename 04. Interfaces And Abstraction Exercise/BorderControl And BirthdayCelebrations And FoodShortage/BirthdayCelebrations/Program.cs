using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> robots = new List<IIdentifiable>();
            List<IBirthable> personAndpet = new List<IBirthable>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split();

                if (tokens[0] == "Citizen")
                {
                    personAndpet.Add(new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]));
                }
                else if (tokens[0] == "Pet")
                {
                    personAndpet.Add(new Pet(tokens[1], tokens[2]));
                }
                else if (tokens[0] == "Robot")
                {
                    robots.Add(new Robot(tokens[1], tokens[2]));
                }
            }

            var lastDigits = Console.ReadLine();

            personAndpet.Where(c => c.Birthday.EndsWith(lastDigits))
                .Select(c => c.Birthday)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
