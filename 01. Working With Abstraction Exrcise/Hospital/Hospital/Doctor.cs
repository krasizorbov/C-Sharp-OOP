using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class Doctor
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public List<Patient> Patients { get; private set; }
        public Doctor(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
            Patients = new List<Patient>();
        }
        public void AddPatient(Patient patient)
        {
            Patients.Add(patient);
        }
        public string GetPatients()
        {
            return String.Join(Environment.NewLine, Patients.Select(p => p.Name).OrderBy(p => p));
        }
    }
}
