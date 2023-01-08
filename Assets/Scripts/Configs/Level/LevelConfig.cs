using Infrastructure;
using Infrastructure.FieldBuilders;
using UnityEngine;

namespace Configs.Level
{
    /// <summary>
    /// Abstract ScriptableObject class needed to store the level configuration
    /// </summary>
    public abstract class LevelConfig : ScriptableObject
    {
        [SerializeField] protected LevelNumberId _levelId;

        public LevelNumberId LevelId => _levelId;

        public ILevelBuilder LevelBuilder { get; protected set; }

        protected abstract void OnEnable();
    }
}