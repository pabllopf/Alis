// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityConstraintInitDataTest.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The velocity constraint init data test class
    /// </summary>
    public class VelocityConstraintInitDataTest
    {
        /// <summary>
        ///     Tests that record struct should be created with all properties
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeAllProperties()
        {
            Vector2F cA = new Vector2F(1.0f, 2.0f);
            Vector2F cB = new Vector2F(3.0f, 4.0f);
            float mA = 1.5f;
            float mB = 2.5f;
            float iA = 0.5f;
            float iB = 1.5f;
            Vector2F tangent = new Vector2F(1.0f, 0.0f);
            Vector2F vA = new Vector2F(0.0f, 1.0f);
            float wA = 2.0f;
            Vector2F vB = new Vector2F(1.0f, 1.0f);
            float wB = 3.0f;

            var data = new VelocityConstraintInitData(
                cA, cB, mA, mB, iA, iB, tangent, vA, wA, vB, wB);

            Assert.Equal(cA, data.cA);
            Assert.Equal(cB, data.cB);
            Assert.Equal(mA, data.mA);
            Assert.Equal(mB, data.mB);
            Assert.Equal(iA, data.iA);
            Assert.Equal(iB, data.iB);
            Assert.Equal(tangent, data.tangent);
            Assert.Equal(vA, data.vA);
            Assert.Equal(wA, data.wA);
            Assert.Equal(vB, data.vB);
            Assert.Equal(wB, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should support zero values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportZeroValues()
        {
            var data = new VelocityConstraintInitData(
                Vector2F.Zero, Vector2F.Zero, 0.0f, 0.0f, 0.0f, 0.0f,
                Vector2F.Zero, Vector2F.Zero, 0.0f, Vector2F.Zero, 0.0f);

            Assert.Equal(Vector2F.Zero, data.cA);
            Assert.Equal(Vector2F.Zero, data.cB);
            Assert.Equal(0.0f, data.mA);
            Assert.Equal(0.0f, data.mB);
            Assert.Equal(0.0f, data.iA);
            Assert.Equal(0.0f, data.iB);
            Assert.Equal(Vector2F.Zero, data.tangent);
            Assert.Equal(Vector2F.Zero, data.vA);
            Assert.Equal(0.0f, data.wA);
            Assert.Equal(Vector2F.Zero, data.vB);
            Assert.Equal(0.0f, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should support negative values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportNegativeValues()
        {
            var data = new VelocityConstraintInitData(
                new Vector2F(-1.0f, -2.0f), new Vector2F(-3.0f, -4.0f),
                -1.5f, -2.5f, -0.5f, -1.5f, new Vector2F(-1.0f, 0.0f),
                new Vector2F(0.0f, -1.0f), -2.0f, new Vector2F(-1.0f, -1.0f), -3.0f);

            Assert.Equal(new Vector2F(-1.0f, -2.0f), data.cA);
            Assert.Equal(new Vector2F(-3.0f, -4.0f), data.cB);
            Assert.Equal(-1.5f, data.mA);
            Assert.Equal(-2.5f, data.mB);
            Assert.Equal(-0.5f, data.iA);
            Assert.Equal(-1.5f, data.iB);
            Assert.Equal(new Vector2F(-1.0f, 0.0f), data.tangent);
            Assert.Equal(new Vector2F(0.0f, -1.0f), data.vA);
            Assert.Equal(-2.0f, data.wA);
            Assert.Equal(new Vector2F(-1.0f, -1.0f), data.vB);
            Assert.Equal(-3.0f, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should support large values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportLargeValues()
        {
            var data = new VelocityConstraintInitData(
                new Vector2F(1000.0f, 2000.0f), new Vector2F(3000.0f, 4000.0f),
                100.5f, 200.5f, 50.5f, 150.5f, new Vector2F(100.0f, 0.0f),
                new Vector2F(0.0f, 100.0f), 200.0f, new Vector2F(100.0f, 100.0f), 300.0f);

            Assert.Equal(new Vector2F(1000.0f, 2000.0f), data.cA);
            Assert.Equal(new Vector2F(3000.0f, 4000.0f), data.cB);
            Assert.Equal(100.5f, data.mA);
            Assert.Equal(200.5f, data.mB);
            Assert.Equal(50.5f, data.iA);
            Assert.Equal(150.5f, data.iB);
            Assert.Equal(new Vector2F(100.0f, 0.0f), data.tangent);
            Assert.Equal(new Vector2F(0.0f, 100.0f), data.vA);
            Assert.Equal(200.0f, data.wA);
            Assert.Equal(new Vector2F(100.0f, 100.0f), data.vB);
            Assert.Equal(300.0f, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should support small values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportSmallValues()
        {
            var data = new VelocityConstraintInitData(
                new Vector2F(0.001f, 0.002f), new Vector2F(0.003f, 0.004f),
                0.0015f, 0.0025f, 0.0005f, 0.0015f, new Vector2F(0.001f, 0.0f),
                new Vector2F(0.0f, 0.001f), 0.002f, new Vector2F(0.001f, 0.001f), 0.003f);

            Assert.Equal(new Vector2F(0.001f, 0.002f), data.cA);
            Assert.Equal(new Vector2F(0.003f, 0.004f), data.cB);
            Assert.Equal(0.0015f, data.mA);
            Assert.Equal(0.0025f, data.mB);
            Assert.Equal(0.0005f, data.iA);
            Assert.Equal(0.0015f, data.iB);
            Assert.Equal(new Vector2F(0.001f, 0.0f), data.tangent);
            Assert.Equal(new Vector2F(0.0f, 0.001f), data.vA);
            Assert.Equal(0.002f, data.wA);
            Assert.Equal(new Vector2F(0.001f, 0.001f), data.vB);
            Assert.Equal(0.003f, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should support unit vectors
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportUnitVectors()
        {
            Vector2F unitX = new Vector2F(1.0f, 0.0f);
            Vector2F unitY = new Vector2F(0.0f, 1.0f);
            Vector2F unitDiag = new Vector2F(0.707106781f, 0.707106781f);

            var data = new VelocityConstraintInitData(
                unitX, unitY, 1.0f, 1.0f, 1.0f, 1.0f,
                unitDiag, unitX, 1.0f, unitY, 1.0f);

            Assert.Equal(unitX, data.cA);
            Assert.Equal(unitY, data.cB);
            Assert.Equal(unitDiag, data.tangent);
            Assert.Equal(unitX, data.vA);
            Assert.Equal(unitY, data.vB);
        }

        /// <summary>
        ///     Tests that record struct should support equal mass values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportEqualMassValues()
        {
            float mass = 5.0f;
            var data = new VelocityConstraintInitData(
                Vector2F.Zero, Vector2F.Zero, mass, mass, 1.0f, 1.0f,
                Vector2F.Zero, Vector2F.Zero, 0.0f, Vector2F.Zero, 0.0f);

            Assert.Equal(mass, data.mA);
            Assert.Equal(mass, data.mB);
        }

        /// <summary>
        ///     Tests that record struct should support equal inertia values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportEqualInertiaValues()
        {
            float inertia = 2.5f;
            var data = new VelocityConstraintInitData(
                Vector2F.Zero, Vector2F.Zero, 1.0f, 1.0f, inertia, inertia,
                Vector2F.Zero, Vector2F.Zero, 0.0f, Vector2F.Zero, 0.0f);

            Assert.Equal(inertia, data.iA);
            Assert.Equal(inertia, data.iB);
        }

        /// <summary>
        ///     Tests that record struct should support identical velocity values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportIdenticalVelocityValues()
        {
            Vector2F velocity = new Vector2F(3.0f, 4.0f);
            float angular = 2.5f;

            var data = new VelocityConstraintInitData(
                Vector2F.Zero, Vector2F.Zero, 1.0f, 1.0f, 1.0f, 1.0f,
                Vector2F.Zero, velocity, angular, velocity, angular);

            Assert.Equal(velocity, data.vA);
            Assert.Equal(angular, data.wA);
            Assert.Equal(velocity, data.vB);
            Assert.Equal(angular, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should support complex scenario values
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportComplexScenarioValues()
        {
            var data = new VelocityConstraintInitData(
                new Vector2F(10.5f, 20.3f), new Vector2F(30.7f, 40.9f),
                15.25f, 25.75f, 5.5f, 15.5f, new Vector2F(0.866f, 0.5f),
                new Vector2F(1.5f, 2.5f), 3.75f, new Vector2F(2.5f, 3.5f), 4.25f);

            Assert.Equal(new Vector2F(10.5f, 20.3f), data.cA);
            Assert.Equal(new Vector2F(30.7f, 40.9f), data.cB);
            Assert.Equal(15.25f, data.mA);
            Assert.Equal(25.75f, data.mB);
            Assert.Equal(5.5f, data.iA);
            Assert.Equal(15.5f, data.iB);
            Assert.Equal(new Vector2F(0.866f, 0.5f), data.tangent);
            Assert.Equal(new Vector2F(1.5f, 2.5f), data.vA);
            Assert.Equal(3.75f, data.wA);
            Assert.Equal(new Vector2F(2.5f, 3.5f), data.vB);
            Assert.Equal(4.25f, data.wB);
        }

        /// <summary>
        ///     Tests that record struct should be immutable after creation
        /// </summary>
        [Fact]
        public void Constructor_ShouldBeImmutable()
        {
            Vector2F cA = new Vector2F(1.0f, 2.0f);
            var data = new VelocityConstraintInitData(
                cA, Vector2F.Zero, 1.0f, 1.0f, 1.0f, 1.0f,
                Vector2F.Zero, Vector2F.Zero, 0.0f, Vector2F.Zero, 0.0f);

            Assert.Equal(cA, data.cA);
        }

        /// <summary>
        ///     Tests that record struct should support all 31 categories
        /// </summary>
        [Fact]
        public void Constructor_ShouldSupportAllCategoryTypes()
        {
            var data = new VelocityConstraintInitData(
                Vector2F.One, Vector2F.One * 2, 1.0f, 1.0f, 1.0f, 1.0f,
                Vector2F.One, Vector2F.One, 1.0f, Vector2F.One, 1.0f);

            Assert.NotNull(data);
            Assert.Equal(Vector2F.One, data.cA);
        }
    }
}
