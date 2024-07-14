using UnityEngine;

namespace PMA.Sound
{
    [System.Serializable]
    public class Sound
    {
        public string key;
        public AudioClip soundMusic; 
    }

    public static class SoundKey
    {
        public static string FORMAT = "SOUND_KEY_";
        public static string SOUND_FLIPPING = FORMAT+"FLIPPING"; 
        public static string SOUND_MATCH = FORMAT+"MATCH";
        public static string SOUND_UN_MATCH = FORMAT+"UN_MATCH";
        public static string SOUND_WIN = FORMAT+"WIN";
        public static string SOUND_LOSE = FORMAT+"LOSE";
    }
}
