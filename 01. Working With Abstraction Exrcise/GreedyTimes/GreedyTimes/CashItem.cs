using System;
using System.Collections.Generic;
using System.Text;

namespace GreedyTimes
{
    public class CashItem : Item
    {
        public CashItem(string key, long value)
        {
            Key = key;
            Value = value;
        }
    }
}
