using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int energy, int happiness, int playTime) 
            : base(name, energy, happiness, playTime)
        {
        }
        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Cat), Name, Happiness, Energy);
        }
    }
}
