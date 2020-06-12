using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Services.Procedures
{
    public class Play : Procedure
    {
        private const int RemoveEnergy = 6;
        private const int AddHappiness = 12;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += AddHappiness;
            animal.Energy -= RemoveEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}
