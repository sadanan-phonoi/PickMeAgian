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

        public override int Score(List<CardSO> compareCard)
        { 
            if (IsCompare(compareCard))
            {
                TimeSpan time = DateTime.Now - _startTime; 
                ResetTime();
                if (time.TotalSeconds > maxScore)
                    return maxScore;
                return (int)time.TotalSeconds;
            } 
            return 0;
        }

        void ResetTime()
        { 
            _startTime = DateTime.Now; 
        }
    }
}
