using UnityEngine;

namespace PMA.Game
{
    [System.Serializable]
    public class GameSetting
    {
        [SerializeField] private int cardValueX = 2;
        [SerializeField] private int cardValueY = 2;
        [SerializeField] private int cardCompareValue = 2; 
        public int CardValueX => cardValueX;
        public int CardValueY => cardValueY;
        public int CardCompareValue => cardCompareValue; 
        public int TotalCard => cardValueX * cardValueY / cardCompareValue;
    }
}
