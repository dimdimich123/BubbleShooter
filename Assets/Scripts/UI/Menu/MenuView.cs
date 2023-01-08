using System;
using UnityEngine;
using UnityEngine.UI;
using GameCore.CommonLogic;
using Audio;
using Audio.UI;
using Config.Audio;

namespace UI.Menu
{
    public sealed class MenuView : MonoBehaviour
    {
        private const float _lowerVolumeLimit = -79f;

        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Toggle _gunConstPoolToggle;
        [SerializeField] private Toggle _gunRandomPoolToggle;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Slider _gunConstPoolLengthSlider;
        [SerializeField] private TMPro.TMP_Text _gunConstPoolLengthText;

        [SerializeField] private AudioUI _audioUI;
        [SerializeField] private GameAudioMixer _audioMixer;

        public event Action OnExit;
        public event Action OnPlay;
        public event Action OnGunConstPool;
        public event Action OnGunRandomPool;
        public event Action<bool> OnMusic;
        public event Action<bool> OnSound;
        public event Action<int> OnPoolLength;

        private void Awake()
        {
            InitSoundAndMusicToggle();
            InitGunConstPoolSlider();
        }

        private void InitSoundAndMusicToggle()
        {
            if (_audioMixer.GetValue(MixerVariables.SoundVolume, out float soundValue))
            {
                if (soundValue < _lowerVolumeLimit)
                {
                    _soundToggle.isOn = false;
                }
            }

            if (_audioMixer.GetValue(MixerVariables.MusicVolume, out float musicValue))
            {
                if(musicValue < _lowerVolumeLimit)
                {
                    _musicToggle.isOn = false;
                }
            }
        }

        private void InitGunConstPoolSlider()
        {
            _gunConstPoolLengthSlider.minValue = Enum.GetNames(typeof(BubbleColor)).Length;
            _gunConstPoolLengthText.text = _gunConstPoolLengthSlider.value.ToString();
            SetGunConstPoolLength(_gunConstPoolLengthSlider.value);
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(Exit);
            _playButton.onClick.AddListener(Play);
            _gunConstPoolToggle.onValueChanged.AddListener(SetGunConstPool);
            _gunConstPoolLengthSlider.onValueChanged.AddListener(SetGunConstPoolLength);
            _gunRandomPoolToggle.onValueChanged.AddListener(SetGunRandomPool);
            _musicToggle.onValueChanged.AddListener(Music);
            _soundToggle.onValueChanged.AddListener(Sound);
        }

        private void Exit()
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            OnExit?.Invoke();
        }

        private void Play()
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            OnPlay?.Invoke();
        }

        private void SetGunConstPool(bool state)
        {
            if (state)
            {
                _audioUI.Play(AudioUITypeID.ButtonClick);
                OnGunConstPool?.Invoke();
            }
        }

        private void SetGunConstPoolLength(float value)
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            _gunConstPoolLengthText.text = value.ToString();
            OnPoolLength?.Invoke((int)value);

            if(_gunConstPoolToggle.isOn)
            {
                OnGunConstPool?.Invoke();
            }
        }

        private void SetGunRandomPool(bool state)
        {
            if (state)
            {
                _audioUI.Play(AudioUITypeID.ButtonClick);
                OnGunRandomPool?.Invoke();
            }
        }

        private void Music(bool state)
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            OnMusic?.Invoke(state);
        }

        private void Sound(bool state)
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            OnSound?.Invoke(state);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveAllListeners();
            _playButton.onClick.RemoveAllListeners();
            _gunConstPoolToggle.onValueChanged.RemoveAllListeners();
            _gunConstPoolLengthSlider.onValueChanged.RemoveAllListeners();
            _gunRandomPoolToggle.onValueChanged.RemoveAllListeners();
            _musicToggle.onValueChanged.RemoveAllListeners();
            _soundToggle.onValueChanged.RemoveAllListeners();
        }
    }
}