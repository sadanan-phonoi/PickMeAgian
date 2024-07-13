using System;
using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{ 
    [CreateAssetMenu(fileName = "New GameMode", menuName = "ScriptableObjects/GameMode")]
    public class GameMode : ScriptableObject
    {
        [SerializeField] private GameSetting gameSetting;
        [SerializeField] private CardSettingSO cardSetting; 
        [SerializeField] private ScoreRule[] scoreRule; 
        public void OnValidate()
        {
            if(cardSetting == null) return;
            if(gameSetting.TotalCard > cardSetting.CardValue)
                Debug.LogError("GameSetting X Y CardCompareValue is not match with cardSetting");
        }

        public void Init()
        {
            foreach (var rule in scoreRule)
            {
                rule.Init();
            }
        }
        public int GetScore(List<CardSO> compareCard)
        {
            var totalScore = 0; 
            foreach (var rule in scoreRule)
            {
                totalScore += rule.Score(compareCard);
            } 
            return totalScore;
        }
    }
}
