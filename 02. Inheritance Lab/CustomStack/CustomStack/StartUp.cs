using System;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackofStrings st = new StackofStrings();
            st.AddRange("krasi");
            Console.WriteLine($"{string.Join(" ", st)}");
        }
    }
}
