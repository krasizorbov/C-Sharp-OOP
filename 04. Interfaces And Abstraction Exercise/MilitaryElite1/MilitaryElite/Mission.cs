using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission : IMission
    {
        const string c1 = "inProgress";
        const string c2 = "Finished";
        string state;
        public Mission(string codeName, string state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get
            {
                return state;
            }

            private set
            {
                if (value != c1 && value != c2)
                {
                    throw new ArgumentException();
                }

                state = value;
            }
        }

        public void CompleteMission()
        {
            state = c2;
        }

        public override string ToString()
        {
            return $"  Code Name: {CodeName} State: {State}";
        }
    }
}
