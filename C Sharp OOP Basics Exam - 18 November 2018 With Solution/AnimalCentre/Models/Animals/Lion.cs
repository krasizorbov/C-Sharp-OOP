using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Lion : Animal
    {
        public Lion(string name, int energy, int happiness, int playTime) 
            : base(name, energy, happiness, playTime)
        {
        }
        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Lion), Name, Happiness, Energy);
        }
    }
}
