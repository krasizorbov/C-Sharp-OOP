using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        readonly IList<IMotorcycle> motorcycles;
        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            motorcycles.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return motorcycles.ToList();
        }

        public IMotorcycle GetByName(string name)
        {
            return motorcycles.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IMotorcycle model)
        {
            return motorcycles.Remove(model);
        }
    }
}
