using PMA.Card;
using UnityEngine;
using UnityEngine.Serialization;

namespace PMA.Player
{
    [System.Serializable]
    public class CardInfo
    {
       [FormerlySerializedAs("cardSo")] [SerializeField] private Card.Card card;
       [SerializeField] private bool isCardSelected;
       
       public Card.Card Card => card;
       public bool IsCardSelected => isCardSelected;
       
       public CardInfo(Card.Card card)
       {
           this.card = card;
       }
       public void SelectCard()
       {
           isCardSelected = true;
       }
    }
}
