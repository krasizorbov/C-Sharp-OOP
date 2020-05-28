using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizen : IBirthable, IIdentifiable
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
            this.Birthday = birthday;
        }

        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}
