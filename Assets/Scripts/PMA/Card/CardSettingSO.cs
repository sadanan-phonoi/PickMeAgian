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

        public List<CardSO> GetCardDeck(GameSetting gameSetting)
        {
            var totalCard = (gameSetting.CardValueX * gameSetting.CardValueY)/gameSetting.CardCompareValue;
            List<CardSO> cardDeck = new List<CardSO>();
            
            if(totalCard>CardValue)
            {
                Debug.Log("GameSetting X Y CardCompareValue is not match");
                return new List<CardSO>();
            } 
            for (int i = 0; i < totalCard; i++)
            {
                cardDeck.Add(card[i]);
            } 
            return cardDeck;
        }
    }
}
