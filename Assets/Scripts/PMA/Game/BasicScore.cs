using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{
    [CreateAssetMenu (fileName = "New BasicScore", menuName = "ScriptableObjects/ScoreRule/BasicScore")]
    public class BasicScore : ScoreRule
    {
        public override void Init(){} 
        public override int Score(List<CardSO> compareCard)
        {
            return IsCompare(compareCard) ? 1 : 0;
        }
    }
}
