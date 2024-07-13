using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{
    public abstract class ScoreRule : ScriptableObject
    {
        public abstract void Init();
        public abstract int Score(List<CardSO> compareCard);

        protected bool IsCompare(List<CardSO> compareCard)
        {
            for (int i = 0; i < compareCard.Count - 1; i++)
            {
                return compareCard[i].CardId == compareCard[i + 1].CardId;
            } 
            return false;
        }
    }
}
