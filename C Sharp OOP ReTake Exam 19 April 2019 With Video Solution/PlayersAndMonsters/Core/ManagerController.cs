namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;
        private PlayerFactory playerFactory;
        private CardFactory cardFactory;
        private IBattleField battleField;
        public ManagerController()
        {
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();
            battleField = new BattleField();
        }


        public string AddPlayer(string type, string username)
        {

            if (playerRepository.Players.Any(p => p.Username == username))
            {
                throw new ArgumentException($"Player {username} already exists!");
            }

            var player = playerFactory.CreatePlayer(type, username);

            playerRepository.Add(player);

            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            if (cardRepository.Cards.Any(c => c.Name == name))
            {
                throw new ArgumentException($"Card {name} already exists!");
            }

            var card = cardFactory.createCard(type, name);

            cardRepository.Add(card);
            
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer player = this.playerRepository.Players.FirstOrDefault(p => p.Username == username);
            ICard card = this.cardRepository.Cards.FirstOrDefault(c => c.Name == cardName);

            player.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Players.FirstOrDefault(p => p.Username == attackUser);
            IPlayer enemyPlayer = this.playerRepository.Players.FirstOrDefault(p => p.Username == enemyUser);

            battleField.Fight(attackPlayer, enemyPlayer);
            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                sb.AppendLine("###");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
