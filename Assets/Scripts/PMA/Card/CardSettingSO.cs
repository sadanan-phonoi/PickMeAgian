using System.Collections.Generic; 
using PMA.Game;
using UnityEngine;

namespace PMA.Card
{
    [CreateAssetMenu(fileName = "New CardSettingSO", menuName = "ScriptableObjects/CardSettingSO")]
    public class CardSettingSO : ScriptableObject
    {
        [SerializeField] private CardSO[] card; 
        public int CardValue => card.Length;

        public List<CardSO> GetCardDeck(StageSetting stageSetting)
        {
            var totalCard = stageSetting.TotalCard;
            var cardDeck = new List<CardSO>();
            
            if(totalCard>CardValue)
            {
                Debug.LogError("StageSetting X Y CardCompareValue is not match with cardSetting");
                return new List<CardSO>();
            } 
            for (int i = 0; i < totalCard; i++)
            {
                cardDeck.Add(card[i]);
            } 
            return cardDeck;
        }

        public void OnValidate()
        {
            foreach (var c in card)
            {
                if(c.CardId == 0)
                    Debug.LogError("Card Id Not Set");
            }
        }
    }
}
