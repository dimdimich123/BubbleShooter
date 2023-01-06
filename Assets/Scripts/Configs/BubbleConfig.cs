using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "BubbleConfig", menuName = "Configs/BubbleConfig", order = 1)]
    public sealed class BubbleConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _points;

        public float Speed => _speed;
        public int Points => _points;
    }
}