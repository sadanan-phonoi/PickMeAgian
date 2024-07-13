using System;
using PMA.Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PMA.Menu
{
    public class StageSelectTab : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image selectedImage;
        
        public delegate void OnButtonClickTab(GameStage gameStage); 
        public event OnButtonClickTab OnButtonClickEvent;  

        private GameStage _info;
        public void Init(GameStage gameStage)
        {
            _info = gameStage;
            text.text = _info.GetStageName;
        }

        public void OnButtonClick()
        { 
            OnButtonClickEvent?.Invoke(_info);
            
            if(selectedImage!=null)
                selectedImage.gameObject.SetActive(true);
        }

        public void Disable()
        {
            if(selectedImage!=null)
                selectedImage.gameObject.SetActive(false);
        }
    }
}
