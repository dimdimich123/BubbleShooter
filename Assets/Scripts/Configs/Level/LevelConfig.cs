using Infrastructure;
using Infrastructure.FieldBuilders;
using UnityEngine;

namespace Configs.Level
{
    public abstract class LevelConfig : ScriptableObject
    {
        [SerializeField] protected LevelNumberId _levelId;

        public LevelNumberId LevelId => _levelId;

        public ILevelBuilder LevelBuilder { get; protected set; }

        protected abstract void OnEnable();
    }
}