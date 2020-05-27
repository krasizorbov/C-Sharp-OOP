using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        double length;
        double width;
        double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double Surface()
        {
            double surfaceArea = 2 * width * length + 2 * length * height + 2 * width * height;
            return surfaceArea;
        }
        public double Lateral()
        {
            double lateralSurfaceArea = 2 * length * height + 2 * width * height;
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = length * width * height;
            return volume;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {Surface():F2}");
            sb.AppendLine($"Lateral Surface Area - {Lateral():F2}");
            sb.AppendLine($"Volume - {Volume():F2}");
            return sb.ToString().TrimEnd();
        }
    }
}
