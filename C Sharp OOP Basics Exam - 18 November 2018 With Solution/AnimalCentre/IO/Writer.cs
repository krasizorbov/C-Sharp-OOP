using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.IO
{
    public class Writer : IWriter
    {
        private StringBuilder sb;

        public Writer()
        {
            this.sb = new StringBuilder();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Flush()
        {
            Console.WriteLine(sb.ToString().Trim());
        }
    }
}
