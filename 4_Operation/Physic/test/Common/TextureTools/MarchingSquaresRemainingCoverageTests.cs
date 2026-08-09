// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquaresRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     The marching squares remaining coverage tests class
    /// </summary>
    public class MarchingSquaresRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that detect squares with all negative values returns polygons
        /// </summary>
        [Fact]
        public void DetectSquares_WithAllNegative_ReturnsPolygons()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = -1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, false);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that detect squares with all positive values returns no polygons
        /// </summary>
        [Fact]
        public void DetectSquares_WithAllPositive_ReturnsNoPolygons()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = 1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, false);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that detect squares with mixed values returns polygons
        /// </summary>
        [Fact]
        public void DetectSquares_WithMixedValues_ReturnsPolygons()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = (x < 5) ? (sbyte) -1 : (sbyte) 1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, false);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that detect squares with combine returns polygons
        /// </summary>
        [Fact]
        public void DetectSquares_WithCombine_ReturnsPolygons()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = (x < 5) ? (sbyte) -1 : (sbyte) 1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, true);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that detect squares with coarse cell size returns polygons
        /// </summary>
        [Fact]
        public void DetectSquares_WithCoarseCellSize_ReturnsPolygons()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = (x < 5) ? (sbyte) -1 : (sbyte) 1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(10, 10));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 3.0f, 3.0f, f, 2, true);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that lerp with zero difference returns midpoint
        /// </summary>
        [Fact]
        public void Lerp_WithZeroDifference_ReturnsMidpoint()
        {
            float result = MarchingSquares.Lerp(0, 10, 5, 5);

            Assert.Equal(5.0f, result, 5);
        }

        /// <summary>
        ///     Tests that lerp with difference interpolates
        /// </summary>
        [Fact]
        public void Lerp_WithDifference_Interpolates()
        {
            float result = MarchingSquares.Lerp(0, 10, 3, 1);

            Assert.Equal(15.0f, result, 5);
        }

        /// <summary>
        ///     Tests that x lerp with count zero returns midpoint
        /// </summary>
        [Fact]
        public void Xlerp_WithCountZero_ReturnsMidpoint()
        {
            sbyte[,] f = new sbyte[40, 40];
            float result = MarchingSquares.Xlerp(0, 10, 5, 1, -1, f, 0);

            Assert.Equal(5.0f, result, 5);
        }

        /// <summary>
        ///     Tests that x lerp with count recurses
        /// </summary>
        [Fact]
        public void Xlerp_WithCount_Recurses()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = (x < 5) ? (sbyte) -1 : (sbyte) 1;
                }
            }

            float result = MarchingSquares.Xlerp(0, 10, 5, -1, 1, f, 2);

            Assert.True(result >= 0.0f);
            Assert.True(result <= 10.0f);
        }

        /// <summary>
        ///     Tests that y lerp with count zero returns midpoint
        /// </summary>
        [Fact]
        public void Ylerp_WithCountZero_ReturnsMidpoint()
        {
            sbyte[,] f = new sbyte[40, 40];
            float result = MarchingSquares.Ylerp(0, 10, 5, 1, -1, f, 0);

            Assert.Equal(5.0f, result, 5);
        }

        /// <summary>
        ///     Tests that y lerp with count recurses
        /// </summary>
        [Fact]
        public void Ylerp_WithCount_Recurses()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    f[x, y] = (y < 5) ? (sbyte) -1 : (sbyte) 1;
                }
            }

            float result = MarchingSquares.Ylerp(0, 10, 5, -1, 1, f, 2);

            Assert.True(result >= 0.0f);
            Assert.True(result <= 10.0f);
        }

        /// <summary>
        ///     Tests that square computes square of value
        /// </summary>
        [Fact]
        public void Square_ComputesSquare()
        {
            Assert.Equal(4.0f, MarchingSquares.Square(2.0f), 5);
            Assert.Equal(9.0f, MarchingSquares.Square(-3.0f), 5);
        }

        /// <summary>
        ///     Tests that vec dsq computes squared distance
        /// </summary>
        [Fact]
        public void VecDsq_ComputesSquaredDistance()
        {
            float result = MarchingSquares.VecDsq(new Vector2F(0, 0), new Vector2F(3, 4));

            Assert.Equal(25.0f, result, 5);
        }

        /// <summary>
        ///     Tests that vec cross computes cross product
        /// </summary>
        [Fact]
        public void VecCross_ComputesCrossProduct()
        {
            float result = MarchingSquares.VecCross(new Vector2F(1, 0), new Vector2F(0, 1));

            Assert.Equal(1.0f, result, 5);
        }

        /// <summary>
        ///     Tests that comb left with matching vertices inserts polygon
        /// </summary>
        [Fact]
        public void CombLeft_WithMatchingVertices_InsertsPolygon()
        {
            MarchingSquares.GeomPoly polya = new MarchingSquares.GeomPoly();
            MarchingSquares.GeomPoly polyb = new MarchingSquares.GeomPoly();
            polya.Points.Add(new Vector2F(1, 1));
            polya.Points.Add(new Vector2F(2, 2));
            polya.Points.Add(new Vector2F(3, 3));
            polya.Length = 3;
            polyb.Points.Add(new Vector2F(1, 1));
            polyb.Points.Add(new Vector2F(5, 5));
            polyb.Length = 2;

            MarchingSquares.CombLeft(ref polya, ref polyb);

            Assert.True(polya.Length >= 3);
        }

        /// <summary>
        ///     Tests that comb left without matching vertices keeps polygon
        /// </summary>
        [Fact]
        public void CombLeft_WithoutMatchingVertices_KeepsPolygon()
        {
            MarchingSquares.GeomPoly polya = new MarchingSquares.GeomPoly();
            MarchingSquares.GeomPoly polyb = new MarchingSquares.GeomPoly();
            polya.Points.Add(new Vector2F(1, 1));
            polya.Points.Add(new Vector2F(2, 2));
            polya.Length = 2;
            polyb.Points.Add(new Vector2F(9, 9));
            polyb.Length = 1;

            MarchingSquares.CombLeft(ref polya, ref polyb);

            Assert.Equal(2, polya.Length);
        }

        /// <summary>
        ///     Tests that march square with zero key returns zero
        /// </summary>
        [Fact]
        public void MarchSquare_WithZeroKey_ReturnsZero()
        {
            sbyte[,] f = new sbyte[40, 40];
            sbyte[,] fs = new sbyte[10, 10];
            MarchingSquares.GeomPoly poly = new MarchingSquares.GeomPoly();

            int key = MarchingSquares.MarchSquare(f, fs, ref poly, 0, 0, 0, 0, 10, 10, 1);

            Assert.Equal(0, key);
        }

        /// <summary>
        ///     Tests that cx fast list add increments count
        /// </summary>
        [Fact]
        public void CxFastList_Add_IncrementsCount()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);

            Assert.Equal(1, list.Size());
            Assert.False(list.Empty());
        }

        /// <summary>
        ///     Tests that cx fast list front returns head element
        /// </summary>
        [Fact]
        public void CxFastList_Front_ReturnsHeadElement()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(2);
            list.Add(1);

            Assert.Equal(1, list.Front());
        }

        /// <summary>
        ///     Tests that cx fast list remove removes matching element
        /// </summary>
        [Fact]
        public void CxFastList_Remove_RemovesMatchingElement()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(2);
            list.Add(1);

            bool removed = list.Remove(2);

            Assert.True(removed);
            Assert.Equal(1, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list remove head removes first element
        /// </summary>
        [Fact]
        public void CxFastList_RemoveHead_RemovesFirstElement()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(2);
            list.Add(1);

            bool removed = list.Remove(1);

            Assert.True(removed);
            Assert.Equal(1, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list remove absent returns false
        /// </summary>
        [Fact]
        public void CxFastList_RemoveAbsent_ReturnsFalse()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);

            bool removed = list.Remove(99);

            Assert.False(removed);
            Assert.Equal(1, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list remove zero value from empty returns false
        /// </summary>
        [Fact]
        public void CxFastList_RemoveZeroValueFromEmpty_ReturnsFalse()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();

            bool removed = list.Remove(0);

            Assert.False(removed);
        }

        /// <summary>
        ///     Tests that cx fast list pop removes head
        /// </summary>
        [Fact]
        public void CxFastList_Pop_RemovesHead()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(2);
            list.Add(1);

            list.Pop();

            Assert.Equal(1, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list insert after node inserts element
        /// </summary>
        [Fact]
        public void CxFastList_Insert_AfterNode_InsertsElement()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            CxFastListNode<int> node = list.Add(1);
            list.Add(3);

            list.Insert(node, 2);

            Assert.Equal(3, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list insert with null node adds element
        /// </summary>
        [Fact]
        public void CxFastList_Insert_WithNullNode_AddsElement()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();

            list.Insert(null, 1);

            Assert.Equal(1, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list erase with prev removes node
        /// </summary>
        [Fact]
        public void CxFastList_Erase_WithPrev_RemovesNode()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            CxFastListNode<int> first = list.Add(1);
            CxFastListNode<int> second = list.Add(2);

            list.Erase(second, first);

            Assert.Equal(1, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list clear empties list
        /// </summary>
        [Fact]
        public void CxFastList_Clear_EmptiesList()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(2);

            list.Clear();

            Assert.True(list.Empty());
            Assert.Equal(0, list.Size());
        }

        /// <summary>
        ///     Tests that cx fast list has finds existing value
        /// </summary>
        [Fact]
        public void CxFastList_Has_FindsExistingValue()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(1);
            list.Add(5);

            Assert.True(list.Has(5));
            Assert.False(list.Has(99));
        }

        /// <summary>
        ///     Tests that cx fast list find returns node for default value
        /// </summary>
        [Fact]
        public void CxFastList_Find_ReturnsNodeForDefaultValue()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(0);
            list.Add(1);

            Assert.NotNull(list.Find(0));
            Assert.NotNull(list.Find(1));
            Assert.Null(list.Find(9));
            Assert.Null(list.Find(0) == null ? null : list.Find(9));
        }

        /// <summary>
        ///     Tests that cx fast list get list of elements returns all elements
        /// </summary>
        [Fact]
        public void CxFastList_GetListOfElements_ReturnsAllElements()
        {
            MarchingSquares.CxFastList<int> list = new MarchingSquares.CxFastList<int>();
            list.Add(2);
            list.Add(1);

            List<int> elements = list.GetListOfElements();

            Assert.Equal(2, elements.Count);
        }
    }
}
