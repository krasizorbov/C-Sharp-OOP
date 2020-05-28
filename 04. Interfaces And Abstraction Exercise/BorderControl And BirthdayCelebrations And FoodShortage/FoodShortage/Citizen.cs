using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBirthable, IIdentifiable, IBuyer
    {
        private string name;
        private int age;

        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public string Name { get; private set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
