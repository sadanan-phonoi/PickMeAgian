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
                this.gameObject.SetActive(true);
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
            StartFlip(true);
        } 
        public void CloseCard()
        { 
            StartCoroutine(WaitDelay(1, () =>
            {
                StartFlip(false);
                _isCardSelected = false;
            }));
        }  
        public void Disable()
        { 
            Button button = GetComponent<Button>();
            button.interactable = false; 
            StartCoroutine(WaitDelay(1, () => _isDisable = true));
        }  
        private IEnumerator WaitDelay(float delay, Action callback)
        {
            yield return new WaitForSeconds(delay);
            callback?.Invoke();
        }

        private void StartFlip(bool isOpen)
        {
            _isFlip = true; 
            this.transform.localScale = new Vector3(-1, 1, 1); 

            _callbackFlip = () =>
            {
                if(isOpen)
                    image.sprite = _cardInfo.Card.CardImage;
                else 
                    image.sprite = _backCard;  
            };
        }
        bool _isDisable = false;
        bool _isFlip = false;
        private Action _callbackFlip = null;
        public void FixedUpdate()
        {
            if(_isDisable)
            {
               this.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
               
               image.color = new Color(1, 1, 1, image.color.a - 0.1f);
               
               if(this.transform.localScale.x > 1.5f)
               {
                   this.transform.localScale = new Vector3(1, 1, 1);
                   image.color = new Color(0, 0, 0, 0);
                   _isDisable = false;
               }
            }

            if (_isFlip)
            {
                var localScale = this.transform.localScale;
                localScale = new Vector3(localScale.x + 0.1f, localScale.y, localScale.z);
                this.transform.localScale = localScale;

                if (this.transform.localScale.x > 0 && _callbackFlip!=null)
                {
                    _callbackFlip?.Invoke();
                    _callbackFlip = null;
                }
                if(this.transform.localScale.x > 1)
                {
                    this.transform.localScale = new Vector3(1, 1, 1); 
                    _isFlip = false;
                }
            }
        }
    }
}
