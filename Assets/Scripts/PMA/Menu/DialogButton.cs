using System;
using UnityEngine;

namespace PMA.Menu
{
    public class DialogButton : MonoBehaviour
    {
        [SerializeField] private EDialogType buttonType = EDialogType.OK;  
        private Action<EDialogType> OnClick {get; set;}
        public Action Close {get; set;}
        public void AddCallback(Action<EDialogType> callback)
        {
            this.OnClick += callback; 
        } 
        public void OnButtonClicked()
        { 
            OnClick?.Invoke(buttonType);
            Close?.Invoke();
        }
    }
}
