using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        string name;
        int age;
        string gender;
        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        private string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }

                name = value;
            }
        }

        private int Age
        {
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                age = value;
            }
        }

        private string Gender
        {
            set
            {
                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                gender = value;
            }
        }
        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(GetType().Name);
            builder.AppendLine($"{name} {age} {gender}");
            builder.Append($"{ProduceSound()}");

            return builder.ToString();
        }
    }
}
