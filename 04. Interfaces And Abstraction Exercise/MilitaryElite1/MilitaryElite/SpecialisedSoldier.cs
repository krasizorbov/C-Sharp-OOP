using System;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        const string c1 = "Airforces";
        const string c2 = "Marines";
        string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps
        {
            get
            {
                return corps;
            }
            private set
            {
                if (value != c1 && value != c2)
                {
                    throw new ArgumentException();
                }
                corps = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine($"Corps: {Corps}");

            return builder.ToString().TrimEnd();
        }
    }
}
