using System;
using PMA.Card;
using UnityEngine;
using UnityEngine.UI;

namespace PMA.Game
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image image;  

        public Action<Card> OnCardClick;
        private CardSO _cardInfo;
        public CardSO CardInfo => _cardInfo;
        private Sprite _backCard;
        public void Init(CardSO info,Sprite backCard)
        {
            _cardInfo = info;
            _backCard = backCard;
            
            image.sprite = _backCard;
            
            foreach (var cardId in Player.Instance.CardSelectedId)
            {
                if (_cardInfo.CardId == cardId)
                {
                    OpenCard();
                    break;
                }
            } 
        } 
        public void OnButtonClick()
        {
            OpenCard();
            OnCardClick?.Invoke(this); 
        }
        public void OpenCard()
        {
            image.sprite = _cardInfo.CardImage;
        }
        public void CloseCard()
        {
            image.sprite = _backCard; 
        }
        public void Disable()
        {
           this.gameObject.SetActive(false);
        }
    }
}
