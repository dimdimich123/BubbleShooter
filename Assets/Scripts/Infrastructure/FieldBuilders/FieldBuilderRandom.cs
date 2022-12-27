using GameCore.Bubbles;
using GameCore.Grids;
using GameCore.Guns;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.FieldBuilders
{
    public class LevelBuilderRandom : ILevelBuilder
    {
        public void Build(BubbleGrid grid, GunRandomPool pool)
        {
            GameObject fieldParent = new GameObject("Field");

            for (int y = 0; y < grid.Height - 4; ++y)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    Bubble bubble = pool.GetBubble();
                    bubble.gameObject.name = "Hex_" + x + "_" + y;
                    bubble.transform.parent = fieldParent.transform;
                    grid.SetBubble(bubble, bubble.transform, x, y);
                    List<Bubble> bubbles = grid.CheckAround(bubble.transform.position, bubble.Color);
                    for (int i = 0; i < bubbles.Count; ++i)
                    {
                        if (bubbles[i].Group != bubble.Group)
                        {
                            bubble.Group.Union(bubbles[i].Group);
                        }
                    }
                }
            }
        }
    }
}
