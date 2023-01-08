using GameCore.Grids;
using GameCore.Guns;

namespace Infrastructure.FieldBuilders
{
    /// <summary>
    /// Field builder interface
    /// </summary>
    public interface ILevelBuilder
    {
        public void Build(BubbleGrid grid, GunRandomPool pool);
    }
}