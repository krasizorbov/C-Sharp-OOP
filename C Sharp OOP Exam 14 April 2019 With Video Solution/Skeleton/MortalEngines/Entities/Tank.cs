using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints - 40, defensePoints + 30, 100)
        {
            DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            FlipDefenceMode();
            UpdatePoints();
        }

        private void UpdatePoints()
        {
            if (DefenseMode == true)
            {
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else
            {
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }

        private void FlipDefenceMode()
        {
            DefenseMode = !DefenseMode;
        }

        public override string ToString()
        {
            string defenceMode = string.Empty;
            if (DefenseMode == true)
            {
                defenceMode = "ON";
            }
            else
            {
                defenceMode = "OFF";
            }
            return base.ToString() + Environment.NewLine + $" *Defense: {defenceMode}";
        }
    }
}
