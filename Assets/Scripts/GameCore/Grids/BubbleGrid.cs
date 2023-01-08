using System;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Bubbles;
using GameCore.CommonLogic;
using GameCore.Guns;

namespace GameCore.Grids
{
    /// <summary>
    /// Controls the mesh on which the <see cref="Bubble"/>s are located
    /// </summary>
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

        public event Action OnLastLineHaveBubble;

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

            CheckLastLine();
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

            CheckLastLine();
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
                if(_y >= Height)
                {
                    continue;
                }
                if ((_x >= 0 && _x < Width) && _y >= 0 && _bubbles[_x, _y] != null && _bubbles[_x, _y].Color == color)
                {
                    result.Add(_bubbles[_x, _y]);
                }
            }

            return result;
        }

        public void BubbleShift(GunBubblePool fieldPool)
        {
            for (int j = Height - 2; j >= 0; j--)
            {
                for(int i = 0; i < Width; ++i)
                {
                    _bubbles[i, j + 1] = _bubbles[i, j];

                    if(_bubbles[i, j + 1] != null)
                    {
                        _cellPosition.x = i;
                        _cellPosition.y = j + 1;
                        _bubbles[i, j + 1].transform.position = _grid.CellToWorld(_cellPosition);

                        _bubbles[i, j + 1].Group = new BubbleGroup(_bubbles[i, j + 1]);
                    }
                }
            }

            _cellPosition.y = 0;
            for (int i = 0; i < Width; i++)
            {
                _bubbles[i, 0] = fieldPool.GetBubble();

                _cellPosition.x = i;
                _bubbles[i, 0].transform.position = _grid.CellToWorld(_cellPosition);
            }

            for(int j = 0; j < Height; ++j)
            {
                for(int i = 0; i < Width; ++i)
                {
                    if(_bubbles[i, j] != null)
                    {
                        List<Bubble> bubbles = CheckAround(_bubbles[i, j].transform.position, _bubbles[i, j].Color);
                        for (int k = 0; k < bubbles.Count; ++k)
                        {
                            if (bubbles[k].Group != _bubbles[i, j].Group)
                            {
                                _bubbles[i, j].Group.Union(bubbles[k].Group);
                            }
                        }
                    }
                }
            }

            CheckLastLine();
        }

        private void CheckLastLine()
        {
            for(int i = 0; i < Width; ++i)
            {
                if (_bubbles[i, Height - 1] != null)
                {
                    OnLastLineHaveBubble?.Invoke();
                    break;
                }
            }
        }

        public bool CheckGrid()
        {
            bool isEmpty = true;
            for (int i = 0; i < Width; ++i)
            {
                for(int j = 0; j < Height; ++j)
                {
                    if (_bubbles[i, j] != null)
                    {
                        isEmpty = false;
                        break;
                    }
                }
                
                if(!isEmpty)
                {
                    break;
                }
            }

            return isEmpty;
        }
    }
}