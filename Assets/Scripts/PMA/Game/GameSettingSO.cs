using System.Collections.Generic;
using PMA.Sound;
using UnityEngine;

namespace PMA.Game
{
    [CreateAssetMenu(fileName = "New GameSettingSO", menuName = "ScriptableObjects/GameSettingSO")]
    public class GameSettingSO : ScriptableObject
    { 
        [SerializeField] private List<GameStageSO> stageInfoList;
        public List<GameStageSO> StageInfoList => stageInfoList;
        
        [SerializeField] private AudioControllerSO audioController;
        public AudioControllerSO AudioController => audioController;
        public void Init(AudioSource[] audioSource)
        {
            audioController.Init(audioSource);
        }
    } 
}
