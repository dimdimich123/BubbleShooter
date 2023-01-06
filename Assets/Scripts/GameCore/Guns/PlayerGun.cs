using System;
using UnityEngine;
using GameCore.Bubbles;

namespace GameCore.Guns
{
    public sealed class PlayerGun : MonoBehaviour
    {
        private Transform _transform;
        private Transform _nextBubbleTransform;
        private GunBubblePool _bubblePool;
        private Bubble _selectedBubble = null;

        private bool _isReady = false;

        private Bubble _nextBubble;
        public event Action OnGoodShot;
        public event Action OnBadShot;

        public void Init(GunBubblePool bubblePool, Transform nextBubbleTransform)
        {
            _bubblePool= bubblePool;
            _nextBubbleTransform = nextBubbleTransform;
            _transform = GetComponent<Transform>();

            _nextBubble = _bubblePool.GetBubble();
            SelectBubble();
        }

        private void SelectBubble()
        {
            if(_selectedBubble!= null)
            {
                _selectedBubble.OnEndMove -= SelectBubble;
                _selectedBubble.OnGroupDontPop -= BadShot;
                _selectedBubble.OnGroupPop -= GoodShot;
            }

            _selectedBubble = _nextBubble;
            _selectedBubble.transform.position = _transform.position;
            _nextBubble = _bubblePool.GetBubble();
            _nextBubble.transform.position = _nextBubbleTransform.position;

            _selectedBubble.OnEndMove += SelectBubble;
            _selectedBubble.OnGroupPop += GoodShot;
            _selectedBubble.OnGroupDontPop += BadShot;
            _isReady = true;
        }

        private void GoodShot()
        {
            OnGoodShot?.Invoke();
        }

        private void BadShot()
        {
            OnBadShot?.Invoke();
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
            _selectedBubble.OnGroupPop -= GoodShot;
            _selectedBubble.OnGroupDontPop -= BadShot;
        }
    }
}