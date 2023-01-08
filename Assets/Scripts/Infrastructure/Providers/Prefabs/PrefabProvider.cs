using UnityEngine;

namespace Infrastructure.Providers.Prefabs
{
    /// <summary>
    /// Provides prefabs from disk
    /// </summary>
    public sealed class PrefabProvider
    {
        private GameObject _bubble;

        public PrefabProvider()
        {
            _bubble = Resources.Load<GameObject>("Prefabs/Bubbles/Bubble");
        }

        public GameObject Bubble => _bubble;
    }
}