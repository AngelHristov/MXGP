namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }

        public void Add(IRace model)
        => races.Add(model);

        public IReadOnlyCollection<IRace> GetAll()
        => races.ToList();

        public IRace GetByName(string name)
        => races.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRace model)
        => races.Remove(model);
    }
}
