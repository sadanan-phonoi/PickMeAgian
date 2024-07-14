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
        
#if UNITY_EDITOR
        public void OnValidate()
        {
            if(cardSetting == null) return;
            if(stageSetting == null) return;
            if(stageSetting.TotalCard > cardSetting.CardValue*2)
                Debug.LogError(GameText.WARNING_STATE_SETTING 
                               + stageSetting.TotalCard/2
                               + " Current Card Count " + cardSetting.CardValue); 
        }  
#endif
        public void Init()
        {
            foreach (var rule in scoreRule)
            {
                rule.Init();
            }
        }
        public int GetScore(List<PMA.Card.Card> compareCard)
        { 
            var totalScore = 0; 
            foreach (var rule in scoreRule)
            {
                totalScore += rule.Score(compareCard);
            } 
            return totalScore;
        }
        public List<PMA.Card.Card> GetCardDeck()
        {  
            var totalCardOpen = stageSetting.TotalCard / stageSetting.CardCompareValue;
            var cardDeck = new List<PMA.Card.Card>();
            var card = cardSetting.GetCard;
            
            if(totalCardOpen > cardSetting.CardValue*2)
            {
                Debug.LogError(GameText.WARNING_STATE_SETTING 
                               + stageSetting.TotalCard/2
                               + "Current Card Count " + cardSetting.CardValue); 
                return new List<PMA.Card.Card>();
            } 
            for (int i = 0; i < totalCardOpen; i++)
            {
                for (int j = 0; j < stageSetting.CardCompareValue; j++)
                {
                    cardDeck.Add(card[i]);
                }
            } 
            return cardDeck; 
        }
    }
}
