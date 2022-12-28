// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Terrain.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Factories;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Tools.PolygonManipulation;
using Alis.Core.Physic.Tools.Triangulation.TriangulationBase;

namespace Alis.Core.Physic.Tools.TextureTools
{
    /// <summary>Simple class to maintain a terrain. It can keep track</summary>
    public class Terrain
    {
        /// <summary>Generated bodies.</summary>
        private List<Body>[,] bodyMap;

        /// <summary>Points per cell.</summary>
        public int CellSize;

        /// <summary>Center of terrain in world units.</summary>
        public Vector2F Center;

        /// <summary>
        ///     Decomposer to use when regenerating terrain. Can be changed on the fly without consequence. Note: Some
        ///     decomposerers are unstable.
        /// </summary>
        public TriangulationAlgorithm Decomposer;

        /// <summary>
        ///     The dirty area
        /// </summary>
        private Aabb dirtyArea;

        /// <summary>Height of terrain in world units.</summary>
        public float Height;

        /// <summary>
        ///     Number of iterations to perform in the Marching Squares algorithm. Note: More then 3 has almost no effect on
        ///     quality.
        /// </summary>
        public int Iterations = 2;

        /// <summary>
        ///     The local height
        /// </summary>
        private float localHeight;

        /// <summary>
        ///     The local width
        /// </summary>
        private float localWidth;

        /// <summary>Points per each world unit used to define the terrain in the point cloud.</summary>
        public int PointsPerUnit;

        /// <summary>Points per sub cell.</summary>
        public int SubCellSize;

        /// <summary>Point cloud defining the terrain.</summary>
        private sbyte[,] terrainMap;

        /// <summary>
        ///     The top left
        /// </summary>
        private Vector2F topLeft;

        /// <summary>Width of terrain in world units.</summary>
        public float Width;

        /// <summary>World to manage terrain in.</summary>
        public World World;

        /// <summary>
        ///     The xnum
        /// </summary>
        private int xnum;

        /// <summary>
        ///     The ynum
        /// </summary>
        private int ynum;

        /// <summary>Creates a new terrain.</summary>
        /// <param name="world">The World</param>
        /// <param name="area">The area of the terrain.</param>
        public Terrain(World world, Aabb area)
        {
            World = world;
            Width = area.Width;
            Height = area.Height;
            Center = area.Center;
        }

        /// <summary>Creates a new terrain</summary>
        /// <param name="world">The World</param>
        /// <param name="position">The position (center) of the terrain.</param>
        /// <param name="width">The width of the terrain.</param>
        /// <param name="height">The height of the terrain.</param>
        public Terrain(World world, Vector2F position, float width, float height)
        {
            World = world;
            Width = width;
            Height = height;
            Center = position;
        }

        /// <summary>Initialize the terrain for use.</summary>
        public void Initialize()
        {
            // find top left of terrain in world space
            topLeft = new Vector2F(Center.X - Width * 0.5f, Center.Y - -Height * 0.5f);

            // convert the terrains size to a point cloud size
            localWidth = Width * PointsPerUnit;
            localHeight = Height * PointsPerUnit;

            terrainMap = new sbyte[(int) localWidth + 1, (int) localHeight + 1];

            for (int x = 0; x < localWidth; x++)
            {
                for (int y = 0; y < localHeight; y++)
                {
                    terrainMap[x, y] = 1;
                }
            }

            xnum = (int) (localWidth / CellSize);
            ynum = (int) (localHeight / CellSize);
            bodyMap = new List<Body>[xnum, ynum];

            // make sure to mark the dirty area to an infinitely small box
            dirtyArea = new Aabb(new Vector2F(float.MaxValue, float.MaxValue),
                new Vector2F(float.MinValue, float.MinValue));
        }

        /// <summary>Apply the specified texture data to the terrain.</summary>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        public void ApplyData(sbyte[,] data, Vector2F offset = default(Vector2F))
        {
            for (int x = 0; x < data.GetUpperBound(0); x++)
            {
                for (int y = 0; y < data.GetUpperBound(1); y++)
                {
                    if ((x + offset.X >= 0) && (x + offset.X < localWidth) && (y + offset.Y >= 0) &&
                        (y + offset.Y < localHeight))
                    {
                        terrainMap[(int) (x + offset.X), (int) (y + offset.Y)] = data[x, y];
                    }
                }
            }

            RemoveOldData(0, xnum, 0, ynum);
        }

        /// <summary>Modify a single point in the terrain.</summary>
        /// <param name="location">World location to modify. Automatically clipped.</param>
        /// <param name="value">-1 = inside terrain, 1 = outside terrain</param>
        public void ModifyTerrain(Vector2F location, sbyte value)
        {
            // find local position
            // make position local to map space
            Vector2F p = location - topLeft;

            // find map position for each axis
            p.X = p.X * localWidth / Width;
            p.Y = p.Y * -localHeight / Height;

            if ((p.X >= 0) && (p.X < localWidth) && (p.Y >= 0) && (p.Y < localHeight))
            {
                terrainMap[(int) p.X, (int) p.Y] = value;

                unchecked
                {
                    // expand dirty area
                    if (p.X < (int) dirtyArea.LowerBound.X)
                    {
                        dirtyArea.LowerBound.X = p.X;
                    }

                    if (p.X > (int) dirtyArea.UpperBound.X)
                    {
                        dirtyArea.UpperBound.X = p.X;
                    }

                    if (p.Y < (int) dirtyArea.LowerBound.Y)
                    {
                        dirtyArea.LowerBound.Y = p.Y;
                    }

                    if (p.Y > (int) dirtyArea.UpperBound.Y)
                    {
                        dirtyArea.UpperBound.Y = p.Y;
                    }
                }
            }
        }

        /// <summary>Regenerate the terrain.</summary>
        public void RegenerateTerrain()
        {
            unchecked
            {
                //iterate effected cells
                int xStart = (int) (dirtyArea.LowerBound.X / CellSize);
                if (xStart < 0)
                {
                    xStart = 0;
                }

                int xEnd = (int) (dirtyArea.UpperBound.X / CellSize) + 1;
                if (xEnd > xnum)
                {
                    xEnd = xnum;
                }

                int yStart = (int) (dirtyArea.LowerBound.Y / CellSize);
                if (yStart < 0)
                {
                    yStart = 0;
                }

                int yEnd = (int) (dirtyArea.UpperBound.Y / CellSize) + 1;
                if (yEnd > ynum)
                {
                    yEnd = ynum;
                }

                RemoveOldData(xStart, xEnd, yStart, yEnd);

                dirtyArea = new Aabb(new Vector2F(float.MaxValue, float.MaxValue),
                    new Vector2F(float.MinValue, float.MinValue));
            }
        }

        /// <summary>
        ///     Removes the old data using the specified x start
        /// </summary>
        /// <param name="xStart">The start</param>
        /// <param name="xEnd">The end</param>
        /// <param name="yStart">The start</param>
        /// <param name="yEnd">The end</param>
        private void RemoveOldData(int xStart, int xEnd, int yStart, int yEnd)
        {
            for (int x = xStart; x < xEnd; x++)
            {
                for (int y = yStart; y < yEnd; y++)
                {
                    //remove old terrain object at grid cell
                    if (bodyMap[x, y] != null)
                    {
                        for (int i = 0; i < bodyMap[x, y].Count; i++)
                        {
                            World.RemoveBody(bodyMap[x, y][i]);
                        }
                    }

                    bodyMap[x, y] = null;

                    //generate new one
                    GenerateTerrain(x, y);
                }
            }
        }

        /// <summary>
        ///     Generates the terrain using the specified gx
        /// </summary>
        /// <param name="gx">The gx</param>
        /// <param name="gy">The gy</param>
        private void GenerateTerrain(int gx, int gy)
        {
            float ax = gx * CellSize;
            float ay = gy * CellSize;

            List<Vertices> polys = MarchingSquares.DetectSquares(
                new Aabb(new Vector2F(ax, ay), new Vector2F(ax + CellSize, ay + CellSize)), SubCellSize, SubCellSize,
                terrainMap, Iterations, true);
            if (polys.Count == 0)
            {
                return;
            }

            bodyMap[gx, gy] = new List<Body>();

            // create the scale vector
            Vector2F scale = new Vector2F(1f / PointsPerUnit, 1f / -PointsPerUnit);

            // create physics object for this grid cell
            foreach (Vertices item in polys)
            {
                // does this need to be negative?
                item.Scale(ref scale);
                item.Translate(ref topLeft);
                Vertices simplified = SimplifyTools.CollinearSimplify(item);

                List<Vertices> decompPolys = Triangulate.ConvexPartition(simplified, Decomposer);

                foreach (Vertices poly in decompPolys)
                {
                    if (poly.Count > 2)
                    {
                        bodyMap[gx, gy].Add(BodyFactory.CreatePolygon(World, poly, 1));
                    }
                }
            }
        }
    }
}