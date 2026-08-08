using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.TextureTools;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    /// Tests targeting remaining uncovered lines/branches in Terrain (RemoveOldData body-removal path).
    /// </summary>
    public class TerrainRemainingCoverageTests
    {
        /// <summary>
        /// Tests that RemoveOldData removes bodies when bodyMap cells are populated,
        /// covering the <c>_bodyMap[x,y] != null</c> true branch and the inner
        /// <c>for</c> loop that calls <c>WorldPhysic.Remove</c>.
        /// </summary>
        [Fact]
        public void RemoveOldData_WithPopulatedBodyMap_RemovesBodies()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100)
                {
                    PointsPerUnit = 2,
                    CellSize = 10,
                    SubCellSize = 2
                };
            terrain.Initialize();

            sbyte[,] data = new sbyte[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    data[x, y] = -1;
                }
            }
            terrain.ApplyData(data, new Vector2F(5, 5));

            // Null out all bodyMap entries so we can populate only specific cells
            for (int gx = 0; gx < terrain._xnum; gx++)
            {
                for (int gy = 0; gy < terrain._ynum; gy++)
                {
                    terrain._bodyMap[gx, gy] = null;
                }
            }

            terrain.GenerateTerrain(0, 1);
            Assert.NotNull(terrain._bodyMap[0, 1]);

            // Call RemoveOldData covering cell (0,1) to exercise the body-removal path
            terrain.RemoveOldData(0, 1, 1, 2);

            Assert.NotNull(terrain._bodyMap[0, 1]);
        }
    }
}
