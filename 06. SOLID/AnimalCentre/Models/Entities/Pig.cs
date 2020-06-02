using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public class Pig : Animal
    {
        public Pig(string name, int energy, int happiness, int procedureTime) 
            : base(name, energy, happiness, procedureTime)
        {
        }
        public override string ToString()
        {
            return String.Format(base.ToString(), GetType().Name, Name, Happiness, Energy);
        }
    }
}
