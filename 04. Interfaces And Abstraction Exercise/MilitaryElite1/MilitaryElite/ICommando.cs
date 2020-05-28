using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando :ISpecialisedSoldier
    {
        IReadOnlyCollection<IMission> Missions { get; }
    }
}