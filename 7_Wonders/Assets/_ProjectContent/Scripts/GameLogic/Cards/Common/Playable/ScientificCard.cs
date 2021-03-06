﻿using WhiteTeam.GameLogic.Cards.Effects;
using WhiteTeam.GameLogic.Cards.Visualization;
using WhiteTeam.GameLogic.Resources;

namespace WhiteTeam.GameLogic.Cards
{
    public class ScientificCard : SpecialCard<ScienceEffect>
    {
        public ScientificCard(string id, string name, CardType type, int epoch, Resource.CurrencyItem[] costInfo,
            string requirementBuildCardId, ScienceEffect currentEffect) : base(id, name, type, epoch, costInfo,
            requirementBuildCardId, currentEffect)
        {
        }

        protected override IVisualizer CreateVisualizer()=> new ScientificVisualizer(this);
         protected override IWonderVisualizer CreateIwonderVisualizer()
        {
            throw new System.NotImplementedException();
        }
       
    }
}