using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        const string Command = "Command";
        public string Read(string InputLine)
        {
            string[] cmdTokens = InputLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string commandName = cmdTokens[0] + Command;
            string[] commandArgs = cmdTokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Operation");
            }

            Object instance = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instance;
            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
