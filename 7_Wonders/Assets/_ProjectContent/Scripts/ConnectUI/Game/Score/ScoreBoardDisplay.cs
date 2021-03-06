﻿using System.Linq;
using UnityEngine;
using WhiteTeam.GameLogic;

namespace WhiteTeam.ConnectingUI
{
    public class ScoreBoardDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject scoreBoardHolder;
        [SerializeField] private Transform scoreBoardElementsHolder;
        [SerializeField] private GameObject scoreBoardElement;

        public void Show(ScoreHandler.ScoreBoard scoreBoard)
        {
            Clear();

            // Add winner
            AddElement(scoreBoard.Elements.First(), true);

            // Add others
            foreach (var scoreData in scoreBoard.Elements.Skip(1))
            {
                AddElement(scoreData);
            }

            scoreBoardHolder.SetActive(true);
        }

        public void Close()
        {
            scoreBoardHolder.SetActive(false);
        }

        private void AddElement(ScoreHandler.ScoreData scoreData, bool isWinner = false)
        {
            var scoreElementObject = Instantiate(scoreBoardElement, scoreBoardElementsHolder);
            var scoreElementLogic = scoreElementObject.GetComponentInChildren<ScoreElement>();

            scoreElementLogic.Setup(scoreData);

            if (isWinner)
            {
                scoreElementLogic.SetupWinner();
            }
        }

        private void Clear()
        {
            for (var i = 0; i < scoreBoardElementsHolder.childCount; i++)
            {
                Destroy(scoreBoardElementsHolder.GetChild(i).gameObject);
            }
        }
    }
}