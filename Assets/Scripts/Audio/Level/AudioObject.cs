using Audio.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Audio.Level
{
    public sealed class AudioObject : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioObjectPair[] _sounds;

        private Dictionary<AudioObjectTypeID, AudioClip[]> _soundsDictionary;
        private int _index = 0;

        private void Awake()
        {
            _soundsDictionary = _sounds.ToDictionary(x => x._audioType, x => x._clips);
        }

        public void Play(AudioObjectTypeID audioObjectTypeID)
        {
            if (_soundsDictionary.ContainsKey(audioObjectTypeID) && _soundsDictionary[audioObjectTypeID] != null)
            {
                _index = Random.Range(0, _soundsDictionary[audioObjectTypeID].Length);
                _audioSource.clip = _soundsDictionary[audioObjectTypeID][_index];
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }
    }
}