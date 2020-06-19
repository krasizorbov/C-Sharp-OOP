using System;
using MXGP.Repositories;
namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core;
    using MXGP.IO;
    using MXGP.IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
