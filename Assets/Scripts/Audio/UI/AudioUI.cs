using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Audio.UI
{
    /// <summary>
    /// Component that stores and launches audio clips of UI objects
    /// </summary>
    public sealed class AudioUI : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioPair[] _sounds;

        private Dictionary<AudioUITypeID, AudioClip[]> _soundsDictionary;
        private int _index = 0;

        private void Awake()
        {
            _soundsDictionary = _sounds.ToDictionary(x => x._audioType, x => x._clips);
        }

        public void Play(AudioUITypeID audioUITypeID)
        {
            if(_soundsDictionary.ContainsKey(audioUITypeID) && _soundsDictionary[audioUITypeID] != null)
            {
                _index = Random.Range(0, _soundsDictionary[audioUITypeID].Length);
                _audioSource.clip = _soundsDictionary[audioUITypeID][_index];
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }
    }
}