using UnityEngine;
using GameCore.Bubbles;

namespace GameCore.CommonLogic {
    /// <summary>
    /// Destroys a <see cref="Bubble"/> on contact
    /// </summary>
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