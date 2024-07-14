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
        
        public delegate void OnButtonClickTab(GameStageSO gameStageSo); 
        public event OnButtonClickTab OnButtonClickEvent;  

        private GameStageSO _info;
        public void Init(GameStageSO gameStageSo)
        {
            _info = gameStageSo;
            text.text = _info.GetStageName;
            selectedImage.gameObject.SetActive(false);
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
