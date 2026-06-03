// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointTypeTest.cs
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

using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Joints
{
    /// <summary>
    ///     The joint type test class
    /// </summary>
    public class JointTypeTest
    {
        /// <summary>
        ///     Tests that unknown should have value zero
        /// </summary>
        [Fact]
        public void Unknown_ShouldHaveValueZero()
        {
            byte value = 0;
            Assert.Equal(value, (byte) JointType.Unknown);
        }

        /// <summary>
        ///     Tests that revolute should have value one
        /// </summary>
        [Fact]
        public void Revolute_ShouldHaveValueOne()
        {
            byte value = 1;
            Assert.Equal(value, (byte) JointType.Revolute);
        }

        /// <summary>
        ///     Tests that prismatic should have value two
        /// </summary>
        [Fact]
        public void Prismatic_ShouldHaveValueTwo()
        {
            byte value = 2;
            Assert.Equal(value, (byte) JointType.Prismatic);
        }

        /// <summary>
        ///     Tests that distance should have value three
        /// </summary>
        [Fact]
        public void Distance_ShouldHaveValueThree()
        {
            byte value = 3;
            Assert.Equal(value, (byte) JointType.Distance);
        }

        /// <summary>
        ///     Tests that pulley should have value four
        /// </summary>
        [Fact]
        public void Pulley_ShouldHaveValueFour()
        {
            byte value = 4;
            Assert.Equal(value, (byte) JointType.Pulley);
        }

        /// <summary>
        ///     Tests that gear should have value five
        /// </summary>
        [Fact]
        public void Gear_ShouldHaveValueFive()
        {
            byte value = 5;
            Assert.Equal(value, (byte) JointType.Gear);
        }

        /// <summary>
        ///     Tests that wheel should have value six
        /// </summary>
        [Fact]
        public void Wheel_ShouldHaveValueSix()
        {
            byte value = 6;
            Assert.Equal(value, (byte) JointType.Wheel);
        }

        /// <summary>
        ///     Tests that weld should have value seven
        /// </summary>
        [Fact]
        public void Weld_ShouldHaveValueSeven()
        {
            byte value = 7;
            Assert.Equal(value, (byte) JointType.Weld);
        }

        /// <summary>
        ///     Tests that friction should have value eight
        /// </summary>
        [Fact]
        public void Friction_ShouldHaveValueEight()
        {
            byte value = 8;
            Assert.Equal(value, (byte) JointType.Friction);
        }

        /// <summary>
        ///     Tests that rope should have value nine
        /// </summary>
        [Fact]
        public void Rope_ShouldHaveValueNine()
        {
            byte value = 9;
            Assert.Equal(value, (byte) JointType.Rope);
        }

        /// <summary>
        ///     Tests that motor should have value ten
        /// </summary>
        [Fact]
        public void Motor_ShouldHaveValueTen()
        {
            byte value = 10;
            Assert.Equal(value, (byte) JointType.Motor);
        }

        /// <summary>
        ///     Tests that angle should have value eleven
        /// </summary>
        [Fact]
        public void Angle_ShouldHaveValueEleven()
        {
            byte value = 11;
            Assert.Equal(value, (byte) JointType.Angle);
        }

        /// <summary>
        ///     Tests that fixedMouse should have value twelve
        /// </summary>
        [Fact]
        public void FixedMouse_ShouldHaveValueTwelve()
        {
            byte value = 12;
            Assert.Equal(value, (byte) JointType.FixedMouse);
        }

        /// <summary>
        ///     Tests that fixedRevolute should have value thirteen
        /// </summary>
        [Fact]
        public void FixedRevolute_ShouldHaveValueThirteen()
        {
            byte value = 13;
            Assert.Equal(value, (byte) JointType.FixedRevolute);
        }

        /// <summary>
        ///     Tests that fixedDistance should have value fourteen
        /// </summary>
        [Fact]
        public void FixedDistance_ShouldHaveValueFourteen()
        {
            byte value = 14;
            Assert.Equal(value, (byte) JointType.FixedDistance);
        }

        /// <summary>
        ///     Tests that fixedLine should have value fifteen
        /// </summary>
        [Fact]
        public void FixedLine_ShouldHaveValueFifteen()
        {
            byte value = 15;
            Assert.Equal(value, (byte) JointType.FixedLine);
        }

        /// <summary>
        ///     Tests that fixedPrismatic should have value sixteen
        /// </summary>
        [Fact]
        public void FixedPrismatic_ShouldHaveValueSixteen()
        {
            byte value = 16;
            Assert.Equal(value, (byte) JointType.FixedPrismatic);
        }

        /// <summary>
        ///     Tests that fixedAngle should have value seventeen
        /// </summary>
        [Fact]
        public void FixedAngle_ShouldHaveValueSeventeen()
        {
            byte value = 17;
            Assert.Equal(value, (byte) JointType.FixedAngle);
        }

        /// <summary>
        ///     Tests that fixedFriction should have value eighteen
        /// </summary>
        [Fact]
        public void FixedFriction_ShouldHaveValueEighteen()
        {
            byte value = 18;
            Assert.Equal(value, (byte) JointType.FixedFriction);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(JointType.Unknown, JointType.Revolute);
            Assert.NotEqual(JointType.Unknown, JointType.Prismatic);
            Assert.NotEqual(JointType.Revolute, JointType.Prismatic);
        }
    }
}
