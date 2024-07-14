using PMA.Card;
using UnityEngine;

namespace PMA.Player
{
    [System.Serializable]
    public class CardInfo
    {
       [SerializeField] private CardSO cardSo;
       [SerializeField] private bool isCardSelected;
       
       public CardSO CardSo => cardSo;
       public bool IsCardSelected => isCardSelected;
       
       public CardInfo(CardSO cardSo)
       {
           this.cardSo = cardSo;
       }
       public void SelectCard()
       {
           isCardSelected = true;
       }
    }
}
