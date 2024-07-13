using PMA.Enum;
using PMA.Game;
using UnityEngine;

namespace PMA.Menu
{
    public class GamePanel : MonoBehaviour
    { 
        [SerializeField] private Panel[] panel;
        [Space]
        [SerializeField] private StageSelectCtrl stageSelectCtrl;
     
        public void Init(GameSetting gameSetting)
        {
            OpenMainMenu(gameSetting); 
        } 
        private void OpenMainMenu(GameSetting gameSetting)
        { 
            stageSelectCtrl.RefreshUi(gameSetting);
            SetPanel(GameEnum.EGamePanel.STAGE_SELECT_PANEL);
        } 
        private void SetPanel(GameEnum.EGamePanel type)
        {
            foreach (var p in panel)
            {
                p.panelObject.SetActive(p.panelType == type);
            }
        }
    }
    [System.Serializable]
    public class Panel
    {
        public GameEnum.EGamePanel panelType;
        public GameObject panelObject;
    }
}
