using System;
using System.Collections.Generic;
using System.Linq;


namespace FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new List<Team>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                var input = command.Split(';');

                try
                {
                    if (input[0] == "Team")
                    {
                        teams.Add(new Team(input[1]));
                    }
                    else if (input[0] == "Add")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == input[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {input[1]} does not exist.");
                        }

                        var player = new Player(input[2], int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]));

                        team.AddPlayer(player);
                    }
                    else if (input[0] == "Remove")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == input[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {input[1]} does not exist.");
                        }

                        team.RemovePlayer(input[2]);
                    }
                    else if (input[0] == "Rating")
                    {
                        var team = teams.FirstOrDefault(t => t.Name == input[1]);
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {input[1]} does not exist.");
                        }

                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
