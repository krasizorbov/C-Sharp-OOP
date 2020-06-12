using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int playTime) 
            : base(name, energy, happiness, playTime)
        {
        }
        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Pig), Name, Happiness, Energy);
        }
    }
}
