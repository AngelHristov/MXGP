namespace MXGP.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts;

    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riders;

        public RiderRepository()
        {
            riders = new List<IRider>();
        }

        public void Add(IRider model)
        => riders.Add(model);

        public IReadOnlyCollection<IRider> GetAll()
        => riders.ToList();

        public IRider GetByName(string name)
        => riders.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRider model)
        => riders.Remove(model);
    }
}
