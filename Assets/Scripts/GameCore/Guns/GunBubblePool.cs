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

		public event Action<int> OnReturned;

        public abstract Bubble GetBubble();

		public virtual void Init(Func<BubbleColor, GunBubblePool, Bubble> factory)
		{
			_factory = factory;

        }

        public void ReturnBubble(Bubble bubble, BubbleColor color, int bubbleNumber)
		{
            bubble.gameObject.SetActive(false);
            _bubbles[color].Add(bubble);
			OnReturned?.Invoke(bubbleNumber);
        }
	}
}