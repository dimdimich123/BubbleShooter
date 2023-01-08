using Infrastructure.FieldBuilders;
using UnityEngine;

namespace Configs.Level
{
    /// <summary>
    /// Implementation of the <see cref="LevelConfig"/> class that stores the level configuration with a random arrangement of bubbles
    /// </summary>
    [CreateAssetMenu(fileName = "LevelConfigRandom", menuName = "Configs/LevelConfigRandom", order = 6)]
    public sealed class LevelConfigRandom : LevelConfig
    {
        protected override void OnEnable()
        {
            LevelBuilder = new LevelBuilderRandom();
        }
    }
}