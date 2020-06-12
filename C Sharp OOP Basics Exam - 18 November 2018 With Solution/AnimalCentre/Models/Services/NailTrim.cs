using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Services.Procedures
{
    public class NailTrim : Procedure
    {
        private const int RemoveHappiness = 7;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness -= RemoveHappiness;
            base.procedureHistory.Add(animal);
        }
    }
}
