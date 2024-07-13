using UnityEngine;

namespace PMA.Card
{
    [System.Serializable]
    public class CardSO
    {
        [SerializeField] private int cardId;
        [SerializeField] private Sprite cardImage;
        
        public int CardId => cardId;
        public Sprite CardImage => cardImage;
    }
}
