using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Hospital
{
    class Program
    {
        private static List<Department> departments = new List<Department>();
        private static List<Doctor> doctors = new List<Doctor>();
        static void Main(string[] args)
        {
            while (true)
            {
                string[] arr = Console.ReadLine().Split().ToArray();
                if (arr[0] == "Output")
                {
                    break;
                }
                
                string departmentName = arr[0];
                string doctorFirstName = arr[1];
                string doctorSecondName = arr[2];
                string patientName = arr[3];

                if (!departments.Any(d => d.Name == departmentName))
                {
                    departments.Add(new Department(departmentName));
                }

                Patient patient = new Patient(patientName);
                var department = departments.FirstOrDefault(d => d.Name == departmentName);
                department.AddPatientToRoom(patient);

                if (!doctors.Any(d => d.FirstName == doctorFirstName && d.SecondName == doctorSecondName))
                {
                    doctors.Add(new Doctor(doctorFirstName, doctorSecondName));
                }

                var doctor = doctors.FirstOrDefault(d => d.FirstName == doctorFirstName && d.SecondName == doctorSecondName);

                doctor.AddPatient(patient);
            }
            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "End")
                {
                    break;
                }
                int length = command.Length;
                if (length == 1)
                {
                    string departmentName = command[0];
                    Console.WriteLine(departments.Single(d => d.Name == departmentName).GetAllPatients());
                }
                
                else if (length == 2)
                {
                    if (command[1].All(Char.IsDigit))
                    {
                        string departmentName = command[0];
                        int roomNumber = int.Parse(command[1]);

                        Console.WriteLine(departments.Single(d => d.Name == departmentName).GetPatientsByRoom(roomNumber));
                    }
                    else
                    {
                        string doctorFirstName = command[0];
                        string doctorLastName = command[1];

                        Console.WriteLine(doctors.Single(d => d.FirstName == doctorFirstName && d.SecondName == doctorLastName).GetPatients());
                    }
                }
            }
        }
    }
}
