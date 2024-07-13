using System.Collections.Generic;
using PMA.Enum;
using UnityEngine;

namespace PMA.Game
{
    [CreateAssetMenu(fileName = "New GameSetting", menuName = "ScriptableObjects/GameSetting")]
    public class GameSetting : ScriptableObject
    { 
        [SerializeField] private List<StageInfo> stageInfoList;
        public List<StageInfo> StageInfoList => stageInfoList;
    }

    [System.Serializable]
    public class StageInfo
    {
        [SerializeField] private int stageId;
        [SerializeField] private GameEnum.EDifficultyLevel difficultyLevel;
        [SerializeField] private GameStage stage;

        public int StageId => stageId;
        public GameEnum.EDifficultyLevel DifficultyLevel => difficultyLevel;
        public GameStage Stage => stage;
    }
}
