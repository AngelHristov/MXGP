namespace MXGP.Models.Motorcycles
{
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double Cubic_Centimeters = 125;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            :base(model, horsePower, Cubic_Centimeters)
        {
            HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                horsePower = value;
            }
        }
    }
}
