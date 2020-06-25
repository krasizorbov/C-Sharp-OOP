using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        List<IPlayer> players;
        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players
        {
            get
            {
                return players.AsReadOnly();
            }
        }

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            else if (players.Contains(player))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            else
            {
                players.Add(player);
            }
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.First(p => p.Username == username);
            return player;
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return players.Remove(player);
        }
    }
}
