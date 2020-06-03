using System;
using System.Collections.Generic;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Entities
{
    public class Person
    {
        const int minAge = 12;
        const int maxAge = 90;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(minAge, maxAge)]
        public int Age { get; private set; }
    }
}
