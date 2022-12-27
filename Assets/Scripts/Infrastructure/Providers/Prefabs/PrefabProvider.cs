using UnityEngine;

namespace Infrastructure.Providers.Prefabs
{
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