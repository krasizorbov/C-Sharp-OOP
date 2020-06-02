using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Writer : IWriter
    {
        public void WriteData(string output)
        {
            Console.WriteLine(output);
        }
    }
}
