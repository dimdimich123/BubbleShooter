using UnityEngine;
using GameCore.CommonLogic;
using Infrastructure.FieldBuilders;

namespace Configs.Level
{
    /// <summary>
    /// Implementation of the <see cref="LevelConfig"/> class that stores the location of the bubbles in the level
    /// </summary>
    [CreateAssetMenu(fileName = "LevelConfigConst", menuName = "Configs/LevelConfigConst", order = 5)]
    public sealed class LevelConfigConst : LevelConfig
    {
        [SerializeField] private BubblePositionData[] _bubbles;

        protected override void OnEnable()
        {
            LevelBuilder = new LevelBuilderConst(_bubbles);
        }
    }
}