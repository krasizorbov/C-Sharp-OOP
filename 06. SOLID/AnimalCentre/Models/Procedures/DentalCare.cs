using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class DentalCare : Procedure
    {
        const int addHappiness = 12;
        const int addEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Happiness += addHappiness;
            animal.Energy += addEnergy;
            procedureHistory.Add(animal);
        }
    }
}
