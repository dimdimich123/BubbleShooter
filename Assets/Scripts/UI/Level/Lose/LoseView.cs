using System;
using UnityEngine;
using UnityEngine.UI;
using UI.Level.Score;

namespace UI.Level.Lose
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LoseView : MonoBehaviour, IPanel
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private TMPro.TMP_Text _scoreNumberText;

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
            OnExit?.Invoke();
        }

        private void Restart()
        {
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