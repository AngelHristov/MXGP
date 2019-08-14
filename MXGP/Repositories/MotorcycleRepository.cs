namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models.Motorcycles.Contracts;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        => motorcycles.Add(model);

        public IReadOnlyCollection<IMotorcycle> GetAll()
        => motorcycles.ToList();

        public IMotorcycle GetByName(string name)
        => motorcycles.FirstOrDefault(x => x.Model == name);

        public bool Remove(IMotorcycle model)
        => motorcycles.Remove(model);
    }
}
