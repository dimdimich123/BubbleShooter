using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Configs;
using Configs.Level;

namespace Infrastructure.Providers.Configs
{
    /// <summary>
    /// Provides configurations from disk
    /// </summary>
    public sealed class ConfigProvider
    {
        private SelectedLevelInfo _selectedLevelInfo;
        private BubbleConfig _bubbleConfig;
        private BubbleColorsConfig _bubbleColorsConig;
        private PlayerControlConfig _playerControlConfig;
        private Dictionary<LevelNumberId, LevelConfig> _levelConfigs;

        public ConfigProvider()
        {
            _selectedLevelInfo = Resources.Load<SelectedLevelInfo>("Configs/SelectedLevelInfo");
            _bubbleConfig = Resources.Load<BubbleConfig>("Configs/BubbleConfig");
            _bubbleColorsConig = Resources.Load<BubbleColorsConfig>("Configs/BubbleColorsConfig");
            _playerControlConfig = Resources.Load<PlayerControlConfig>("Configs/PlayerControlConfig");
            _levelConfigs = Resources.LoadAll<LevelConfig>("Configs/Levels").ToDictionary(x => x.LevelId, y => y);
        }

        public SelectedLevelInfo SelectedLevelInfo => _selectedLevelInfo;
        public BubbleConfig BubbleConfig => _bubbleConfig;
        public BubbleColorsConfig BubbleColorsConfig => _bubbleColorsConig;
        public PlayerControlConfig PlayerControlConfig => _playerControlConfig;
        public LevelConfig GetLevelConfig(LevelNumberId levelId) => 
            _levelConfigs.TryGetValue(levelId,out LevelConfig config) ? config : null;
    }
}