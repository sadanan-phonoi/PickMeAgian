using System;
using System.Collections; 
using PMA.Player;
using UnityEngine; 
using UnityEngine.UI;

namespace PMA.Game
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private Image image;
        
        private CardInfo _cardInfo;
        private Sprite _backCard;
        public CardInfo CardInfo => _cardInfo;
        
        public Action<Card> OnCardClick;
        
        bool _isCardSelected;
        public void Init(CardInfo info, Sprite backCard)
        {
            _cardInfo = info;
            _backCard = backCard;

            image.sprite = _backCard;

            if (info.IsCardSelected)
            {
                Disable(); 
            }
        }
        public void OnButtonClick()
        {
            if(_isCardSelected) return;
            OpenCard();
            OnCardClick?.Invoke(this);
        }

        public void OpenCard()
        { 
            _isCardSelected = true;
            image.sprite = _cardInfo.Card.CardImage;
        } 
        public void CloseCard()
        {
            _isCardSelected = false;
            StartCoroutine(CloseCardWithDelay(1f));
        } 
        public IEnumerator CloseCardWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            image.sprite = _backCard;
        } 
        public void Disable()
        { 
            Button button = GetComponent<Button>();
            button.interactable = false; 
            StartCoroutine(DisableWithDelay(1f));
        }
        public IEnumerator DisableWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            image.color = new Color(0, 0, 0, 0);
        } 
    }
}
