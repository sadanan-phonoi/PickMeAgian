using System;
using PMA.Enum;
using PMA.Game;
using UnityEngine;
using UnityEngine.UI;

namespace PMA.Menu
{
    public class GamePanel : MonoBehaviour
    { 
        [SerializeField] private Panel[] panel; 
        [Space] 
        [SerializeField] private DialogPopup dialogOk;
        [SerializeField] private DialogPopup dialogYesNo;
        [Space]
        [SerializeField] private StageSelectCtrl stageSelectCtrl;
        [Space]
        [SerializeField] private Button resumeButton;

        public void Init(GameSetting gameSetting)
        {
            OpenMainMenu(gameSetting);
            resumeButton.interactable = false;
        }
        private void OpenMainMenu(GameSetting gameSetting)
        { 
            stageSelectCtrl.RefreshUi(gameSetting);
            SetPanel(GameEnum.EGamePanel.STAGE_SELECT_PANEL);
        } 
        public void SetPanel(GameEnum.EGamePanel type)
        {
            foreach (var p in panel)
            {
                p.panelObject.SetActive(p.panelType == type);
            }
        } 
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
    }
    [System.Serializable]
    public class Panel
    {
        public GameEnum.EGamePanel panelType;
        public GameObject panelObject;
    }
}
