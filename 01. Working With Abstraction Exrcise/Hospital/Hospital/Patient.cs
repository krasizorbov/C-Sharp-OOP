using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Patient
    {
        public string Name { get;private set; }
        public Patient(string name)
        {
            Name = name;
        }
    }
}
