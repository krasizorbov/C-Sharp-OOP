using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities
{
    public abstract class Animal : IAnimal
    {
        string name;
        int happiness;
        int energy;
        int procedureTime;
        string owner = "Centre";
        bool isAdopt;
        bool isChipped;
        bool isVaccinated;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }

        public string Name { get => name; set => name = value; }

        public int Happiness
        {
            get
            {
                return happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }

        public int ProcedureTime { get => procedureTime; set => procedureTime = value; }
        public string Owner { get => owner; set => owner = value; }

        public bool IsAdopt { get => isAdopt; set => isAdopt = value; }

        public bool IsChipped { get => isChipped; set => isChipped = value; }

        public bool IsVaccinated { get => isVaccinated; set => isVaccinated = value; }
        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}
