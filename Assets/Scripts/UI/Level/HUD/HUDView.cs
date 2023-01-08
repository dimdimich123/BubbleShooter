using Audio.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class HUDView : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _pauseButton;

        [SerializeField] private AudioUI _audioUI;

        private CanvasGroup _canvas;

        public event Action OnPause;

        private void Awake()
        {
            _canvas = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(Pause);
        }

        private void Pause()
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            _canvas.Close();
            OnPause?.Invoke();
        }

        public void Open()
        {
            _canvas.Open();
        }

        public void Close()
        {
            _canvas.Close();
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveAllListeners();
        }

        
    }
}