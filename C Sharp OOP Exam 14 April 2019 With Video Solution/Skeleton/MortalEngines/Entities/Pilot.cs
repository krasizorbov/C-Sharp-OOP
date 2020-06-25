using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot : IPilot
    {
        string name;
        List<IMachine> machines;
        public Pilot(string name)
        {
            Name = name;
            machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            else
            {
                machines.Add(machine);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} - {machines.Count} machines");
            foreach (var machine in machines)
            {
                sb.AppendLine(machine.ToString().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
