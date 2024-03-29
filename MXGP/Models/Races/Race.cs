﻿namespace MXGP.Models.Races
{
    using Contracts;
    using Riders.Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private readonly List<IRider> riders;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;

            riders = new List<IRider>();
        }

        public IReadOnlyCollection<IRider> Riders => riders.AsReadOnly();

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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Laps cannot be less than 1.");
                }

                laps = value;
            }
        }

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }
            if (rider.CanParticipate == false)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            if (riders.Any(x => x.Name == rider.Name)) 
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {Name} race.");
            }

            riders.Add(rider);
        }
    }
}
