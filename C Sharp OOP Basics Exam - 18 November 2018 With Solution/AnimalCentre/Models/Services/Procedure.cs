using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AnimalCentre.Models.Services
{
    public abstract class Procedure : IProcedure
    {
        protected IList<IAnimal> procedureHistory;

        protected Procedure()
        {
            this.procedureHistory = new List<IAnimal>();
        }
        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            
            string[] animalsInfo = procedureHistory
                    .OrderBy(a => a.Name)
                   .Select(a => a.ToString())
                   .ToArray();

            sb.AppendLine(string.Join(Environment.NewLine, animalsInfo));

            string result = sb.ToString().TrimEnd();
            return result;
        }

        public abstract void DoService(IAnimal animal, int procedureTime);
        protected void CheckTime(int time, IAnimal animal)
        {
            if (time <= animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }

    }
}
