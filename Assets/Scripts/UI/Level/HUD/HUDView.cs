using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.HUD
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class HUDView : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _pauseButton;

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