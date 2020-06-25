namespace MortalEngines.Core
{
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;
    using MortalEngines.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IMachinesManager machinesManager;

        public CommandInterpreter(IMachinesManager machinesManager)
        {
            this.machinesManager = machinesManager;
        }

        public string Read(string[] args)
        {
            string[] commandArgs = args
                .Skip(1)
                .ToArray();
            string commandName = args[0];

            if (commandName == "AggressiveMode")
            {
                commandName = "ToggleFighterAggressiveMode";
            }
            else if (commandName == "DefenseMode")
            {
                commandName = "ToggleTankDefenseMode";
            }
            else if (commandName == "Engage")
            {
                commandName = "EngageMachine";
            }
            else if (commandName == "Attack")
            {
                commandName = "AttackMachines";
            }

            MethodInfo managerMethod = typeof(MachinesManager)
                .GetMethod(commandName);

            List<object> requiredParameters = new List<object>();

            foreach (var argument in commandArgs)
            {
                if (double.TryParse(argument, out double parsedArgument))
                {
                    requiredParameters.Add(parsedArgument);

                    continue;
                }

                requiredParameters.Add(argument);
            }

            string result = (string)managerMethod.Invoke(this.machinesManager, requiredParameters.ToArray());

            return result;
        }
    }
}