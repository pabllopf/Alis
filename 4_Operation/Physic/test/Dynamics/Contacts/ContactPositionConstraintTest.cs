// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactPositionConstraintTest.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact position constraint test class
    /// </summary>
    public class ContactPositionConstraintTest
    {
        /// <summary>
        /// Tests that default constructor should initialize local points array
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeLocalPointsArray()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint();

            Assert.NotNull(constraint.LocalPoints);
            Assert.Equal(SettingEnv.MaxManifoldPoints, constraint.LocalPoints.Length);
        }

        /// <summary>
        /// Tests that default constructor should initialize index a to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeIndexAToZero()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint();

            Assert.Equal(0, constraint.IndexA);
        }

        /// <summary>
        /// Tests that default constructor should initialize index b to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeIndexBToZero()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint();

            Assert.Equal(0, constraint.IndexB);
        }

        /// <summary>
        /// Tests that default constructor should initialize point count to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializePointCountToZero()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint();

            Assert.Equal(0, constraint.PointCount);
        }

        /// <summary>
        /// Tests that default constructor should initialize radius a to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeRadiusAToZero()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint();

            Assert.Equal(0f, constraint.RadiusA);
        }

        /// <summary>
        /// Tests that default constructor should initialize radius b to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeRadiusBToZero()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint();

            Assert.Equal(0f, constraint.RadiusB);
        }

        /// <summary>
        /// Tests that index a should set and get correctly
        /// </summary>
        [Fact]
        public void IndexA_ShouldSetAndGetCorrectly()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                IndexA = 5
            };

            Assert.Equal(5, constraint.IndexA);
        }

        /// <summary>
        /// Tests that index b should set and get correctly
        /// </summary>
        [Fact]
        public void IndexB_ShouldSetAndGetCorrectly()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                IndexB = 3
            };

            Assert.Equal(3, constraint.IndexB);
        }

        /// <summary>
        /// Tests that point count should set and get correctly
        /// </summary>
        [Fact]
        public void PointCount_ShouldSetAndGetCorrectly()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                PointCount = 2
            };

            Assert.Equal(2, constraint.PointCount);
        }

        /// <summary>
        /// Tests that radius a should set and get correctly
        /// </summary>
        [Fact]
        public void RadiusA_ShouldSetAndGetCorrectly()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                RadiusA = 0.5f
            };

            Assert.Equal(0.5f, constraint.RadiusA);
        }

        /// <summary>
        /// Tests that radius b should set and get correctly
        /// </summary>
        [Fact]
        public void RadiusB_ShouldSetAndGetCorrectly()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                RadiusB = 1.0f
            };

            Assert.Equal(1.0f, constraint.RadiusB);
        }

        /// <summary>
        /// Tests that local normal should set and get correctly
        /// </summary>
        [Fact]
        public void LocalNormal_ShouldSetAndGetCorrectly()
        {
            Vector2F normal = new Vector2F(0f, 1f);
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                LocalNormal = normal
            };

            Assert.Equal(normal, constraint.LocalNormal);
        }

        /// <summary>
        /// Tests that local point should set and get correctly
        /// </summary>
        [Fact]
        public void LocalPoint_ShouldSetAndGetCorrectly()
        {
            Vector2F point = new Vector2F(1f, 2f);
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                LocalPoint = point
            };

            Assert.Equal(point, constraint.LocalPoint);
        }

        /// <summary>
        /// Tests that type should set and get correctly
        /// </summary>
        [Fact]
        public void Type_ShouldSetAndGetCorrectly()
        {
            ContactPositionConstraint constraint = new ContactPositionConstraint
            {
                Type = ManifoldType.FaceA
            };

            Assert.Equal(ManifoldType.FaceA, constraint.Type);
        }
    }
}
