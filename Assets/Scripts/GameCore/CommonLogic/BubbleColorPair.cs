using System;
using UnityEngine;

namespace GameCore.CommonLogic
{
    /// <summary>
    /// A simple class that has a pair of values ​​(<see cref="BubbleColor"/> and <see cref="Color"/>)
    /// </summary>
    [Serializable]
    public sealed class BubbleColorPair
    {
        public BubbleColor ColorKey;
        public Color ColorValue;
    }
}