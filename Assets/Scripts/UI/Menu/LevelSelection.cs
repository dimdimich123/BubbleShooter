using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Configs.Level;
using Infrastructure.Data;
using Infrastructure.SavingData;
using Infrastructure.Serialization;

namespace UI.Menu
{
    public sealed class LevelSelection : MonoBehaviour
    {
        [SerializeField] private List<LevelSelectionData> _levels;
        [SerializeField] private SelectedLevelInfo _selectedLevelInfo;

        [SerializeField] private TMPro.TMP_Text _levelNameText;
        [SerializeField] private TMPro.TMP_Text _levelRecordNumberText;
        [SerializeField] private Button _leftArrow;
        [SerializeField] private Button _rightArrow;

        private LevelRecords _records;
        private int _currentIndex = 0;

        private void Awake()
        {
            _records = BinarySerialization.DeserializeData<LevelRecords>(LevelRecords.Path);
        }

        private void Start()
        {
            ChangeLevel();
        }

        private void OnEnable()
        {
            _leftArrow.onClick.AddListener(PreviousLevel);
            _rightArrow.onClick.AddListener(NextLevel);
        }

        private void PreviousLevel()
        {
            _currentIndex = (_currentIndex - 1) < 0 ? _levels.Count - 1 : _currentIndex - 1;
            ChangeLevel();
        }

        private void NextLevel()
        {
            _currentIndex = (_currentIndex + 1) >= _levels.Count ? 0 : _currentIndex + 1;
            ChangeLevel();
        }

        private void ChangeLevel()
        {
            _levelNameText.text = _levels[_currentIndex].Name;
            _levelRecordNumberText.text = _records[_levels[_currentIndex].LevelId].Score.ToString();
            _selectedLevelInfo.LevelId = _levels[_currentIndex].LevelId;
        }

        private void OnDisable()
        {
            _leftArrow.onClick.RemoveAllListeners();
            _rightArrow.onClick.RemoveAllListeners();
        }
    }
}