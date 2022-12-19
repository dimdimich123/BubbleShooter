using UnityEngine;
using Configs;

namespace Infrastructure.Providers.Configs
{
    public sealed class ConfigProvider
    {
        private BubbleConfig _bubbleConfig;
        private BubbleColorsConfig _bubbleColorsConig;
        private PlayerControlConfig _playerControlConfig;

        public ConfigProvider()
        {
            _bubbleConfig = Resources.Load<BubbleConfig>("Configs/BubbleConfig");
            _bubbleColorsConig = Resources.Load<BubbleColorsConfig>("Configs/BubbleColorsConfig");
            _playerControlConfig = Resources.Load<PlayerControlConfig>("Configs/PlayerControlConfig");
        }

        public BubbleConfig GetBubbleConfig() => _bubbleConfig;
        public BubbleColorsConfig GetBubbleColorsConfig() => _bubbleColorsConig;
        public PlayerControlConfig GetPlayerControlConfig() => _playerControlConfig;
    }
}