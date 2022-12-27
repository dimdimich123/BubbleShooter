using Infrastructure.FieldBuilders;
using UnityEngine;

namespace Configs.Level
{
    [CreateAssetMenu(fileName = "LevelConfigRandom", menuName = "Configs/LevelConfigRandom", order = 6)]
    public sealed class LevelConfigRandom : LevelConfig
    {
        protected override void OnEnable()
        {
            LevelBuilder = new LevelBuilderRandom();
        }
    }
}