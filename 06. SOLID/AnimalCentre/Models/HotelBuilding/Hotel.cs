using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Models.HotelBuilding
{
    public class Hotel : IHotel
    {
        int capacity;
        Dictionary<string, IAnimal> animals;
        public Hotel()
        {
            animals = new Dictionary<string, IAnimal>();
            capacity = 10;
        }
        public IReadOnlyDictionary<string, IAnimal> Animals
        {
            get => new ReadOnlyDictionary<string, IAnimal>(this.animals);
        }

        public void Accommodate(IAnimal animal)
        {
            if (capacity <= 0)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            else
            {
                animals.Add(animal.Name, animal);
                capacity--;
            }
        }
        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            else
            {
                IAnimal animal = animals[animalName];
                animal.IsAdopt = true;
                animals.Remove(animalName);
                capacity++;
            }
        }
    }
}
