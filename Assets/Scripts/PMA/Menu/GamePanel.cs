using System;
using PMA.Enum;
using PMA.Game;
using UnityEngine;
using UnityEngine.UI;

namespace PMA.Menu
{
    [System.Serializable]
    public class Panel
    {
        public GameEnum.EGamePanel panelType;
        public GameObject panelObject;
    }
    public class GamePanel : MonoBehaviour
    { 
        [SerializeField] private Panel[] panel; 
        [Header("Dialog")] 
        [SerializeField] private DialogPopup dialogOk;
        [SerializeField] private DialogPopup dialogYesNo;
        [Header("State Select")] 
        [SerializeField] private StageSelectCtrl stageSelectCtrl;
        [Space]
        [SerializeField] private Button resumeButton;

        public void Init(GameSettingSO gameSettingSo)
        {
            OpenMainMenu(gameSettingSo); 
        }
        private void OpenMainMenu(GameSettingSO gameSettingSo)
        { 
            stageSelectCtrl.Init(gameSettingSo);
            SetPanel(GameEnum.EGamePanel.STAGE_SELECT_PANEL);
        } 
        public void SetPanel(GameEnum.EGamePanel type)
        {
            foreach (var p in panel)
            {
                p.panelObject.SetActive(p.panelType == type);
            }
        } 
        public void SetPanel(int panel)
        {
            SetPanel((GameEnum.EGamePanel)panel);
        } 
        public void ActiveButtonResume(bool isActive)
        { 
            resumeButton.interactable = isActive;
        }

        #region Dialog OK 
        public void ShowDialogOk(string header,string message, Action<EDialogType> callback = null)
        {
            if(dialogOk!=null)
                dialogOk.Init( new DialogInfo(header,message, callback));
        }
        public void ShowDialogYesNo(string header,string message, Action<EDialogType> callback = null)
        {
            if(dialogYesNo!=null)
                dialogYesNo.Init(new DialogInfo(header,message, callback));
        }
        public void CloseDialog()
        {
            if(dialogOk!=null)
                dialogOk.Close();
            if(dialogYesNo!=null)
                dialogYesNo.Close();
        }
        #endregion
    }
}
