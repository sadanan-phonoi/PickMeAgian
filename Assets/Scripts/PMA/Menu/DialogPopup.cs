using System;
using TMPro;
using UnityEngine;

namespace PMA.Menu
{
    public enum EDialogType
    {
        OK,
        YES,
        NO
    } 
    public class DialogInfo
    {
        public string header { get; private set; } 
        public string message { get; private set; }
        public Action<EDialogType> callback { get; private set; }

        public DialogInfo(string header,string message, Action<EDialogType> callback = null)
        {
            this.header = header;
            this.message = message;
            this.callback = callback;
        }
    }

    public class DialogPopup : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI textContent; 
        [SerializeField] private TextMeshProUGUI textHeader; 
        [SerializeField] private DialogButton[] dialogButton;

        public void Init(DialogInfo info)
        {
            canvas.SetActive(true);
            root.SetActive(true);
            textContent.text = info.message;
            textHeader.text = info.header;
            foreach (var button in dialogButton)
            {
                button.AddCallback(info.callback); 
                button.Close += Close;
            } 
        }

        public void Close()
        {
            root.SetActive(false);
            canvas.SetActive(false);
            foreach (var button in dialogButton)
            {
                button.AddCallback(null); 
            } 
        }
    }
}
