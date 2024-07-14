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
        [SerializeField] private AudioSource audioSource;
        
        private GameStageSO _stageSoSelected;
        private void Start()
        {
            gamePanel.Init(gameSettingSo);
            gameSettingSo.Init(audioSource);
            SubscribeGameEnd();
            GameEvent.OnStageSelected += SubscribeStageSelected;
            GameEvent.OnGameStart += SubscribeGameStart;
            GameEvent.OnGameEnd += SubscribeGameEnd;
            GameEvent.PlaySoundEvent += SubscribePlaySound;
        }

        #region GameEvent 
        private void SubscribePlaySound(string key)
        { 
            gameSettingSo.AudioController.PlaySound(key);
        }
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
