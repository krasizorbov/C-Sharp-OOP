using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException();
                }
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * Radius * 2;
        }
        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
