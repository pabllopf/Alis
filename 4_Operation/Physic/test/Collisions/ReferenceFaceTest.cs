// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ReferenceFaceTest.cs
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
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The reference face test class
    /// </summary>
    public class ReferenceFaceTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            ReferenceFace face = new ReferenceFace();
            
            Assert.Equal(0, face.I1);
            Assert.Equal(0, face.I2);
            Assert.Equal(Vector2F.Zero, face.V1);
            Assert.Equal(Vector2F.Zero, face.V2);
            Assert.Equal(Vector2F.Zero, face.Normal);
            Assert.Equal(Vector2F.Zero, face.SideNormal1);
            Assert.Equal(Vector2F.Zero, face.SideNormal2);
            Assert.Equal(0.0f, face.SideOffset1);
            Assert.Equal(0.0f, face.SideOffset2);
        }

        /// <summary>
        ///     Tests that i1 should set and get correctly
        /// </summary>
        [Fact]
        public void I1_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                I1 = 5
            };
            
            Assert.Equal(5, face.I1);
        }

        /// <summary>
        ///     Tests that i2 should set and get correctly
        /// </summary>
        [Fact]
        public void I2_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                I2 = 10
            };
            
            Assert.Equal(10, face.I2);
        }

        /// <summary>
        ///     Tests that v1 should set and get correctly
        /// </summary>
        [Fact]
        public void V1_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                V1 = new Vector2F(1.0f, 2.0f)
            };
            
            Assert.Equal(new Vector2F(1.0f, 2.0f), face.V1);
        }

        /// <summary>
        ///     Tests that v2 should set and get correctly
        /// </summary>
        [Fact]
        public void V2_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                V2 = new Vector2F(3.0f, 4.0f)
            };
            
            Assert.Equal(new Vector2F(3.0f, 4.0f), face.V2);
        }

        /// <summary>
        ///     Tests that normal should set and get correctly
        /// </summary>
        [Fact]
        public void Normal_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                Normal = new Vector2F(0.0f, 1.0f)
            };
            
            Assert.Equal(new Vector2F(0.0f, 1.0f), face.Normal);
        }

        /// <summary>
        ///     Tests that side normal 1 should set and get correctly
        /// </summary>
        [Fact]
        public void SideNormal1_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                SideNormal1 = new Vector2F(1.0f, 0.0f)
            };
            
            Assert.Equal(new Vector2F(1.0f, 0.0f), face.SideNormal1);
        }

        /// <summary>
        ///     Tests that side normal 2 should set and get correctly
        /// </summary>
        [Fact]
        public void SideNormal2_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                SideNormal2 = new Vector2F(-1.0f, 0.0f)
            };
            
            Assert.Equal(new Vector2F(-1.0f, 0.0f), face.SideNormal2);
        }

        /// <summary>
        ///     Tests that side offset 1 should set and get correctly
        /// </summary>
        [Fact]
        public void SideOffset1_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                SideOffset1 = 2.5f
            };
            
            Assert.Equal(2.5f, face.SideOffset1);
        }

        /// <summary>
        ///     Tests that side offset 2 should set and get correctly
        /// </summary>
        [Fact]
        public void SideOffset2_ShouldSetAndGetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                SideOffset2 = 3.5f
            };
            
            Assert.Equal(3.5f, face.SideOffset2);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            ReferenceFace face = new ReferenceFace
            {
                I1 = 1,
                I2 = 2,
                V1 = new Vector2F(1.0f, 2.0f),
                V2 = new Vector2F(3.0f, 4.0f),
                Normal = new Vector2F(0.0f, 1.0f),
                SideNormal1 = new Vector2F(1.0f, 0.0f),
                SideNormal2 = new Vector2F(-1.0f, 0.0f),
                SideOffset1 = 2.5f,
                SideOffset2 = 3.5f
            };
            
            Assert.Equal(1, face.I1);
            Assert.Equal(2, face.I2);
            Assert.Equal(new Vector2F(1.0f, 2.0f), face.V1);
            Assert.Equal(new Vector2F(3.0f, 4.0f), face.V2);
            Assert.Equal(new Vector2F(0.0f, 1.0f), face.Normal);
            Assert.Equal(new Vector2F(1.0f, 0.0f), face.SideNormal1);
            Assert.Equal(new Vector2F(-1.0f, 0.0f), face.SideNormal2);
            Assert.Equal(2.5f, face.SideOffset1);
            Assert.Equal(3.5f, face.SideOffset2);
        }
    }
}

