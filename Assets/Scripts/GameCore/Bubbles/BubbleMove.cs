using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace GameCore.Bubbles
{
    public sealed class BubbleMove : MonoBehaviour
    {
        [SerializeField] private LayerMask _wallMask;
        [SerializeField] private LayerMask _bubbleMask;
        private float _speed;
        private Transform _bubbleTansform;
        private Bubble _bubble;

        private Vector3 _direction;
        private bool _isStatic;

        public void Init(Bubble bubble, float speed, bool isStatic)
        {
            _bubble = bubble;
            _bubbleTansform = _bubble.GetComponent<Transform>();
            _speed = speed;
            _isStatic = isStatic;
        }

        public void StartMove(Vector3 direction)
        {
            _direction = direction;
            StartCoroutine(Move());
        }

        private IEnumerator Move()
        {
            while(true)
            {
                _bubbleTansform.position += _direction * Time.deltaTime * _speed;
                yield return null;
            }
        }

        private void TakePlace()
        {
            StopAllCoroutines();
            _bubble.EndMove();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isStatic == false)
            {
                if ((1 << collision.gameObject.layer & _bubbleMask) != 0)
                {
                    _isStatic = true;
                    _bubbleTansform.position -= _direction * Time.deltaTime * _speed;
                    TakePlace();
                }
                else
                {
                    if ((1 << collision.gameObject.layer & _wallMask) != 0)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(_bubbleTansform.position, _direction, 1, _wallMask.value);
                        if (hit.collider != null)
                        {
                            _direction = Vector3.Reflect(_direction, hit.normal);
                        }
                    }
                }
            }
        }
    }
}