﻿using System.Collections.Generic;
using System.Linq;
using WhiteTeam.GameLogic.Cards.Wonder;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public class CardsStack : Singleton<CardsStack>
    {
        private readonly List<WonderCard> _wonderCards = new List<WonderCard>();
        private readonly List<CommonCard> _cards = new List<CommonCard>();

        private readonly List<CommonCard> _thrownCards = new List<CommonCard>();

        public List<WonderCard> WonderCards => _wonderCards;
        public List<CommonCard> CommonCards => _cards;

        public void LoadWonderCards(IEnumerable<WonderCardData> cards)
        {
            foreach (var cardData in cards)
            {
                var card = CardCreator.Create(cardData);
                _wonderCards.Add(card);
            }
        }

        public void LoadCards(IEnumerable<CommonCardData> cards)
        {
            foreach (var cardData in cards)
            {
                var card = CardCreator.Create(cardData);
                _cards.Add(card);
            }
        }

        #region Wonder cards

        public IEnumerable<WonderCard> GetWonderCards(IEnumerable<string> cardsId)
        {
            return cardsId.Select(GetWonderCard);
        }

        public WonderCard GetWonderCard(string id)
        {
            NetworkEntity.FindEntityById(_wonderCards, id, out var card);
            return card;
        }

        #endregion

        #region Common cards

        public IEnumerable<CommonCard> GetCards(IEnumerable<string> cardsId)
        {
            return cardsId.Select(GetCard);
        }

        public CommonCard GetCard(string id)
        {
            NetworkEntity.FindEntityById(_cards, id, out var card);
            return card;
        }

        public void ThrowCard(CommonCard card)
        {
            _thrownCards.Add(card);
        }

        public IEnumerable<CommonCard> GetThrownCards()
        {
            return _thrownCards;
        }

        #endregion
    }
}