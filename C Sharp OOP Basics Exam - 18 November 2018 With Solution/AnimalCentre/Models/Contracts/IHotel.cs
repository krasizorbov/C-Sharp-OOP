using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IHotel
    {
        IReadOnlyDictionary<string, IAnimal> Animals { get; }
        void Adopt(string animalName, string owner);
        void Accommodate(IAnimal animal);
    }
}