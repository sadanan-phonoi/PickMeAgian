using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{
    public abstract class ScoreRule : ScriptableObject
    {
        [SerializeField] private string ruleName;
        public string RuleName => ruleName;
        public abstract void Init();
        public abstract int Score(List<PMA.Card.Card> compareCard);

        protected bool IsCompare(List<PMA.Card.Card> compareCard)
        {
            for (int i = 0; i < compareCard.Count - 1; i++)
            {
                if (compareCard[i].CardId != compareCard[i+1].CardId)
                    return false; 
            } 
            return true;
        }
    }
}
