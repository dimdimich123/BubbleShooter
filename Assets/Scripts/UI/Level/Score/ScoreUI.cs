using System.Collections;
using UnityEngine;
using GameCore.Guns;

namespace UI.Level.Score
{
    /// <summary>
    /// Stores and displays player scores
    /// </summary>
    public sealed class ScoreUI : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text _scoreNumberText;

        private int _scoreForBubble;
        private GunBubblePool _gunPool;
        private GunRandomPool _fieldPool;

        private WaitForSeconds _waitSeconds = new WaitForSeconds(1);

        public int TotalScores { get; private set; } = 0;

        private void Awake()
        {
            StartCoroutine(ScoreDecrease());
        }

        public void Init(GunBubblePool gunPool, GunRandomPool fieldPool, int scoreForBubble)
        {
            _gunPool = gunPool;
            _fieldPool = fieldPool;
            _scoreForBubble = scoreForBubble;
            _gunPool.OnReturned += ChangScore;
            _fieldPool.OnReturned += ChangScore;
        }

        private void ChangScore(int bubbleNumber)
        {
            TotalScores += _scoreForBubble * bubbleNumber;
            _scoreNumberText.text = TotalScores.ToString();
        }

        private IEnumerator ScoreDecrease()
        {
            while(true)
            {
                yield return _waitSeconds;
                if(TotalScores > 0)
                {
                    TotalScores--;
                    _scoreNumberText.text = TotalScores.ToString();
                }
            }
        }

        private void OnDestroy()
        {
            _gunPool.OnReturned -= ChangScore;
            _fieldPool.OnReturned -= ChangScore;
        }
    }
}