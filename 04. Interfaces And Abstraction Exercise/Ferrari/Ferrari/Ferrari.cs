using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        string name;

        public string Name { get; set; }
        public Ferrari(string name)
        {
            Name = name;
        }

        public string Brakes()
        {
            return "Brakes!";
        }
        public string Gas()
        {
            return "Gas!";
        }
    }
}
