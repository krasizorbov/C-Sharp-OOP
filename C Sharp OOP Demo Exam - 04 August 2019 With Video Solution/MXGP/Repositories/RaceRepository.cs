using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        readonly IList<IRace> motorcycles;
        public RaceRepository()
        {
            motorcycles = new List<IRace>();
        }
        public void Add(IRace model)
        {
            motorcycles.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return motorcycles.ToList();
        }

        public IRace GetByName(string name)
        {
            return motorcycles.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IRace model)
        {
            return motorcycles.Remove(model);
        }
    }
}
