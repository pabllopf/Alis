// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ToiOutputTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The toi output test class
    /// </summary>
    public class ToiOutputTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            ToiOutput output = new ToiOutput();

            Assert.Equal(ToiOutputState.Unknown, output.State);
            Assert.Equal(0.0f, output.T);
        }

      

        /// <summary>
        ///     Tests that T should set and get correctly
        /// </summary>
        [Fact]
        public void T_ShouldSetAndGetCorrectly()
        {
            ToiOutput output = new ToiOutput
            {
                T = 0.5f
            };

            Assert.Equal(0.5f, output.T);
        }

        /// <summary>
        ///     Tests that State with Unknown should work
        /// </summary>
        [Fact]
        public void State_WithUnknown_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Unknown
            };

            Assert.Equal(ToiOutputState.Unknown, output.State);
        }

        /// <summary>
        ///     Tests that State with Failed should work
        /// </summary>
        [Fact]
        public void State_WithFailed_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Failed
            };

            Assert.Equal(ToiOutputState.Failed, output.State);
        }

        /// <summary>
        ///     Tests that State with Overlapped should work
        /// </summary>
        [Fact]
        public void State_WithOverlapped_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Overlapped
            };

            Assert.Equal(ToiOutputState.Overlapped, output.State);
        }

        /// <summary>
        ///     Tests that State with Touching should work
        /// </summary>
        [Fact]
        public void State_WithTouching_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Touching
            };

            Assert.Equal(ToiOutputState.Touching, output.State);
        }

        /// <summary>
        ///     Tests that State with Seperated should work
        /// </summary>
        [Fact]
        public void State_WithSeperated_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Seperated
            };

            Assert.Equal(ToiOutputState.Seperated, output.State);
        }

        /// <summary>
        ///     Tests that T with zero should work
        /// </summary>
        [Fact]
        public void T_WithZero_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                T = 0.0f
            };

            Assert.Equal(0.0f, output.T);
        }

        /// <summary>
        ///     Tests that T with very small value should work
        /// </summary>
        [Fact]
        public void T_WithVerySmallValue_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                T = SettingEnv.Epsilon
            };

            Assert.Equal(SettingEnv.Epsilon, output.T);
        }

        /// <summary>
        ///     Tests that T with value close to one should work
        /// </summary>
        [Fact]
        public void T_WithValueCloseToOne_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                T = 0.999f
            };

            Assert.Equal(0.999f, output.T);
        }

        /// <summary>
        ///     Tests that default ToiOutput should have Unknown state
        /// </summary>
        [Fact]
        public void DefaultToiOutput_ShouldHaveUnknownState()
        {
            ToiOutput output = new ToiOutput();

            Assert.Equal(ToiOutputState.Unknown, output.State);
        }

        /// <summary>
        ///     Tests that default ToiOutput should have zero T
        /// </summary>
        [Fact]
        public void DefaultToiOutput_ShouldHaveZeroT()
        {
            ToiOutput output = new ToiOutput();

            Assert.Equal(0.0f, output.T);
        }

      
        /// <summary>
        ///     Tests that ToiOutput with Failed state should have valid T
        /// </summary>
        [Fact]
        public void ToiOutput_WithFailedState_ShouldHaveValidT()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Failed,
                T = 0.0f
            };

            Assert.Equal(ToiOutputState.Failed, output.State);
            Assert.Equal(0.0f, output.T);
        }

        /// <summary>
        ///     Tests that ToiOutput with Overlapped state should have valid T
        /// </summary>
        [Fact]
        public void ToiOutput_WithOverlappedState_ShouldHaveValidT()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Overlapped,
                T = 0.0f
            };

            Assert.Equal(ToiOutputState.Overlapped, output.State);
            Assert.Equal(0.0f, output.T);
        }

        /// <summary>
        ///     Tests that ToiOutput with Touching state should have valid T
        /// </summary>
        [Fact]
        public void ToiOutput_WithTouchingState_ShouldHaveValidT()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Touching,
                T = 0.5f
            };

            Assert.Equal(ToiOutputState.Touching, output.State);
            Assert.Equal(0.5f, output.T);
        }

        /// <summary>
        ///     Tests that ToiOutput with Seperated state should have valid T
        /// </summary>
        [Fact]
        public void ToiOutput_WithSeperatedState_ShouldHaveValidT()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Seperated,
                T = 1.0f
            };

            Assert.Equal(ToiOutputState.Seperated, output.State);
            Assert.Equal(1.0f, output.T);
        }
    }
}
