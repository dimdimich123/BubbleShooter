using System;
using UnityEngine;
using GameCore.CommonLogic;
using GameCore.Guns;
using GameCore.Grids;
using System.Collections.Generic;

namespace GameCore.Bubbles
{
    public sealed class Bubble : MonoBehaviour
    {
        [SerializeField] private BubbleMove _move;

        private BubbleGrid _grid;
        private GunBubblePool _pool;

        [NonSerialized] public BubbleGroup Group;
        public BubbleColor Color { get; private set; }
        public event Action OnEndMove;

        public void Init(BubbleGrid grid, BubbleColor color, GunBubblePool pool, float bubbleSpeed, bool isStatic)
        {
            _grid = grid;
            Color = color;
            _pool = pool;
            Group = new BubbleGroup(this);
            _move.Init(this, bubbleSpeed, isStatic);
        }

        public void StartMove(Vector3 direction)
        {
            _move.StartMove(direction);
        }

        public void EndMove()
        {
            OnEndMove?.Invoke();
            _grid.SetBubble(this, transform);
            List<Bubble> neighborBubble = _grid.CheckAround(transform.position, Color);
            for(int i = 0; i < neighborBubble.Count; ++i)
            {
                if(neighborBubble[i].Group != Group)
                {
                    Group.Union(neighborBubble[i].Group);
                }
            }
            Group.TryPop();
        }

        public void PopOnDeadZone()
        {
            OnEndMove?.Invoke();
            _pool.ReturnBubble(this, Color);
        }

        public void PopOnField()
        {
            _grid.RemoveBubble(transform.position);
            Group = new BubbleGroup(this);
            _pool.ReturnBubble(this, Color);
        }
    }
}