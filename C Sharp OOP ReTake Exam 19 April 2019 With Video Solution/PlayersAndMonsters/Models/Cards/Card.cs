using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        string name;
        int damagePoints;
        int healthPoints;
        public Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string.");
                }
                name = value;
            }
        }

        public int DamagePoints
        {
            get
            {
                return damagePoints;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return healthPoints;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }
                healthPoints = value;
            }
        }
    }
}
