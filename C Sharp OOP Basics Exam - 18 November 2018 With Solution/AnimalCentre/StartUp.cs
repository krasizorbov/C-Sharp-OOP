using System;
using AnimalCentre.Core;
using AnimalCentre.IO;

namespace AnimalCentre
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
