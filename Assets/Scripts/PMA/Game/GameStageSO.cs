using System.Collections.Generic;
using PMA.Card;
using PMA.Enum;
using UnityEngine;

namespace PMA.Game
{ 
    [CreateAssetMenu(fileName = "New GameStageSO", menuName = "ScriptableObjects/GameStageSO")]
    public class GameStageSO : ScriptableObject
    {
        [SerializeField] private GameEnum.EDifficultyLevel stageDifficulty;
        [SerializeField] private CardSettingSO cardSetting;
        [SerializeField] private StageSetting stageSetting;
        [SerializeField] private ScoreRule[] scoreRule; 
        public GameEnum.EDifficultyLevel StageDifficulty => stageDifficulty;
        public string GetStageName => stageSetting.StageName;
        public CardSettingSO CardSetting => cardSetting;
        public StageSetting StageSetting => stageSetting;
        public ScoreRule[] ScoreRule => scoreRule;
        public void OnValidate()
        {
            if(cardSetting == null) return;
            if(stageSetting == null) return;
            if(stageSetting.TotalCard > cardSetting.CardValue)
                Debug.LogError(GameText.WARNING_STATE_SETTING); 
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
            var totalCardOpen = stageSetting.TotalCard / stageSetting.CardCompareValue;
            var cardDeck = new List<CardSO>();
            var card = cardSetting.GetCard;
            
            if(totalCardOpen > cardSetting.CardValue)
            {
                Debug.LogError(GameText.WARNING_STATE_SETTING); 
                return new List<CardSO>();
            } 
            for (int i = 0; i < totalCardOpen; i++)
            {
                cardDeck.Add(card[i]);
                cardDeck.Add(card[i]); 
            } 
            return cardDeck; 
        }
    }
}
