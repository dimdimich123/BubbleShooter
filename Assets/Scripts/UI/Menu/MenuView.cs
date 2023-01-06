using GameCore.CommonLogic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Menu
{
    public sealed class MenuView : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _playButton;
        [SerializeField] private Toggle _gunConstPoolToggle;
        [SerializeField] private Toggle _gunRandomPoolToggle;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private Slider _gunConstPoolLengthSlider;
        [SerializeField] private TMPro.TMP_Text _gunConstPoolLengthText;

        public event Action OnExit;
        public event Action OnPlay;
        public event Action OnGunConstPool;
        public event Action OnGunRandomPool;
        public event Action<bool> OnMusic;
        public event Action<bool> OnSound;
        public event Action<int> OnPoolLength;

        private void Awake()
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
            OnExit?.Invoke();
        }

        private void Play()
        {
            OnPlay?.Invoke();
        }

        private void SetGunConstPool(bool state)
        {
            if(state)
            {
                OnGunConstPool?.Invoke();
            }
        }

        private void SetGunConstPoolLength(float value)
        {
            _gunConstPoolLengthText.text = value.ToString();
            OnPoolLength?.Invoke((int)value);

            if(_gunConstPoolToggle.isOn)
            {
                OnGunConstPool?.Invoke();
            }
        }

        private void SetGunRandomPool(bool state)
        {
            if(state)
            {
                OnGunRandomPool?.Invoke();
            }
        }

        private void Music(bool state)
        {
            OnMusic?.Invoke(state);
        }

        private void Sound(bool state)
        {
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