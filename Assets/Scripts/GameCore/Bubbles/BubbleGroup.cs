using System.Collections.Generic;

namespace GameCore.Bubbles
{
    public sealed class BubbleGroup
    {
        private const int _maxCount = 3;

        private readonly List<Bubble> _bubbles;

        public BubbleGroup(Bubble bubble)
        {
            _bubbles = new List<Bubble> { bubble };
        }

        public void Add(Bubble bubble) => _bubbles.Add(bubble);

        public void Union(BubbleGroup group)
        {
            _bubbles.AddRange(group._bubbles);
            foreach(Bubble bubble in group._bubbles)
            {
                bubble.Group = this;
            }
        }

        public void TryPop()
        {
            if (_bubbles.Count >= _maxCount)
            {
                foreach (Bubble bubble in _bubbles)
                {
                    bubble.PopOnField();
                }
                _bubbles.Clear();
            }
        }
    }
}