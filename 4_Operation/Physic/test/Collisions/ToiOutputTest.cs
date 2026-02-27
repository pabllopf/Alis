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
        ///     Tests that state should set and get correctly
        /// </summary>
        [Fact]
        public void State_ShouldSetAndGetCorrectly()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Touching
            };
            
            Assert.Equal(ToiOutputState.Touching, output.State);
        }

        /// <summary>
        ///     Tests that t should set and get correctly
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
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            ToiOutput output = new ToiOutput
            {
                State = ToiOutputState.Overlapped,
                T = 0.75f
            };
            
            Assert.Equal(ToiOutputState.Overlapped, output.State);
            Assert.Equal(0.75f, output.T);
        }

        /// <summary>
        ///     Tests that t with zero should work
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
        ///     Tests that t with one should work
        /// </summary>
        [Fact]
        public void T_WithOne_ShouldWork()
        {
            ToiOutput output = new ToiOutput
            {
                T = 1.0f
            };
            
            Assert.Equal(1.0f, output.T);
        }

        /// <summary>
        ///     Tests that state with failed should work
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
        ///     Tests that state with seperated should work
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
    }
}

