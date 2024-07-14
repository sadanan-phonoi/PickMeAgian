using System;
using PMA.Game;

namespace PMA.Event
{
    public static class GameEvent
    { 
        public static Action OnGameStart;
        public static Action OnGameEnd;
        public static Action<GameStageSO> OnStageSelected;
        
        public static Action<int> OnScoreChanged;
        public static Action<int> OnTurnIncrease;
    }
}
