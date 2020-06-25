namespace MortalEngines.Core
{
    using System;
    using System.Reflection;
    using MortalEngines.Core.Contracts;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "Quit")
            {
                string[] inputArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    string result = this.commandInterpreter.Read(inputArgs);
                    Console.WriteLine(result);
                }
                catch (TargetInvocationException ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException.Message}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
