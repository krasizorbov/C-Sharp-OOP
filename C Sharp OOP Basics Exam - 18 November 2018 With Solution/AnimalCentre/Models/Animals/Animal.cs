using AnimalCentre.Models.Contracts;
using System;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner = "Centre";
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Happiness
        {
            get { return happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        public int Energy
        {
            get { return energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }
        public int ProcedureTime
        {
            get { return procedureTime; }
            set
            {
                procedureTime = value;
            }
        }
        public bool IsAdopt
        {
            get { return isAdopt; }
            set { isAdopt = value; }
        }

        public bool IsChipped
        {
            get { return isChipped; }
            set {isChipped = value; }
        }
        public bool IsVaccinated
        {
            get { return isVaccinated; }
            set { isVaccinated = value; }
        }
        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}
