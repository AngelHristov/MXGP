namespace MXGP.Models.Riders
{
    using Contracts;
    using Motorcycles.Contracts;

    using System;

    public class Rider : IRider
    {
        private string name;

        public Rider(string name)
        {
            Name = name;
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => Motorcycle != null;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            Motorcycle = motorcycle ?? throw new ArgumentNullException("Motorcycle cannot be null.");
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
