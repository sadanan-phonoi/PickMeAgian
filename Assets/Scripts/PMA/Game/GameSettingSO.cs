using System.Collections.Generic; 
using UnityEngine;

namespace PMA.Game
{
    [CreateAssetMenu(fileName = "New GameSettingSO", menuName = "ScriptableObjects/GameSettingSO")]
    public class GameSettingSO : ScriptableObject
    { 
        [SerializeField] private List<GameStageSO> stageInfoList;
        public List<GameStageSO> StageInfoList => stageInfoList;
    } 
}
