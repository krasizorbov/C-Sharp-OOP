using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackofStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }
        public Stack<string> AddRange()
        {
            this.Push();
            return this;
        }
    }
}
