using System.Collections.Generic; 
using PMA.Game;
using UnityEngine;

namespace PMA.Card
{
    [CreateAssetMenu(fileName = "New CardSettingSO", menuName = "ScriptableObjects/CardSettingSO")]
    public class CardSettingSO : ScriptableObject
    {
        [SerializeField] private Sprite backCard;
        [SerializeField] private CardSO[] card; 
        public int CardValue => card.Length*2;
        public Sprite BackCard => backCard;
        public List<CardSO> GetCardDeck(StageSetting stageSetting)
        {
            var cardOpen = stageSetting.TotalCard / stageSetting.CardCompareValue;
            var cardDeck = new List<CardSO>();
            
            if(cardOpen > CardValue)
            {
                Debug.LogError("StageSetting X Y CardCompareValue is not match with cardSetting");
                return new List<CardSO>();
            } 
            for (int i = 0; i < cardOpen; i++)
            {
                cardDeck.Add(card[i]);
                cardDeck.Add(card[i]);
                Debug.Log("Add " + card[i].CardId);
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
