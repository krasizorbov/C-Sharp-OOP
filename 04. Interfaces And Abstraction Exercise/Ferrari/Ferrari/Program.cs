using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string model = "488-Spider";
            Ferrari f = new Ferrari(name);
            Console.WriteLine($"{model}/{f.Brakes()}/{f.Gas()}/{f.Name}");
           }
    }
}
