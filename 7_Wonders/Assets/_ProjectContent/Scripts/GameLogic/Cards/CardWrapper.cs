﻿using SK_Engine;
using UnityEngine;
using WhiteTeam.GameLogic.Managers;
using WhiteTeam.Network.Entity;

namespace WhiteTeam.GameLogic.Cards
{
    public abstract class CardWrapper<T> : ICard
        where T : CardData
    {
        public T Data;

        protected readonly EventHolder<string> OnErrorEvent = new EventHolder<string>();

        public CardWrapper(T data)
        {
            Data = data;
        }

        protected PlayerData LocalPlayer => GameManager.Instance.CurrentSession.LocalPlayerData;
        
        public abstract void UseRequest();
        public abstract void ActivatedUseRequest();
        public abstract void Use(PlayerData player);
        public abstract void ActivatedUse(PlayerData player);
        public abstract void ActivateEndGameEffect(PlayerData player);

        public IdentifierInfo GetIdentifierInfo() => Data.GetIdentifierInfo();
    }
}