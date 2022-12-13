using UnityEngine;
using UnityEngine.EventSystems;
using GameCore.Guns;

namespace GameCore.Players
{
    public sealed class PlayerControl : MonoBehaviour, IPointerMoveHandler,
            IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Transform _arrow;
        [SerializeField] private float _maxAngle;
        private PlayerGun _playerGun;

        private bool _onField = true;
        private bool _onDown = false;
        private Vector3 _direction;
        private Vector3 _angles;

        public void Init(PlayerGun playerGun)
        {
            _playerGun = playerGun;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _onField = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _onField = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _onDown = true;
            Rotate(eventData);
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if(_onDown && _onField)
            {
                Rotate(eventData);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _onDown = false;
            _playerGun.Shoot();
        }

        private void Rotate(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.worldPosition != Vector3.zero)
            {
                _direction = eventData.pointerCurrentRaycast.worldPosition - _arrow.position;
                _angles = Quaternion.LookRotation(Vector3.forward, _direction).eulerAngles;
                if (_angles.z > 360 - _maxAngle * 2)
                {
                    _angles.z -= 360;
                }
                _angles.z = Mathf.Clamp(_angles.z, -_maxAngle, _maxAngle);
                _arrow.localEulerAngles = _angles;
            }
        }
    }
}