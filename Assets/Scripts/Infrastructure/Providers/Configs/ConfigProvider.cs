using UnityEngine;
using Configs;

namespace Infrastructure.Providers.Configs
{
    public sealed class ConfigProvider
    {
        private BubbleConfig _bubbleConfig;
        private BubbleColorsConfig _bubbleColorsConig;

        public ConfigProvider()
        {
            _bubbleConfig = Resources.Load<BubbleConfig>("Configs/BubbleConfig");
            _bubbleColorsConig = Resources.Load<BubbleColorsConfig>("Configs/BubbleColorsConfig");
        }

        public BubbleConfig GetBubbleConfig() => _bubbleConfig;
        public BubbleColorsConfig GetBubbleColorsConfig() => _bubbleColorsConig;
    }
}