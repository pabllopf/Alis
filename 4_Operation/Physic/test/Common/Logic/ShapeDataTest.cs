// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeDataTest.cs
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
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The shape data test class
    /// </summary>
    public class ShapeDataTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            ShapeData data = new ShapeData();
            
            Assert.Null(data.Body);
            Assert.Equal(0.0f, data.Max);
            Assert.Equal(0.0f, data.Min);
        }

        /// <summary>
        ///     Tests that body property should set and get correctly
        /// </summary>
        [Fact]
        public void BodyProperty_ShouldSetAndGetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            ShapeData data = new ShapeData
            {
                Body = body
            };
            
            Assert.Equal(body, data.Body);
        }

        /// <summary>
        ///     Tests that max property should set and get correctly
        /// </summary>
        [Fact]
        public void MaxProperty_ShouldSetAndGetCorrectly()
        {
            ShapeData data = new ShapeData
            {
                Max = 45.0f
            };
            
            Assert.Equal(45.0f, data.Max);
        }

        /// <summary>
        ///     Tests that min property should set and get correctly
        /// </summary>
        [Fact]
        public void MinProperty_ShouldSetAndGetCorrectly()
        {
            ShapeData data = new ShapeData
            {
                Min = -30.0f
            };
            
            Assert.Equal(-30.0f, data.Min);
        }

        /// <summary>
        ///     Tests that shape data should be value type
        /// </summary>
        [Fact]
        public void ShapeData_ShouldBeValueType()
        {
            ShapeData data1 = new ShapeData { Max = 10.0f };
            ShapeData data2 = data1;
            
            data2.Max = 20.0f;
            
            Assert.NotEqual(data1.Max, data2.Max);
        }

        /// <summary>
        ///     Tests that shape data should handle all properties together
        /// </summary>
        [Fact]
        public void ShapeData_ShouldHandleAllPropertiesTogether()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            ShapeData data = new ShapeData
            {
                Body = body,
                Max = 90.0f,
                Min = -90.0f
            };
            
            Assert.Equal(body, data.Body);
            Assert.Equal(90.0f, data.Max);
            Assert.Equal(-90.0f, data.Min);
        }

        /// <summary>
        ///     Tests that shape data should handle negative angles
        /// </summary>
        [Fact]
        public void ShapeData_ShouldHandleNegativeAngles()
        {
            ShapeData data = new ShapeData
            {
                Max = -10.0f,
                Min = -45.0f
            };
            
            Assert.Equal(-10.0f, data.Max);
            Assert.Equal(-45.0f, data.Min);
        }

        /// <summary>
        ///     Tests that shape data should handle zero angles
        /// </summary>
        [Fact]
        public void ShapeData_ShouldHandleZeroAngles()
        {
            ShapeData data = new ShapeData
            {
                Max = 0.0f,
                Min = 0.0f
            };
            
            Assert.Equal(0.0f, data.Max);
            Assert.Equal(0.0f, data.Min);
        }

        /// <summary>
        ///     Tests that shape data should handle large angles
        /// </summary>
        [Fact]
        public void ShapeData_ShouldHandleLargeAngles()
        {
            ShapeData data = new ShapeData
            {
                Max = 360.0f,
                Min = -360.0f
            };
            
            Assert.Equal(360.0f, data.Max);
            Assert.Equal(-360.0f, data.Min);
        }

        /// <summary>
        ///     Tests that shape data should allow null body
        /// </summary>
        [Fact]
        public void ShapeData_ShouldAllowNullBody()
        {
            ShapeData data = new ShapeData
            {
                Body = null,
                Max = 10.0f,
                Min = 5.0f
            };
            
            Assert.Null(data.Body);
        }

        /// <summary>
        ///     Tests that shape data should support min greater than max
        /// </summary>
        [Fact]
        public void ShapeData_ShouldSupportMinGreaterThanMax()
        {
            ShapeData data = new ShapeData
            {
                Max = 10.0f,
                Min = 20.0f
            };
            
            Assert.True(data.Min > data.Max);
        }
    }
}

