namespace MortalEngines.Core
{
    public interface ICommandInterpreter
    {
        string Read(string[] args);
    }
}