namespace MXGP.Models.Motorcycles    
{
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private const double Cubic_Centimeters = 450;

        private int horsePower;

        public PowerMotorcycle(string model, int horsePower)
            :base(model, horsePower, Cubic_Centimeters)
        {
            HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }
    }
}
