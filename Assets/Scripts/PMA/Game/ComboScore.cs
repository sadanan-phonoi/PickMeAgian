using System.Collections.Generic;
using PMA.Card;
using UnityEngine;

namespace PMA.Game
{
    [CreateAssetMenu (fileName = "New ComboScore", menuName = "ScriptableObjects/ScoreRule/ComboScore")] 
    public class ComboScore : ScoreRule
    {
        [SerializeField] private int comboMax = 3;
        private int _combo;
        public override void Init()
        {
            _combo = 0;
        }
        public override int Score(List<PMA.Card.Card> compareCard)
        {
            if (IsCompare(compareCard))
            {
                _combo += 1;
                if (_combo > comboMax)
                    _combo = comboMax;
            }
            else
                _combo = 0;

            return _combo;
        }
    }
}
