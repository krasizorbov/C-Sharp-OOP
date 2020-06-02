using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        const int removeHappiness = 3;
        const int addEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Happiness -= removeHappiness;
            animal.Energy += addEnergy;
            procedureHistory.Add(animal);
        }
    }
}
