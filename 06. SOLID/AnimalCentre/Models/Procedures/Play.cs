using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        const int addHappiness = 12;
        const int removeEnergy = 6;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Happiness += addHappiness;
            animal.Energy -= removeEnergy;
            procedureHistory.Add(animal);
        }
    }
}
