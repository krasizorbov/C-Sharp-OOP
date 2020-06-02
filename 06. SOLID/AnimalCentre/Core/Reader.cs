using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Reader : IReader
    {
        public string ReadData()
        {
            return Console.ReadLine();
        }
    }
}
