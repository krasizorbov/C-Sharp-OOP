using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class PlayerFactory
    {
        public Player CreatePlayer(string type, string username)
        {
            Player player = null;
            if (type == "Beginner")
            {
                ICardRepository cardRepository = new CardRepository();
                player = new Beginner(cardRepository, username);
            }
            else if (type == "Advanced")
            {
                ICardRepository cardRepository = new CardRepository();
                player = new Advanced(cardRepository, username);
            }
            return player;
        }
    }
}
