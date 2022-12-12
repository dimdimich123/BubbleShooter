using System;
using UnityEngine;
using GameCore.CommonLogic;
using GameCore.Guns;
using GameCore.Grids;

namespace GameCore.Bubbles
{
    public sealed class Bubble : MonoBehaviour
    {
        [SerializeField] private BubbleMove _move;

        private BubbleGrid _grid;
        private GunBubblePool _pool;

        public BubbleColor Color { get; private set; }

        public event Action OnEndMove;

        public void Init(BubbleGrid grid, BubbleColor color, GunBubblePool pool, float bubbleSpeed, bool isStatic)
        {
            _grid = grid;
            Color = color;
            _pool = pool;
            _move.Init(this, bubbleSpeed, isStatic);
        }

        public void StartMove(Vector3 direction)
        {
            _move.StartMove(direction);
        }

        public void EndMove()
        {
            _grid.SetBubble(transform);
            OnEndMove?.Invoke();
        }
    }
}