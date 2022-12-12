using UnityEngine;
using GameCore.Bubbles;

namespace GameCore.Guns
{
    public sealed class PlayerGun : MonoBehaviour
    {
        private Transform _transform;
        private GunBubblePool _bubblePool;
        private Bubble _selectedBubble = null;

        private bool _isReady = false;

        public void Init(GunBubblePool bubblePool)
        {
            _bubblePool= bubblePool;
            _transform = GetComponent<Transform>();
            SelectBubble();
        }

        private void SelectBubble()
        {
            if(_selectedBubble!= null)
            {
                _selectedBubble.OnEndMove -= SelectBubble;
            }
            _selectedBubble = _bubblePool.GetBubble();
            _selectedBubble.transform.position = _transform.position;
            _selectedBubble.OnEndMove += SelectBubble;
            _isReady = true;

        }

        public void Shoot()
        {
            if(_isReady)
            {
                _selectedBubble.StartMove(_transform.up);
                _isReady = false;
            }
        }

        private void OnDisable()
        {
            _selectedBubble.OnEndMove -= SelectBubble;
        }
    }
}