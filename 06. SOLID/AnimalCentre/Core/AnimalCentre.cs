using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities;
using AnimalCentre.Models.HotelBuilding;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        IHotel hotel;
        private Dictionary<string, List<string>> adoptedAnimals;
        private IDictionary<string, IProcedure> services;
        public AnimalCentre()
        {
            hotel = new Hotel();
            services = new Dictionary<string, IProcedure>();
            this.adoptedAnimals = new Dictionary<string, List<string>>();
            InitializeServices();
        }
        private void InitializeServices()
        {
            services.Add("Chip", new Chip());
            services.Add("DentalCare", new DentalCare());
            services.Add("Fitness", new Fitness());
            services.Add("NailTrim", new NailTrim());
            services.Add("Play", new Play());
            services.Add("Vaccinate", new Vaccinate());
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            IAnimal newAnimal = null;
            switch (type)
            {
                case "Lion":
                    newAnimal = new Lion(name, energy, happiness, procedureTime);
                    break;
                case "Dog":
                    newAnimal = new Dog(name, energy, happiness, procedureTime);
                    break;
                case "Pig":
                    newAnimal = new Pig(name, energy, happiness, procedureTime);
                    break;
                case "Cat":
                    newAnimal = new Cat(name, energy, happiness, procedureTime);
                    break;
                default:
                    break;
            }
            hotel.Accommodate(newAnimal);
            return $"Animal {name} registered successfully";
        }

        private void CheckAnimalExists(IAnimal animal)
        {
            if (animal == null)
            {
                throw new ArgumentException("Current animal does not exist");
            }
        }
        public string Chip(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];
            CheckAnimalExists(currentAnimal);
            services["Chip"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had chip procedure";
        }


        public string Vaccinate(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];
            this.CheckAnimalExists(currentAnimal);
            services["Vaccinate"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];
            this.CheckAnimalExists(currentAnimal);
            services["Fitness"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];
            this.CheckAnimalExists(currentAnimal);
            services["Play"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];
            this.CheckAnimalExists(currentAnimal);
            services["DentalCare"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            var animals = hotel.Animals;
            var currentAnimal = animals[name];
            this.CheckAnimalExists(currentAnimal);
            services["NailTrim"].DoService(currentAnimal, procedureTime);
            return $"{currentAnimal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string ownerName)
        {
            var animal = hotel.Animals[animalName];
            hotel.Adopt(animalName, ownerName);
            if (!adoptedAnimals.ContainsKey(ownerName))
            {
                adoptedAnimals.Add(ownerName, new List<string>());
                adoptedAnimals[ownerName].Add(animalName);
            }
            else
            {
                adoptedAnimals[ownerName].Add(animalName);
            }

            return animal.IsChipped == true ? $"{ownerName} adopted animal with chip" : $"{ownerName} adopted animal without chip";
        }

        public string History(string procedureType)
        {
            string output = string.Empty;
            switch (procedureType)
            {
                case "Chip":
                    output = services["Chip"].History();
                    break;
                case "DentalCare":
                    output = services["DentalCare"].History();
                    break;
                case "Play":
                    output = services["Play"].History();
                    break;
                case "Vaccinate":
                    output = services["Vaccinate"].History();
                    break;
                case "Fitness":
                    output = services["Fitness"].History();
                    break;
                case "NailTrim":
                    output = services["NailTrim"].History();
                    break;
                default:
                    break;
            }
            return output;
        }
        public string AdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in adoptedAnimals.OrderBy(a => a.Key))
            {
                sb.AppendLine($"--Owner: {item.Key}");
                sb.AppendLine("    - Adopted animals: " + string.Join(" ", item.Value));

            }
            string result = sb.ToString();
            return result;
        }
    }
}
