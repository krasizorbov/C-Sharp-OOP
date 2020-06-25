using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Core
{
    public class MachineRepository
    {
        private List<IMachine> machines;

        public MachineRepository()
        {
            this.machines = new List<IMachine>();
        }

        public IReadOnlyCollection<IMachine> Machines => this.machines;

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public void RemoveMachine(IMachine machine)
        {
            if (this.machines.Contains(machine))
            {
                this.machines.Remove(machine);
            }
        }

        public bool ContainsMachine(string name)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
