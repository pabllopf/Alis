using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common.TextureTools;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    /// The terrain test class
    /// </summary>
    public class TerrainTest
    {
        /// <summary>
        /// Tests that constructor with aabb sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithAabb_SetsProperties()
        {
            Aabb area = new Aabb(new Vector2F(0, 0), new Vector2F(100, 100));
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, area);

            Assert.Equal(100f, terrain.Width);
            Assert.Equal(100f, terrain.Height);
            Assert.Equal(new Vector2F(50, 50), terrain.Center);
        }

        /// <summary>
        /// Tests that constructor with position and size sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithPositionAndSize_SetsProperties()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 200);

            Assert.Equal(100f, terrain.Width);
            Assert.Equal(200f, terrain.Height);
            Assert.Equal(new Vector2F(50, 50), terrain.Center);
        }

        /// <summary>
        /// Tests that initialize sets up internal structures
        /// </summary>
        [Fact]
        public void Initialize_SetsUpInternalStructures()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;

            terrain.Initialize();

            Assert.NotNull(terrain._terrainMap);
            Assert.NotNull(terrain._bodyMap);
        }

        /// <summary>
        /// Tests that apply data with in bounds data writes to terrain map
        /// </summary>
        [Fact]
        public void ApplyData_WithInBoundsData_WritesToTerrainMap()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
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

            Assert.Equal(-1, terrain._terrainMap[5, 5]);
        }

        /// <summary>
        /// Tests that apply data with out of bounds offset does not write
        /// </summary>
        [Fact]
        public void ApplyData_WithOutOfBoundsOffset_DoesNotWrite()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            sbyte originalValue = terrain._terrainMap[0, 0];
            sbyte[,] data = new sbyte[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    data[x, y] = -1;
                }
            }

            terrain.ApplyData(data, new Vector2F(-1000, -1000));

            Assert.Equal(originalValue, terrain._terrainMap[0, 0]);
        }

        /// <summary>
        /// Tests that modify terrain with valid coordinates updates terrain and dirty area
        /// </summary>
        [Fact]
        public void ModifyTerrain_WithValidCoordinates_UpdatesTerrainAndDirtyArea()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            Vector2F location = terrain._topLeft + new Vector2F(1, -1);
            terrain.ModifyTerrain(location, -1);

            Assert.Equal(-1, terrain._terrainMap[2, 2]);
        }

        /// <summary>
        /// Tests that modify terrain with out of bounds coordinates does nothing
        /// </summary>
        [Fact]
        public void ModifyTerrain_WithOutOfBoundsCoordinates_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            sbyte originalValue = terrain._terrainMap[0, 0];
            Vector2F farAway = new Vector2F(-1000, -1000);
            terrain.ModifyTerrain(farAway, -1);

            Assert.Equal(originalValue, terrain._terrainMap[0, 0]);
        }

        /// <summary>
        /// Tests that regenerate terrain resets dirty area
        /// </summary>
        [Fact]
        public void RegenerateTerrain_ResetsDirtyArea()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            Vector2F location = terrain._topLeft + new Vector2F(1, -1);
            terrain.ModifyTerrain(location, -1);
            terrain.RegenerateTerrain();

            Assert.Equal(float.MaxValue, terrain._dirtyArea.LowerBound.X);
            Assert.Equal(float.MinValue, terrain._dirtyArea.UpperBound.X);
        }

        /// <summary>
        /// Tests that regenerate terrain clamps bounds to grid
        /// </summary>
        [Fact]
        public void RegenerateTerrain_ClampsBoundsToGrid()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            terrain._dirtyArea = new Aabb(
                new Vector2F(-1000, -1000),
                new Vector2F(1000, 1000)
            );
            terrain.RegenerateTerrain();

            Assert.Equal(float.MaxValue, terrain._dirtyArea.LowerBound.X);
            Assert.Equal(float.MinValue, terrain._dirtyArea.UpperBound.X);
        }

        /// <summary>
        /// Tests that remove old data with empty body map does not throw
        /// </summary>
        [Fact]
        public void RemoveOldData_WithEmptyBodyMap_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            terrain.RemoveOldData(0, 1, 0, 1);
        }

        /// <summary>
        /// Tests that generate terrain with uniform map returns early
        /// </summary>
        [Fact]
        public void GenerateTerrain_WithUniformMap_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic();
            Terrain terrain = new Terrain(world, new Vector2F(50, 50), 100, 100);
            terrain.PointsPerUnit = 2;
            terrain.CellSize = 10;
            terrain.SubCellSize = 2;
            terrain.Initialize();

            for (int x = 0; x < terrain._xnum; x++)
            {
                for (int y = 0; y < terrain._ynum; y++)
                {
                    terrain._bodyMap[x, y] = null;
                }
            }

            terrain.GenerateTerrain(0, 0);
        }
    }
}
