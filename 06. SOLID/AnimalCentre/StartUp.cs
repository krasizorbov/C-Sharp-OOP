using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
