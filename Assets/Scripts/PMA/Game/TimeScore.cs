using System;
using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{
    [CreateAssetMenu(fileName = "New TimeScore", menuName = "ScriptableObjects/ScoreRule/TimeScore")]
    public class TimeScore : ScoreRule
    {  
        [SerializeField] private int maxScore = 10;
        private DateTime _startTime;
        public override void Init()
        { 
            ResetTime();
        }

        public override int Score(List<PMA.Card.Card> compareCard)
        { 
            if (IsCompare(compareCard))
            {
                TimeSpan time = DateTime.Now - _startTime; 
                var score = maxScore - (int)time.TotalSeconds;
                
                if (score > 0)
                {
                    ResetTime();
                    return score;
                }
            } 
            return 0;
        }

        void ResetTime()
        { 
            _startTime = DateTime.Now; 
        }
    }
}
