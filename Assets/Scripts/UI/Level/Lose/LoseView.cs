using System;
using UnityEngine;
using UnityEngine.UI;
using UI.Level.Score;
using Audio.UI;

namespace UI.Level.Lose
{
    /// <summary>
    /// Displaying data received from the <see cref="LoseModel"/>
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LoseView : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMPro.TMP_Text _scoreNumberText;

        [SerializeField] private AudioUI _audioUI;

        private CanvasGroup _canvas;
        private ScoreUI _scoreUI;

        public event Action OnExit;
        public event Action OnRestart;

        private void Awake()
        {
            _canvas = GetComponent<CanvasGroup>();
        }

        public void Init(ScoreUI scoreUI)
        {
            _scoreUI = scoreUI;
        }

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(Exit);
            _restartButton.onClick.AddListener(Restart);
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

        public void Open()
        {
            Time.timeScale = 0;
            _scoreNumberText.text = _scoreUI.TotalScores.ToString();
            _canvas.Open();
        }

        public void Close()
        {
            _canvas.Close();
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveAllListeners();
            _restartButton.onClick.RemoveAllListeners();
        }
    }
}