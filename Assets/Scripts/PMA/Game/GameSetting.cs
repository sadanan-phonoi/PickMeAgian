using UnityEngine;

namespace PMA.Game
{
    [System.Serializable]
    public class GameSetting
    {
        [SerializeField] private int cardValueX;
        [SerializeField] private int cardValueY;
        [SerializeField] private int cardCompareValue;

        public int CardValueX => cardValueX;
        public int CardValueY => cardValueY;
        public int CardCompareValue => cardCompareValue;
    }
}
