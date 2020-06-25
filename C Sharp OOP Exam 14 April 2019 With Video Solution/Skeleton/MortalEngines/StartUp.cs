using MortalEngines.Core;
using MortalEngines.Core.Contracts;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            IMachinesManager machinesManager = new MachinesManager();

            ICommandInterpreter commandInterpreter = new CommandInterpreter(machinesManager);
            IEngine engine = new Engine(commandInterpreter);

            engine.Run();
        }
    }
}