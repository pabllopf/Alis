// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceInputTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The distance input test class
    /// </summary>
    public class DistanceInputTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            DistanceInput input = new DistanceInput();
            
            Assert.False(input.UseRadii);
        }

        /// <summary>
        ///     Tests that use radii should set and get correctly
        /// </summary>
        [Fact]
        public void UseRadii_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput
            {
                UseRadii = true
            };
            
            Assert.True(input.UseRadii);
        }

        /// <summary>
        ///     Tests that proxy a should set and get correctly
        /// </summary>
        [Fact]
        public void ProxyA_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
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
            DistanceInput input = new DistanceInput();
            DistanceProxy proxy = new DistanceProxy();
            
            input.ProxyB = proxy;
            
            Assert.Equal(proxy, input.ProxyB);
        }

        /// <summary>
        ///     Tests that transform a should set and get correctly
        /// </summary>
        [Fact]
        public void TransformA_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
            ControllerTransform transform = ControllerTransform.Identity;
            
            input.ControllerTransformA = transform;
            
            Assert.Equal(transform, input.ControllerTransformA);
        }

        /// <summary>
        ///     Tests that transform b should set and get correctly
        /// </summary>
        [Fact]
        public void TransformB_ShouldSetAndGetCorrectly()
        {
            DistanceInput input = new DistanceInput();
            ControllerTransform transform = ControllerTransform.Identity;
            
            input.ControllerTransformB = transform;
            
            Assert.Equal(transform, input.ControllerTransformB);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            DistanceInput input = new DistanceInput
            {
                ProxyA = new DistanceProxy(),
                ProxyB = new DistanceProxy(),
                ControllerTransformA = ControllerTransform.Identity,
                ControllerTransformB = ControllerTransform.Identity,
                UseRadii = true
            };
            
            Assert.True(input.UseRadii);
        }
    }
}

