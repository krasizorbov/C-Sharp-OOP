using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MortalEngines.Core
{
    public class PilotRepository
    {
        private List<IPilot> pilots;

        public PilotRepository()
        {
            this.pilots = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public void RemovePilot(IPilot pilot)
        {
            if (this.pilots.Contains(pilot))
            {
                this.pilots.Remove(pilot);
            }
        }

        public bool ContainsPilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
