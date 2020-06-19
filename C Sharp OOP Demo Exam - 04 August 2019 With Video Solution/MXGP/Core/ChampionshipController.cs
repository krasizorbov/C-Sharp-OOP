using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        readonly IRepository<IRider> riderRepository;
        readonly IRepository<IMotorcycle> motorcycleRepository;
        readonly IRepository<IRace> raceRepository;

        public ChampionshipController()
        {
            riderRepository = new RiderRepository();
            motorcycleRepository = new MotorcycleRepository();
            raceRepository = new RaceRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            IRider rider = riderRepository.GetByName(riderName);
            IMotorcycle motorcycle = motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);
            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            IRace race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            IRider rider = riderRepository.GetByName(riderName);
            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            race.AddRider(rider);
            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            IMotorcycle motorcycle = motorcycleRepository.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }
            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            motorcycleRepository.Add(motorcycle);
            return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            IRace race = raceRepository.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }
            race = new Race(name, laps);
            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string CreateRider(string riderName)
        {
            IRider rider = riderRepository.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);

            riderRepository.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var riders = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3).ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            raceRepository.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
