using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.CommonLogic;
using GameCore.Bubbles;

namespace GameCore.Guns {
    public sealed class GunConstPool : GunBubblePool
    {
        private int _bubbleColorIndex = 0;
        private List<BubbleColor> _bubbleColors= new List<BubbleColor>();
        private readonly int _length;

        public GunConstPool(int length)
        {
            _length = length;
        }

        public override void Init(Func<BubbleColor, GunBubblePool, Bubble> factory)
        {
            base.Init(factory);
            InitColors(_length);
            InitBubbles(_length);
        }

        private void InitColors(int length)
        {
            int colorsCount = Enum.GetNames(typeof(BubbleColor)).Length;
            for (int i = 0; i < colorsCount; i++)
            {
                _bubbleColors.Add((BubbleColor)i);
            }

            _bubbleColors = _bubbleColors.OrderBy(a => UnityEngine.Random.Range(0, int.MaxValue)).ToList();

            for (int i = colorsCount; i < length; i++)
            {
                _bubbleColors.Add((BubbleColor)UnityEngine.Random.Range(0, colorsCount));
            }
        }

        private void InitBubbles(int length)
        {
            for (int i = 0; i < length; i++)
            {
                BubbleColor color = _bubbleColors[i];
                Bubble bubble = _factory(color, this);
                bubble.gameObject.SetActive(false);

                if (_bubbles.ContainsKey(color))
                {
                    _bubbles[color].Add(bubble);
                }
                else
                {
                    _bubbles[color] = new List<Bubble> { bubble };
                }
                
            }
        }

        public override Bubble GetBubble()
        {
            BubbleColor color = _bubbleColors[_bubbleColorIndex];
            _bubbleColorIndex = (_bubbleColorIndex + 1 < _bubbleColors.Count) ? _bubbleColorIndex + 1 : 0;
            Bubble bubble = null;

            if(_bubbles[color].Count > 0)
            {
                bubble = _bubbles[color][0];
                _bubbles[color].RemoveAt(0);
                bubble.gameObject.SetActive(true);
            }
            else
            {
                bubble = _factory(color, this);
            }
            return bubble;
        }
    }
}