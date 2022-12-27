using System.Collections.Generic;
using UnityEngine;
using GameCore.Bubbles;
using GameCore.CommonLogic;

namespace GameCore.Grids
{
    public sealed class BubbleGrid
    {
        private Grid _grid;

        public int Width { get; private set; }
        public int Height { get; private set; }

        private Vector3Int _cellPosition;
        private Bubble[,] _bubbles;
        private readonly List<Pair> _evenOffset;
        private readonly List<Pair> _oddOffset;
        private int _x = 0;
        private int _y = 0;


        public BubbleGrid(Grid grid, int width, int height)
        {
            _grid = grid;
            Width = width;
            Height = height;
            _bubbles = new Bubble[width, height];
            _evenOffset = new List<Pair>() 
            {
                new Pair(-1, -1),
                new Pair(-1, 0),
                new Pair(-1, 1),
                new Pair(0, -1),
                new Pair(0, 1),
                new Pair(1, 0),
            };

            _oddOffset = new List<Pair>()
            {
                new Pair(0, -1),
                new Pair(-1, 0),
                new Pair(0, 1),
                new Pair(1, -1),
                new Pair(1, 0),
                new Pair(1, 1),
            };
        }

        public void SetBubble(Bubble bubble, Transform bubbleTransform, int width, int height)
        {
            _cellPosition.x = width;
            _cellPosition.y = height;
            _bubbles[width, height] = bubble;
            bubbleTransform.position = _grid.CellToWorld(_cellPosition);
        }

        public void SetBubble(Bubble bubble, Transform bubbleTransform)
        {
            _cellPosition = _grid.WorldToCell(bubbleTransform.position);

            if (_cellPosition.x < 0 || _cellPosition.x >= Width)
            {
                _cellPosition.x = Mathf.Clamp(_cellPosition.x, 0, Width - 1);
            }

            _bubbles[_cellPosition.x, _cellPosition.y] = bubble;
            bubbleTransform.position = _grid.CellToWorld(_cellPosition);
        }

        public void RemoveBubble(Vector3 position)
        {
            _cellPosition = _grid.WorldToCell(position);
            _bubbles[_cellPosition.x, _cellPosition.y] = null;
        }

        public List<Bubble> CheckAround(Vector3 position, BubbleColor color)
        {
            _cellPosition = _grid.WorldToCell(position);
            List<Bubble> result = new List<Bubble>();
            List<Pair> offset;

            if((_cellPosition.y & 1) == 1)
            {
                offset = _oddOffset;
            }
            else
            {
                offset = _evenOffset;
            }

            foreach (Pair pair in offset)
            {
                _x = _cellPosition.x + pair.FirstValue;
                _y = _cellPosition.y + pair.SecondValue;
                if ((_x >= 0 && _x < Width) && _y >= 0 && _bubbles[_x, _y] != null && _bubbles[_x, _y].Color == color)
                {
                    result.Add(_bubbles[_x, _y]);
                }
            }

            return result;
        }
    }
}