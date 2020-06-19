using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        string name;
        public Rider(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }
        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(nameof(motorcycle),"Motorcycle cannot be null.");
            }

            Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
