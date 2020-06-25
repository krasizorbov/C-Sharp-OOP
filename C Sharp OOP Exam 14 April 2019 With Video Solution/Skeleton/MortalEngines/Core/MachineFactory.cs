using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class MachineFactory
    {
        public IMachine CreateMachine(string type, string name, double attack, double defense)
        {
            IMachine machine = null;
            if (type == "Fighter")
            {
                machine = new Fighter(name, attack, defense);
            }
            else if (type == "Tank")
            {
                machine = new Tank(name, attack, defense);
            }
            return machine;
        }
    }
}
