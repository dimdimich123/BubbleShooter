using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameCore.Grids
{
    public sealed class BubbleGrid
    {
        private Grid _grid;

        public int Width { get; private set; }
        public int Height { get; private set; }

        Vector3Int _cellPosition;

        public BubbleGrid(Grid grid, int width, int height)
        {
            _grid = grid;
            Width = width;
            Height = height;
        }

        public void SetBubble(Transform bubble, int width, int height)
        {
            _cellPosition.x = width;
            _cellPosition.y = height;
            bubble.position = _grid.CellToWorld(_cellPosition);
        }

        public void SetBubble(Transform bubble)
        {
            _cellPosition = _grid.WorldToCell(bubble.position);

            if (_cellPosition.x < 0 || _cellPosition.x > Width)
            {
                _cellPosition.x = Mathf.Clamp(_cellPosition.x, 0, Width);
            }
            bubble.position = _grid.CellToWorld(_cellPosition);
        }

    }
}