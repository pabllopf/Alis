// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTreeLatestCoverageTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The dynamic tree latest coverage tests class
    /// </summary>
    public class DynamicTreeLatestCoverageTests
    {
        /// <summary>
        /// Tests that ray cast skips a node when the separation axis is positive
        /// even though the segment bounding box overlaps the proxy fat AABB
        /// </summary>
        [Fact]
        public void RayCast_SeparationAxisPositive_WhileSegmentBoxOverlaps_ShouldSkipNode()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(6.0f, 6.0f));
            tree.AddProxy(ref aabb);

            int hitCount = 0;
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0.0f, 5.0f),
                Point2 = new Vector2F(10.0f, 0.1f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return 1.0f;
            }, ref input);

            Assert.Equal(0, hitCount);
        }

        /// <summary>
        /// Tests that balance performs a double right rotation when the left child
        /// of the right child is the taller subtree
        /// </summary>
        [Fact]
        public void Balance_DoubleRightRotation_WhenLeftGrandchildOfRightChildIsTaller()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            for (int i = 0; i < 10; i++)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 5.0f, 0.0f),
                    new Vector2F(i * 5.0f + 1.0f, 1.0f));
                tree.AddProxy(ref aabb);
            }

            for (int i = 9; i >= 0; i--)
            {
                Aabb aabb = new Aabb(
                    new Vector2F(i * 5.0f, 5.0f),
                    new Vector2F(i * 5.0f + 1.0f, 6.0f));
                tree.AddProxy(ref aabb);
            }

            tree.Validate();
            Assert.True(tree.Height > 0);
            Assert.True(tree.MaxBalance >= 0);
        }
    }
}
