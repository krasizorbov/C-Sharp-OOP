using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        List<ICard> cards;
        public CardRepository()
        {
            cards = new List<ICard>();
        }

        public int Count => cards.Count;

        public IReadOnlyCollection<ICard> Cards
        {
            get
            {
                return cards.AsReadOnly();
            }
        }

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            else if (cards.Contains(card))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            else
            {
                cards.Add(card);
            }
        }

        public ICard Find(string name)
        {
            ICard card = cards.First(c => c.Name == name);
            return card;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null");
            }
            return cards.Remove(card);
        }
    }
}
