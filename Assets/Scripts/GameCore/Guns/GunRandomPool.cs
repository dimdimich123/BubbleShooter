using System;
using System.Collections.Generic;
using GameCore.Bubbles;
using GameCore.CommonLogic;

namespace GameCore.Guns
{
    /// <summary>
    /// Implementation of the <see cref="GunBubblePool"/> class that has a random sequence of bubbles
    /// </summary>
    public sealed class GunRandomPool : GunBubblePool
    {
        private int _colorCount = 1;

        public GunRandomPool()
        {
            _colorCount = Enum.GetNames(typeof(BubbleColor)).Length;
        }

        public override void Init(Func<BubbleColor, GunBubblePool, Bubble> factory)
        {
            base.Init(factory);
            InitBubbles();
        }

        private void InitBubbles()
        {
            for (int i = 0; i < _colorCount; i++)
            {
                BubbleColor color = (BubbleColor)i;
                Bubble bubble = _factory(color, this);
                bubble.gameObject.SetActive(false);
                _bubbles[color] = new List<Bubble> { bubble };
            }
        }

        private Bubble TakeBubble(BubbleColor color)
        {
            Bubble bubble = null;

            if (_bubbles[color].Count > 0)
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

        public override Bubble GetBubble()
        {
            BubbleColor color = (BubbleColor)UnityEngine.Random.Range(0, _colorCount);
            return TakeBubble(color);
        }

        public Bubble GetBubble(BubbleColor color)
        {
            return TakeBubble(color);
        }
    }
}