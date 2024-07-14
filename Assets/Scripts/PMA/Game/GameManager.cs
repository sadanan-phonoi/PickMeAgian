using PMA.Event;
using PMA.Menu;
using UnityEngine;

namespace PMA.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSettingSO gameSettingSo;
        [SerializeField] private GamePanel gamePanel;
        [SerializeField] private GamePlay gamePlay;

        private GameStageSO _stageSoSelected;
        private void Start()
        {
            gamePanel.Init(gameSettingSo);
            
            GameEvent.OnStageSelected += SubscribeStageSelected;
            GameEvent.OnGameStart += SubscribeGameStart;
            GameEvent.OnGameEnd += SubscribeGameEnd;
        }

        #region GameEvent 
        private void SubscribeStageSelected(GameStageSO stageSoInfo)
        {
            _stageSoSelected = stageSoInfo; 
        } 
        private void SubscribeGameStart()
        {
            gamePanel.ActiveButtonResume(true);
        } 
        private void SubscribeGameEnd()
        {
            gamePanel.ActiveButtonResume(false);
        }
        #endregion
        
        public void OnButtonClick_GameStart()
        {
            if (_stageSoSelected == null)
            {
                gamePanel.ShowDialogOk(GameText.NOTICE,GameText.PLEASE_SELECT_STAGE);
                return;
            }
            gamePlay.Init(_stageSoSelected);
        }
        public void OnButtonClick_GameResume()
        {
            gamePlay.Resume();
        }
    }
}
