// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactVelocityConstraintTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    /// The contact velocity constraint test class
    /// </summary>
    public class ContactVelocityConstraintTest
    {
        /// <summary>
        /// Tests that default constructor should initialize points array
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializePointsArray()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.NotNull(constraint.Points);
            Assert.Equal(SettingEnv.MaxManifoldPoints, constraint.Points.Length);
        }

        /// <summary>
        /// Tests that default constructor should initialize contact index to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeContactIndexToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0, constraint.ContactIndex);
        }

        /// <summary>
        /// Tests that default constructor should initialize friction to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeFrictionToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0f, constraint.Friction);
        }

        /// <summary>
        /// Tests that default constructor should initialize index a to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeIndexAToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0, constraint.IndexA);
        }

        /// <summary>
        /// Tests that default constructor should initialize index b to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeIndexBToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0, constraint.IndexB);
        }

        /// <summary>
        /// Tests that default constructor should initialize point count to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializePointCountToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0, constraint.PointCount);
        }

        /// <summary>
        /// Tests that default constructor should initialize restitution to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeRestitutionToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0f, constraint.Restitution);
        }

        /// <summary>
        /// Tests that default constructor should initialize tangent speed to zero
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeTangentSpeedToZero()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint();

            Assert.Equal(0f, constraint.TangentSpeed);
        }

        /// <summary>
        /// Tests that contact index should set and get correctly
        /// </summary>
        [Fact]
        public void ContactIndex_ShouldSetAndGetCorrectly()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                ContactIndex = 5
            };

            Assert.Equal(5, constraint.ContactIndex);
        }

        /// <summary>
        /// Tests that friction should set and get correctly
        /// </summary>
        [Fact]
        public void Friction_ShouldSetAndGetCorrectly()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                Friction = 0.5f
            };

            Assert.Equal(0.5f, constraint.Friction);
        }

        /// <summary>
        /// Tests that index a should set and get correctly
        /// </summary>
        [Fact]
        public void IndexA_ShouldSetAndGetCorrectly()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                IndexA = 2
            };

            Assert.Equal(2, constraint.IndexA);
        }

        /// <summary>
        /// Tests that index b should set and get correctly
        /// </summary>
        [Fact]
        public void IndexB_ShouldSetAndGetCorrectly()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
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
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                PointCount = 2
            };

            Assert.Equal(2, constraint.PointCount);
        }

        /// <summary>
        /// Tests that restitution should set and get correctly
        /// </summary>
        [Fact]
        public void Restitution_ShouldSetAndGetCorrectly()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                Restitution = 0.8f
            };

            Assert.Equal(0.8f, constraint.Restitution);
        }

        /// <summary>
        /// Tests that tangent speed should set and get correctly
        /// </summary>
        [Fact]
        public void TangentSpeed_ShouldSetAndGetCorrectly()
        {
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                TangentSpeed = 2.5f
            };

            Assert.Equal(2.5f, constraint.TangentSpeed);
        }

        /// <summary>
        /// Tests that normal should set and get correctly
        /// </summary>
        [Fact]
        public void Normal_ShouldSetAndGetCorrectly()
        {
            Vector2F normal = new Vector2F(0f, 1f);
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                Normal = normal
            };

            Assert.Equal(normal, constraint.Normal);
        }

        /// <summary>
        /// Tests that k matrix should set and get correctly
        /// </summary>
        [Fact]
        public void K_ShouldSetAndGetCorrectly()
        {
            Mat22 k = new Mat22(1f, 2f, 3f, 4f);
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                K = k
            };

            Assert.Equal(k, constraint.K);
        }

        /// <summary>
        /// Tests that normal mass should set and get correctly
        /// </summary>
        [Fact]
        public void NormalMass_ShouldSetAndGetCorrectly()
        {
            Mat22 normalMass = new Mat22(1f, 0f, 0f, 1f);
            ContactVelocityConstraint constraint = new ContactVelocityConstraint
            {
                NormalMass = normalMass
            };

            Assert.Equal(normalMass, constraint.NormalMass);
        }
    }
}
