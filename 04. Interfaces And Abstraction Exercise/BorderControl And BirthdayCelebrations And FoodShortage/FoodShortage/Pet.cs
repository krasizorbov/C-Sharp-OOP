using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Pet : IBirthable
    {
        string name;
        public string Birthday { get; set; }
        public Pet(string name, string birthday)
        {
            this.name = name;
            Birthday = birthday;
        }
    }
}
