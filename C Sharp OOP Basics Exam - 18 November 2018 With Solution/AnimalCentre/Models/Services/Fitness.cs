using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Services.Procedures
{
    public class Fitness : Procedure
    {
        private const int RemoveHappiness = 3;
        private const int AddEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness -= RemoveHappiness;
            animal.Energy += AddEnergy;
            base.procedureHistory.Add(animal);
        }
    }
}
