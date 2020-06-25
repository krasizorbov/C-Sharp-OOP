using MortalEngines.Entities;
using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Core
{
    public class PilotFactory
    {
        public IPilot CreatePilot(string name)
        {
            IPilot pilot = new Pilot(name);
            return pilot;
        }
    }
}
