using MXGP.Core.Contracts;
using MXGP.IO.Contracts;
using MXGP.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ChampionshipController chshcon;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            chshcon = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var command = this.reader.ReadLine();
                if (command == "End")
                {
                    break;
                }

                try
                {
                    var commandResult = ProcessCommand(command);
                    this.writer.WriteLine(commandResult);
                }
                catch (ArgumentException e)
                {
                    writer.WriteLine(e.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    writer.WriteLine(ioe.Message);
                }
            }

            string ProcessCommand(string command)
            {
                var commandArgs = command.Split(' ');
                var commandName = commandArgs[0];
                var args = commandArgs.Skip(1).ToArray();

                var output = string.Empty;
                switch (commandName)
                {
                    case "CreateRider":
                        {
                            var name = args[0];

                            output = chshcon.CreateRider(name);
                            break;
                        }
                    case "CreateMotorcycle":
                        {
                            var type = args[0];
                            var name = args[1];
                            var horsePower = int.Parse(args[2]);
                            output = chshcon.CreateMotorcycle(type, name, horsePower);
                            break;
                        }
                    case "AddMotorcycleToRider":
                        {
                            var riderName = args[0];
                            var motorcycleModel = args[1];

                            output = chshcon.AddMotorcycleToRider(riderName, motorcycleModel);
                            break;
                        }
                    case "CreateRace":
                        {
                            var raceName = args[0];
                            var laps = int.Parse(args[1]);

                            output = chshcon.CreateRace(raceName, laps);
                            break;
                        }
                    case "AddRiderToRace":
                        {
                            var raceName = args[0];
                            var riderName = args[1];

                            output = chshcon.AddRiderToRace(raceName, riderName);
                            break;
                        }
                    case "StartRace":
                        {
                            var raceName = args[0];

                            output = chshcon.StartRace(raceName);
                            break;
                        }
                }

                return output;
            }
        }
    }
}
