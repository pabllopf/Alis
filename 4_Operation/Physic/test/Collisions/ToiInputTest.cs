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
        ///     Tests that TMax should set and get correctly
        /// </summary>
        [Fact]
        public void TMax_ShouldSetAndGetCorrectly()
        {
            ToiInput input = new ToiInput
            {
                TMax = 0.5f
            };

            Assert.Equal(0.5f, input.TMax);
        }

        /// <summary>
        ///     Tests that TMax with zero should work
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
        ///     Tests that TMax with one should work
        /// </summary>
        [Fact]
        public void TMax_WithOne_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = 1.0f
            };

            Assert.Equal(1.0f, input.TMax);
        }

        /// <summary>
        ///     Tests that TMax with very small value should work
        /// </summary>
        [Fact]
        public void TMax_WithVerySmallValue_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = SettingEnv.Epsilon
            };

            Assert.Equal(SettingEnv.Epsilon, input.TMax);
        }

        /// <summary>
        ///     Tests that TMax with large value should work
        /// </summary>
        [Fact]
        public void TMax_WithLargeValue_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = 100.0f
            };

            Assert.Equal(100.0f, input.TMax);
        }
        

        /// <summary>
        ///     Tests that default ToiInput should have zero TMax
        /// </summary>
        [Fact]
        public void DefaultToiInput_ShouldHaveZeroTMax()
        {
            ToiInput input = new ToiInput();

            Assert.Equal(0.0f, input.TMax);
        }

        /// <summary>
        ///     Tests that ToiInput should allow setting properties independently
        /// </summary>
        [Fact]
        public void ToiInput_ShouldAllowSettingPropertiesIndependently()
        {
            ToiInput input = new ToiInput();

            input.ProxyA = new DistanceProxy();
            input.ProxyB = new DistanceProxy();
            input.SweepA = new Sweep();
            input.SweepB = new Sweep();
            input.TMax = 0.75f;

            Assert.NotNull(input.ProxyA);
            Assert.NotNull(input.ProxyB);
            Assert.NotNull(input.SweepA);
            Assert.NotNull(input.SweepB);
            Assert.Equal(0.75f, input.TMax);
        }

        /// <summary>
        ///     Tests that ToiInput with TMax at epsilon should work
        /// </summary>
        [Fact]
        public void ToiInput_WithTMaxAtEpsilon_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = SettingEnv.Epsilon
            };

            Assert.Equal(SettingEnv.Epsilon, input.TMax);
        }

        /// <summary>
        ///     Tests that ToiInput with TMax greater than one should work
        /// </summary>
        [Fact]
        public void ToiInput_WithTMaxGreaterThanOne_ShouldWork()
        {
            ToiInput input = new ToiInput
            {
                TMax = 2.5f
            };

            Assert.Equal(2.5f, input.TMax);
        }
    }
}
