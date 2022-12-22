using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "PlayerControlConfig", menuName = "Configs/PlayerControlConfig", order = 4)]
    public sealed class PlayerControlConfig : ScriptableObject
    {
        [SerializeField] private float _angle;

        public float Angle => _angle;
    }
}