// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ToiInputTest.cs
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
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The toi input test class
    /// </summary>
    public class ToiInputTest
    {
        /// <summary>
        ///     Tests that constructor should create instance
        /// </summary>
        [Fact]
        public void Constructor_ShouldCreateInstance()
        {
            ToiInput input = new ToiInput();
            
            Assert.NotNull(input);
        }

        /// <summary>
        ///     Tests that proxy a should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyA_ShouldSetAndGetCorrectly()
        {
            ToiInput input = new ToiInput();
            DistanceProxy proxy = new DistanceProxy();
            
            input.ProxyA = proxy;
            
            Assert.Equal(proxy, input.ProxyA);
        }

        /// <summary>
        ///     Tests that proxy b should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyB_ShouldSetAndGetCorrectly()
        {
            ToiInput input = new ToiInput();
            DistanceProxy proxy = new DistanceProxy();
            
            input.ProxyB = proxy;
            
            Assert.Equal(proxy, input.ProxyB);
        }

        /// <summary>
        ///     Tests that sweep a should set and get correctly
        /// </summary>
        [Fact]
        public void SweepA_ShouldSetAndGetCorrectly()
        {
            ToiInput input = new ToiInput();
            Sweep sweep = new Sweep();
            
            input.SweepA = sweep;
            
            Assert.Equal(sweep, input.SweepA);
        }

        /// <summary>
        ///     Tests that sweep b should set and get correctly
        /// </summary>
        [Fact]
        public void SweepB_ShouldSetAndGetCorrectly()
        {
            ToiInput input = new ToiInput();
            Sweep sweep = new Sweep();
            
            input.SweepB = sweep;
            
            Assert.Equal(sweep, input.SweepB);
        }

        /// <summary>
        ///     Tests that t max should set and get correctly
        /// </summary>
        [Fact]
        public void TMax_ShouldSetAndGetCorrectly()
        {
            ToiInput input = new ToiInput
            {
                TMax = 1.5f
            };
            
            Assert.Equal(1.5f, input.TMax);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(),
                ProxyB = new DistanceProxy(),
                SweepA = new Sweep(),
                SweepB = new Sweep(),
                TMax = 2.0f
            };
            
            Assert.NotNull(input.ProxyA);
            Assert.NotNull(input.ProxyB);
            Assert.Equal(2.0f, input.TMax);
        }

        /// <summary>
        ///     Tests that t max with zero should work
        /// </summary>
        [Fact]
        public void TMax_WithZero_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = 0.0f
            };
            
            Assert.Equal(0.0f, input.TMax);
        }

        /// <summary>
        ///     Tests that t max with negative value should work
        /// </summary>
        [Fact]
        public void TMax_WithNegativeValue_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = -1.0f
            };
            
            Assert.Equal(-1.0f, input.TMax);
        }
    }
}

