using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public interface ICommand
    {
        string Execute(string[] args);
    }
}
