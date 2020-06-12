using System;

namespace AnimalCentre.IO
{
    public class Reader : IReader

    {
        public string readInput()
        {
            return Console.ReadLine();
        }
    }
}