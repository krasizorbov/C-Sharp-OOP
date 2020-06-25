using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints + 50, defensePoints - 25, 200)
        {
            AggressiveMode = true;
        }
        public bool AggressiveMode { get; private set; }
     
        public void ToggleAggressiveMode()
        {
            FlipAggressiveMode();
            UpdatePoints();
        }

        private void UpdatePoints()
        {
            if (AggressiveMode == true)
            {
                AttackPoints += 50;
                DefensePoints -= 25;
            }
            else
            {
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }

        private void FlipAggressiveMode()
        {
            AggressiveMode = !AggressiveMode;
        }

        public override string ToString()
        {
            string aggressiveMode = string.Empty;
            if (AggressiveMode == true)
            {
                aggressiveMode = "ON";
            }
            else
            {
                aggressiveMode = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Aggressive: {aggressiveMode}";
        }
    }
}
