using UnityEngine;
using Infrastructure;
using GameCore.Guns;

namespace Configs.Level
{
    /// <summary>
    /// ScriptableObject class that has a pair of values (<see cref="LevelNumberId"/> and <see cref="GunBubblePool"/>)
    /// </summary>
    /// <remarks>
    /// Object to transfer the selected level between scenes
    /// </remarks>
    [CreateAssetMenu(fileName = "SelectedLevelInfo", menuName = "Configs/SelectedLevelInfo", order = 6)]
    public sealed class SelectedLevelInfo : ScriptableObject
    {
        public LevelNumberId LevelId;
        public GunBubblePool GunPool;
    }
}