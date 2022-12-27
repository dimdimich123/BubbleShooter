using GameCore.Grids;
using GameCore.Guns;

namespace Infrastructure.FieldBuilders
{
    public interface ILevelBuilder
    {
        public void Build(BubbleGrid grid, GunRandomPool pool);
    }
}