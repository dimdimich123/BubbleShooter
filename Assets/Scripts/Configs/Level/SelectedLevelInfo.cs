using UnityEngine;
using Infrastructure;
using GameCore.Guns;


namespace Configs.Level
{
    [CreateAssetMenu(fileName = "SelectedLevelInfo", menuName = "Configs/SelectedLevelInfo", order = 6)]
    public class SelectedLevelInfo : ScriptableObject
    {
        public LevelNumberId LevelId;
        public GunBubblePool GunPool;
    }
}