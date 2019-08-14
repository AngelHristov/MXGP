namespace MXGP.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using MXGP.Core.Contracts;
    using MXGP.Models.Motorcycles;
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Races;
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories;
    using MXGP.Repositories.Contracts;

    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IRider> riders;
        private readonly IRepository<IMotorcycle> motorcycles;
        private readonly IRepository<IRace> races;

        public ChampionshipController()
        {
            riders = new RiderRepository();
            motorcycles = new MotorcycleRepository();
            races = new RaceRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = riders.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException($"Rider {riderName} is already created.");
            }

            rider = new Rider(riderName);

            riders.Add(rider);

            return $"Rider {riderName} is created.";
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riders.GetByName(riderName);
            var motorcycle = motorcycles.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException($"Motorcycle {motorcycleModel} could not be found.");
            }

            rider.AddMotorcycle(motorcycle);

            return $"Rider {riderName} received motorcycle {motorcycleModel}.";
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = riders.GetByName(riderName);
            var race = races.GetByName(raceName);

            if (rider == null)
            {
                throw new InvalidOperationException($"Rider {riderName} could not be found.");
            }
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            race.AddRider(rider);

            return $"Rider {riderName} added in {raceName} race.";
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var motorcycle = motorcycles.GetByName(model);

            if (motorcycle != null)
            {
                throw new ArgumentException($"Motorcycle {model} is already created.");
            }

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }
            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }

            motorcycles.Add(motorcycle);

            return $"{motorcycle.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var race = races.GetByName(name);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already created.");
            }

            race = new Race(name, laps);

            races.Add(race);

            return $"Race {name} is created.";
        }


        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var riders = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rider {riders[0].Name} wins {raceName} race.");
            sb.AppendLine($"Rider {riders[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Rider {riders[2].Name} is third in {raceName} race.");

            races.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
