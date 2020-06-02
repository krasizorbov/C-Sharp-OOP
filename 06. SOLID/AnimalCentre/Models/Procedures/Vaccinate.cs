using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        const int removeEnergy = 8;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Energy -= removeEnergy;
            animal.IsVaccinated = true;
            procedureHistory.Add(animal);
        }
    }
}
