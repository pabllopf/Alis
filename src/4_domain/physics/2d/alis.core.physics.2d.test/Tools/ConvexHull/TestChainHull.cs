// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TestChainHull.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Numerics;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Tools.ConvexHull;
using NUnit.Framework;

namespace Alis.Core.Systems.Physics2D.Test.Tools.ConvexHull
{
    /// <summary>
    ///     Test of class: Andrew's Monotone Chain Convex Hull algorithm. Used to get the convex hull of a point cloud.
    /// </summary>
    public class TestChainHull
    {
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        ///     Tests that test get convex hull
        /// </summary>
        [Test]
        public void TestGetConvexHull()
        {
            Vertices? vertices = new Vertices();
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(1, 0);
            Vector2 point3 = new Vector2(0, 1);

            vertices.Add(point1);
            vertices.Add(point2);
            vertices.Add(point3);

            Vertices? convexHull = ChainHull.GetConvexHull(vertices);

            Assert.AreEqual(convexHull.Count, 3);
            Assert.IsTrue(convexHull[0] == vertices[0]);
            Assert.IsTrue(convexHull[1] == vertices[1]);
            Assert.IsTrue(convexHull[2] == vertices[2]);
        }
    }
}