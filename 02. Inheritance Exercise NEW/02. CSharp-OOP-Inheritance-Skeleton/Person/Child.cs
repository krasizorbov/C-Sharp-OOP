using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age) : base(name, age)
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
