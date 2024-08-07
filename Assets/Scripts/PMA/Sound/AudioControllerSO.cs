using System.Collections.Generic;
using UnityEngine;

namespace PMA.Sound
{
    [CreateAssetMenu (fileName = "New AudioControllerSO", menuName = "ScriptableObjects/AudioControllerSO")]
    public class AudioControllerSO : ScriptableObject
    {
        public List<Sound> Sounds;

        private AudioSource[] _audioSource;
        private int _currentIndex = 0;
        private AudioClip GetSound(string key)
        {
            return Sounds.Find(x => x.key == key).soundMusic;
        } 
        public void Init(AudioSource[] audioSource)
        {
            this._audioSource = audioSource;
        }
        public void PlaySound(string key, float volumePercentage = 1.0f)
        { 
            AudioSource source = _audioSource[_currentIndex];
            if (_currentIndex == _audioSource.Length - 1)
                _currentIndex = 0;
            else
                _currentIndex += 1;
            
            source.clip = GetSound(key);
            source.volume *= volumePercentage;
            source.Play(); 
        }

    }
}
