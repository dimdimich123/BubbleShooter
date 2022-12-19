using UnityEngine;
using GameCore.Bubbles;
using GameCore.CommonLogic;
using GameCore.Guns;
using GameCore.Grids;
using Configs;

namespace Infrastructure.Factories
{
    public sealed class BubbleFactory
    {
        private BubbleGrid _grid;
        private BubbleColorsConfig _colorsConfig;
        private GameObject _bubblePrefab;
        private float _speed;
        private bool _isStatic;

        public BubbleFactory(BubbleGrid grid, BubbleColorsConfig colorsConfig, GameObject bubblePrefab, float speed, bool isStatic)
        {
            _grid = grid;
            _colorsConfig = colorsConfig;
            _bubblePrefab = bubblePrefab;
            _speed = speed;
            _isStatic = isStatic;
        }

        public Bubble Create(BubbleColor color, GunBubblePool pool)
        {
            GameObject bubbleNew = Object.Instantiate(_bubblePrefab);
            Bubble bubble = bubbleNew.GetComponent<Bubble>();
            bubble.Init(_grid, color, pool, _speed, _isStatic);
            bubble.GetComponent<SpriteRenderer>().color = _colorsConfig.GetColor(color);
            return bubble;
        }
    }
}