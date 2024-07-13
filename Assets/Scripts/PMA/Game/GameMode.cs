using PMA.Card;
using UnityEngine;

namespace PMA.Game
{ 
    public class GameMode : ScriptableObject
    {
        [SerializeField] private GameSetting gameSetting;
        [SerializeField] private CardSettingSO cardSetting; 
        [SerializeField] private ScoreRule[] scoreRule;

        public int GetScore(CompareCard compareCard)
        {
            var totalScore = 0; 
            foreach (var rule in scoreRule)
            {
                totalScore += rule.Score(compareCard);
            } 
            return totalScore;
        }
    }
}
