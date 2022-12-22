using UnityEngine;
using GameCore.Bubbles;

namespace GameCore.CommonLogic {
    public sealed class DeadZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Bubble bubble))
            {
                bubble.PopOnDeadZone();
            }
        }
    }
}