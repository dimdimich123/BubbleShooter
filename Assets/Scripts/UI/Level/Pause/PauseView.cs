using Audio.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.Pause
{
    /// <summary>
    /// Displaying data received from the <see cref="PauseModel"/>
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class PauseView : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _continueButton;

        [SerializeField] private AudioUI _audioUI;

        private CanvasGroup _canvas;

        public event Action OnExit;
        public event Action OnRestart;
        public event Action OnContinue;

        private void Awake()
        {
            _canvas = GetComponent<CanvasGroup>();
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(Exit);
            _restartButton.onClick.AddListener(Restart);
            _continueButton.onClick.AddListener(Continue);
        }

        private void Exit()
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            OnExit?.Invoke();
        }

        private void Restart()
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            OnRestart?.Invoke();
        }

        private void Continue()
        {
            _audioUI.Play(AudioUITypeID.ButtonClick);
            _canvas.Close();
            OnContinue?.Invoke();
        }

        public void Close()
        {
            _canvas.Close();
        }

        public void Open()
        {
            _canvas.Open();
        }

        private void OnDisable()
        {
            _exitButton.onClick.AddListener(Exit);
            _restartButton.onClick.AddListener(Restart);
            _continueButton.onClick.AddListener(Continue);
        }
    }
}