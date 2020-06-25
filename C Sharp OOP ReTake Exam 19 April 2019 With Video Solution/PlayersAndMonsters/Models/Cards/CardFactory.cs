using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class CardFactory
    {
        public Card createCard(string type, string name)
        {
            Card card = null;
            if (type == "Trap")
            {
                card = new TrapCard(name);
            }
            else if (type == "Magic")
            {
                card = new MagicCard(name);
            }
            return card;
        }
    }
}
