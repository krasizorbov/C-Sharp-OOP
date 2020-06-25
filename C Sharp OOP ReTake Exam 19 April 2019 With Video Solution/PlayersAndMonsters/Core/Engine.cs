using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private ManagerController managerController;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            managerController = new ManagerController();
        }


        public void Run()
        {
            while (true)
            {
                var command = this.reader.ReadLine();
                if (command == "Exit")
                {
                    break;
                }

                try
                {
                    var commandResult = this.ProcessCommand(command);
                    this.writer.WriteLine(commandResult);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Error: " + e.Message);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }
        private string ProcessCommand(string command)
        {
            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;
            switch (commandName)
            {
                case "AddPlayer":
                    {
                        var type = args[0];
                        var name = args[1];

                        output = this.managerController.AddPlayer(type, name);
                        break;
                    }
                case "AddCard":
                    {
                        var type = args[0];
                        var name = args[1];

                        output = this.managerController.AddCard(type, name);
                        break;
                    }
                case "AddPlayerCard":
                    {
                        var playerName = args[0];
                        var cardName = args[1];

                        output = this.managerController.AddPlayerCard(playerName, cardName);
                        break;
                    }
                case "Fight":
                    {
                        var attackUser = args[0];
                        var enemyUser = args[1];

                        output = this.managerController.Fight(attackUser, enemyUser);
                        break;
                    }
                case "Report":
                    {
                        output = this.managerController.Report();
                        break;
                    }
            }

            return output;

        }
    }
}
