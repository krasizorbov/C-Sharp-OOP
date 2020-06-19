using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        int horsePower;
        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 125)
        {
        }

        public override int HorsePower
        {
            get
            {
                return horsePower;
            }
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
