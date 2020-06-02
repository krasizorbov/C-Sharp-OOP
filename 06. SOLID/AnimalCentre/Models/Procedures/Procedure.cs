using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected IList<IAnimal> procedureHistory;

        protected Procedure()
        {
            procedureHistory = new List<IAnimal>();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            string[] animalsInfo = procedureHistory
                .OrderBy(a => a.Name).Select(a => a.ToString()).ToArray();
            sb.AppendLine(String.Join(Environment.NewLine, animalsInfo));
            return sb.ToString().TrimEnd();
        }
        public void CheckTime(int time, IAnimal animal)
        {
            if (animal.ProcedureTime >= time)
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
