using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{ 
    [CreateAssetMenu(fileName = "New GameStage", menuName = "ScriptableObjects/GameStage")]
    public class GameStage : ScriptableObject
    {
        [SerializeField] private StageSetting stageSetting;
        [SerializeField] private CardSettingSO cardSetting; 
        [SerializeField] private ScoreRule[] scoreRule; 
        public string GetStageName => stageSetting.StageName;
        public StageSetting StageSetting => stageSetting;
        public CardSettingSO CardSetting => cardSetting;
        public ScoreRule[] ScoreRule => scoreRule;
        public void OnValidate()
        {
            if(cardSetting == null) return;
            if(stageSetting.TotalCard > cardSetting.CardValue)
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
        public List<CardSO> GetCardDeck()
        {
            return cardSetting.GetCardDeck(stageSetting);
        }
    }
}
