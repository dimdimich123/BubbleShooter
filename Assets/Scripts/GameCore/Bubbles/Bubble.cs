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
        public event Action OnGroupDontPop;
        public event Action OnGroupPop;

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
            _grid.SetBubble(this, transform);
            List<Bubble> neighborBubble = _grid.CheckAround(transform.position, Color);
            for(int i = 0; i < neighborBubble.Count; ++i)
            {
                if(neighborBubble[i].Group != Group)
                {
                    Group.Union(neighborBubble[i].Group);
                }
            }

            if(Group.TryPop())
            {
                OnGroupPop?.Invoke();
            }
            else
            {
                OnGroupDontPop?.Invoke();
            }
            OnEndMove?.Invoke();
        }

        public void PopOnDeadZone()
        {
            OnEndMove?.Invoke();
            _pool.ReturnBubble(this, Color, 0);
        }

        public void PopOnField(int bubbleNumber)
        {
            _grid.RemoveBubble(transform.position);
            Group = new BubbleGroup(this);
            _pool.ReturnBubble(this, Color, bubbleNumber);
        }
    }
}