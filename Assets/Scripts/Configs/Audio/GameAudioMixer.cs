using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using Audio;

namespace Config.Audio
{
    [CreateAssetMenu(fileName = "GameAudioMixer", menuName = "Configs/GameAudioMixer", order = 7)]
    public sealed class GameAudioMixer : ScriptableObject
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private MixerVariablePair[] _variables;

        private Dictionary<MixerVariables, string> _variablesDictionary;

        private void OnEnable()
        {
            _variablesDictionary = _variables.ToDictionary(x => x.Variable, x => x.Value);
        }

        public AudioMixer AudioMixer => _audioMixer;

        public bool GetValue(MixerVariables variable, out float value)
        {
            if (_variablesDictionary.TryGetValue(variable, out string variableName))
            {
                if (_audioMixer.GetFloat(variableName, out value))
                {
                    return true;
                }
                else
                {
                    value = default;
                    return false;
                }
            }
            else
            {
                value = default;
                return false;
            }
        }

        public bool SetValue(MixerVariables variable, float value)
        {
            if (_variablesDictionary.TryGetValue(variable, out string variableName))
            {
                return _audioMixer.SetFloat(variableName, value);
            }
            else
            {
                return false;
            }
        }
    }
}