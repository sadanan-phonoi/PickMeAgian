using UnityEngine;

namespace PMA.Card
{
    [System.Serializable]
    public class Card
    { 
        [SerializeField] private int cardId;
        [SerializeField] private Sprite cardImage;
        
        public int CardId => cardId;
        public Sprite CardImage => cardImage;
        
        public Card (int cardId,Sprite cardImage)
        {
            this.cardId = cardId;
            this.cardImage = cardImage;
        }
    }
}
