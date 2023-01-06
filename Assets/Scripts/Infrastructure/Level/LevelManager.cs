using UnityEngine;
using GameCore.Grids;
using GameCore.Guns;
using UI.Level.Lose;
using UI.Level.Win;
using Infrastructure.SavingData;
using Infrastructure.Serialization;
using UI.Level.Score;

namespace Infrastructure.Level
{
    public class LevelManager : MonoBehaviour
    {
        private const int _badShotsBeforeAddingBubbles = 5;

        private int _currentBadShotNumber = 0;

        private LevelNumberId _levelId;
        private BubbleGrid _grid;
        private GunBubblePool _fieldPool;
        private PlayerGun _playerGun;
        private LoseView _loseView;
        private WinView _winView;
        private ScoreUI _scoreUI;

        public void Init(BubbleGrid grid, GunBubblePool fieldPool, PlayerGun playerGun,
            LoseView loseView, WinView winView, ScoreUI scoreUI, LevelNumberId levelId)
        {
            _grid = grid;
            _fieldPool = fieldPool;
            _playerGun = playerGun;
            _loseView = loseView;
            _winView = winView;
            _scoreUI = scoreUI;
            _levelId = levelId;

            _grid.OnLastLineHaveBubble += Lose;
            _playerGun.OnGoodShot += CheckGrid;
            _playerGun.OnBadShot += BadShotCounter;
        }

        private void CheckGrid()
        {
            if (_grid.CheckGrid())
            {
                Win();
            }
        }

        private void BadShotCounter()
        {
            _currentBadShotNumber++;
            if (_currentBadShotNumber >= _badShotsBeforeAddingBubbles)
            {
                _grid.BubbleShift(_fieldPool);
                _currentBadShotNumber = 0;
            }
        }

        private void Lose()
        {
            _loseView.Open();
        }

        private void Win()
        {
            LevelRecords data = BinarySerialization.DeserializeData<LevelRecords>(LevelRecords.Path);
            if (data[_levelId].Score < _scoreUI.TotalScores)
            {
                data[_levelId].Score = _scoreUI.TotalScores;
                BinarySerialization.SerializeData(LevelRecords.Path, data);
            }
            _winView.Open();
        }

        private void OnDestroy()
        {
            _grid.OnLastLineHaveBubble -= Lose;
            _playerGun.OnGoodShot -= CheckGrid;
            _playerGun.OnBadShot -= BadShotCounter;
        }

    }
}