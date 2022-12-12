using System;
using System.Collections.Generic;
using GameCore.CommonLogic;
using GameCore.Bubbles;

namespace GameCore.Guns
{
	public abstract class GunBubblePool
	{
		protected Dictionary<BubbleColor, List<Bubble>> _bubbles = new Dictionary<BubbleColor, List<Bubble>>();
        protected Func<BubbleColor, GunBubblePool, Bubble> _factory;

        public abstract Bubble GetBubble();
		public void ReturnBubble(Bubble bubble, BubbleColor color)
		{
            bubble.gameObject.SetActive(false);
            _bubbles[color].Add(bubble);
        }
	}
}