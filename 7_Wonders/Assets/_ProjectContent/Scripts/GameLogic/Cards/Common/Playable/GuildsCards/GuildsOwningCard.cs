﻿using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class GuildsOwningCard : GuildsCard<CardTypeOwnVictoryEffect, CardTypeOwnVictoryEffect>
    {
        public GuildsOwningCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, CardTypeOwnVictoryEffect currentEffect)
            : base(id, name, type, epoch, costInfo, requirementBuildCardId, currentEffect)
        {
        }

        protected override IVisualizer CreateVisualizer() => new GuildsOwningVisualizer(this);
         protected override IWonderVisualizer CreateIwonderVisualizer()
        {
            throw new System.NotImplementedException();
        }
       
    }
}