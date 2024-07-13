using PMA.Enum;
using PMA.Event;
using PMA.Menu;
using UnityEngine;

namespace PMA.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSetting gameSetting;
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private GamePlay gamePlay;

        private GameStage _stageSelected;
        private void Start()
        {
            gamePanel.Init(gameSetting);
            GameEvent.OnStageSelected += OnStageSelected;
        }
        private void OnStageSelected(GameStage stageInfo)
        {
            _stageSelected = stageInfo; 
        }
        
        public void OnButtonClick_GameStart()
        {
            if (_stageSelected == null)
            {
                gamePanel.ShowDialogOk(GameText.NOTICE,GameText.PLEASE_SELECT_STAGE);
                return;
            }
            gamePlay.Init(_stageSelected);
        }
        public void OnButtonClick_GameResume()
        {
            gamePlay.Resume();
        }
    }
}
