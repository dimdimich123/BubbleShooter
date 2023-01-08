using UnityEngine;
using UnityEngine.SceneManagement;
using Configs.Level;
using GameCore.Guns;
using Audio;
using Config.Audio;

namespace UI.Menu
{
    /// <summary>
    /// Implements click actions on UI elements of the <see cref="MenuView"/>
    /// </summary>
    public sealed class MenuModel
    {
        private const float _valueWhenAudioIsOn = 0;
        private const float _valueWhenAudioIsOff = -80f;

        private SelectedLevelInfo _selectedLevelInfo;
        private GameAudioMixer _audioMixer;
        private int _gunConstPoolLength = 5;

        public MenuModel(SelectedLevelInfo selectedLevelInfo, GameAudioMixer audioMixer)
        {
            _selectedLevelInfo = selectedLevelInfo;
            _audioMixer = audioMixer;
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Play()
        {
            SceneManager.LoadScene(Infrastructure.SceneName.Level.ToString());
        }

        public void SetGunConstPool()
        {
            _selectedLevelInfo.GunPool = new GunConstPool(_gunConstPoolLength);
        }

        public void SetGunConstPoolLength(int poolLength)
        {
            _gunConstPoolLength = poolLength;
        }

        public void SetGunRandomPool()
        {
            _selectedLevelInfo.GunPool = new GunRandomPool();
        }

        public void Music(bool state)
        {
            if(state)
            {
                _audioMixer.SetValue(MixerVariables.MusicVolume, _valueWhenAudioIsOn);
            }
            else
            {
                _audioMixer.SetValue(MixerVariables.MusicVolume, _valueWhenAudioIsOff);
            }
        }

        public void Sound(bool state)
        {
            if (state)
            {
                _audioMixer.SetValue(MixerVariables.SoundVolume, _valueWhenAudioIsOn);
            }
            else
            {
                _audioMixer.SetValue(MixerVariables.SoundVolume, _valueWhenAudioIsOff);
            }
        }
    }
}