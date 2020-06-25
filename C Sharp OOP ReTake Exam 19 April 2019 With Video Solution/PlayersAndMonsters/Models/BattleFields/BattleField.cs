using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public BattleField()
        {
        }

        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            CheckForBeginners(attackPlayer, enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Sum(c => c.HealthPoints);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
            }
        }

        private void CheckForBeginners(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType() == typeof(Beginner))
            {
                attackPlayer.Health += 40;

                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            if (enemyPlayer.GetType() == typeof(Beginner))
            {
                enemyPlayer.Health += 40;

                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
