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
            Assert.Equal(0, (int)JointType.Unknown);
        }

        /// <summary>
        ///     Tests that revolute should have value one
        /// </summary>
        [Fact]
        public void Revolute_ShouldHaveValueOne()
        {
            Assert.Equal(1, (int)JointType.Revolute);
        }

        /// <summary>
        ///     Tests that prismatic should have value two
        /// </summary>
        [Fact]
        public void Prismatic_ShouldHaveValueTwo()
        {
            Assert.Equal(2, (int)JointType.Prismatic);
        }

        /// <summary>
        ///     Tests that distance should have value three
        /// </summary>
        [Fact]
        public void Distance_ShouldHaveValueThree()
        {
            Assert.Equal(3, (int)JointType.Distance);
        }

        /// <summary>
        ///     Tests that pulley should have value four
        /// </summary>
        [Fact]
        public void Pulley_ShouldHaveValueFour()
        {
            Assert.Equal(4, (int)JointType.Pulley);
        }

        /// <summary>
        ///     Tests that gear should have value five
        /// </summary>
        [Fact]
        public void Gear_ShouldHaveValueFive()
        {
            Assert.Equal(5, (int)JointType.Gear);
        }

        /// <summary>
        ///     Tests that wheel should have value six
        /// </summary>
        [Fact]
        public void Wheel_ShouldHaveValueSix()
        {
            Assert.Equal(6, (int)JointType.Wheel);
        }

        /// <summary>
        ///     Tests that weld should have value seven
        /// </summary>
        [Fact]
        public void Weld_ShouldHaveValueSeven()
        {
            Assert.Equal(7, (int)JointType.Weld);
        }

        /// <summary>
        ///     Tests that friction should have value eight
        /// </summary>
        [Fact]
        public void Friction_ShouldHaveValueEight()
        {
            Assert.Equal(8, (int)JointType.Friction);
        }

        /// <summary>
        ///     Tests that rope should have value nine
        /// </summary>
        [Fact]
        public void Rope_ShouldHaveValueNine()
        {
            Assert.Equal(9, (int)JointType.Rope);
        }

        /// <summary>
        ///     Tests that motor should have value ten
        /// </summary>
        [Fact]
        public void Motor_ShouldHaveValueTen()
        {
            Assert.Equal(10, (int)JointType.Motor);
        }

        /// <summary>
        ///     Tests that angle should have value eleven
        /// </summary>
        [Fact]
        public void Angle_ShouldHaveValueEleven()
        {
            Assert.Equal(11, (int)JointType.Angle);
        }

        /// <summary>
        ///     Tests that fixed mouse should have value twelve
        /// </summary>
        [Fact]
        public void FixedMouse_ShouldHaveValueTwelve()
        {
            Assert.Equal(12, (int)JointType.FixedMouse);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            JointType[] values = new[]
            {
                JointType.Unknown,
                JointType.Revolute,
                JointType.Prismatic,
                JointType.Distance,
                JointType.Pulley,
                JointType.Gear,
                JointType.Wheel,
                JointType.Weld,
                JointType.Friction,
                JointType.Rope,
                JointType.Motor,
                JointType.Angle,
                JointType.FixedMouse
            };
            
            for (int i = 0; i < values.Length; i++)
            {
                for (int j = i + 1; j < values.Length; j++)
                {
                    Assert.NotEqual(values[i], values[j]);
                }
            }
        }
    }
}

