using GameCore.CommonLogic;
using System;
using System.Collections.Generic;
using GameCore.Bubbles;

namespace GameCore.Guns
{
    public sealed class GunRandomPool : GunBubblePool
    {
        private int _colorCount = 1;

        public GunRandomPool(Func<BubbleColor, GunBubblePool, Bubble> factory)
        {
            _factory = factory;
            _colorCount = Enum.GetNames(typeof(BubbleColor)).Length;
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

        public override Bubble GetBubble()
        {
            BubbleColor color = (BubbleColor)UnityEngine.Random.Range(0, _colorCount);
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
    }
}