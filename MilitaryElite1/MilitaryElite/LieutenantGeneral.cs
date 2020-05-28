using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILeutenantGeneral
    {
        List<Private> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName,salary)
        {
            privates = new List<Private>();
        }
        public IReadOnlyCollection<IPrivate> Privates
        {
            get
            {
                return privates;
            }
        }
        public void AddPrivate(Private newPrivate)
        {
            privates.Add(newPrivate);
        }
        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var current in privates)
            {
                builder.AppendLine("  " + current.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
