namespace MXGP.Core.Contracts
{
    using MXGP.IO;
    using System;

    public class Engine : IEngine
    {
        private ChampionshipController controler;
        private ConsoleReader consoleReader;
        private ConsoleWriter consoleWriter;

        public Engine()
        {
            controler = new ChampionshipController();
            consoleReader = new ConsoleReader();
            consoleWriter = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                string line = consoleReader.ReadLine();
                string[] input = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];

                if (command == "End")
                {
                    break;
                }

                switch (command)
                {
                    case "CreateRider":
                        {
                            string name = input[1];

                            consoleWriter.WriteLine(controler.CreateRider(name));
                            break;
                        }
                    case "CreateMotorcycle":
                        {
                            string motorcycleType = input[1];
                            string model = input[2];
                            int horsePower = int.Parse(input[3]);

                            consoleWriter.WriteLine(controler.CreateMotorcycle(motorcycleType, model, horsePower));
                            break;
                        }
                    case "AddMotorcycleToRider":
                        {
                            string riderName = input[1];
                            string motorcycleName = input[2];

                            consoleWriter.WriteLine(controler.AddMotorcycleToRider(riderName, motorcycleName));
                            break;
                        }
                    case "AddRiderToRace":
                        {
                            string raceName = input[1];
                            string riderName = input[2];

                            consoleWriter.WriteLine(controler.AddRiderToRace(raceName, riderName));
                            break;
                        }
                    case "CreateRace":
                        {
                            string name = input[1];
                            int laps = int.Parse(input[2]);

                            consoleWriter.WriteLine(controler.CreateRace(name, laps));
                            break;
                        }
                    case "StartRace":
                        {
                            string raceName = input[1];

                            consoleWriter.WriteLine(controler.StartRace(raceName));
                            break;
                        }
                    default:
                        Console.WriteLine("error");
                        break;
                }
            }
        }
    }
}
