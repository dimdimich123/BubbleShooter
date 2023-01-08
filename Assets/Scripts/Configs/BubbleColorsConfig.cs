using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameCore.CommonLogic;

namespace Configs
{
    /// <summary>
    /// Stores the correspondence of <see cref="BubbleColor"/> to <see cref="Color"/>
    /// </summary>
    [CreateAssetMenu(fileName = "BubbleColorsConfig", menuName = "Configs/BubbleColorsConfig", order = 2)]
    public sealed class BubbleColorsConfig : ScriptableObject
    {
        [SerializeField] private BubbleColorPair[] _colors;

        private Dictionary<BubbleColor, Color> _bubbleColors = new Dictionary<BubbleColor, Color>();

        private void OnEnable()
        {
            _bubbleColors = _colors.ToDictionary(x => x.ColorKey, y => y.ColorValue);
        }

        public Color GetColor(BubbleColor color) => _bubbleColors.TryGetValue(color, out Color result) ? result : Color.white;
        

    }

    
}