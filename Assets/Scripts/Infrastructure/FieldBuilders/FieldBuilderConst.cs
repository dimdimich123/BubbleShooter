using GameCore.Bubbles;
using GameCore.CommonLogic;
using GameCore.Grids;
using System.Collections.Generic;
using UnityEngine;
using GameCore.Guns;

namespace Infrastructure.FieldBuilders
{
    /// <summary>
    /// Fills the playing field with <see cref="Bubble"/> from the permanent level configuration
    /// </summary>
    public class LevelBuilderConst : ILevelBuilder
    {
        private BubblePositionData[] _bubbles;

        public LevelBuilderConst(BubblePositionData[] bubbles)
        {
            _bubbles = bubbles;
        }

        public void Build(BubbleGrid grid, GunRandomPool pool)
        {
            GameObject fieldParent = new GameObject("Field");

            for(int i = 0; i < _bubbles.Length; i++)
            {
                Bubble bubble = pool.GetBubble(_bubbles[i].Color);
                bubble.gameObject.name = "Hex_" + _bubbles[i].PositionX + "_" + _bubbles[i].PositionY;
                bubble.transform.parent = fieldParent.transform;
                grid.SetBubble(bubble, bubble.transform, _bubbles[i].PositionX, _bubbles[i].PositionY);
                List<Bubble> bubbles = grid.CheckAround(bubble.transform.position, bubble.Color);
                for (int j = 0; j < bubbles.Count; ++j)
                {
                    if (bubbles[j].Group != bubble.Group)
                    {
                        bubble.Group.Union(bubbles[j].Group);
                    }
                }
            }
        }
    }
}