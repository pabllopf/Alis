// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Entity.Transform;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Entity.Transform
{
    /// <summary>
    /// The transform builder test class
    /// </summary>
    public class TransformBuilderTest
    {
        /// <summary>
        /// Tests that transform builder default constructor valid input
        /// </summary>
        [Fact]
        public void TransformBuilder_DefaultConstructor_ValidInput()
        {
            var transformBuilder = new TransformBuilder();
            
            Assert.NotNull(transformBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            var transformBuilder = new TransformBuilder();
            
            var transform = transformBuilder.Build();
        }
        
        /// <summary>
        /// Tests that position valid input
        /// </summary>
        [Fact]
        public void Position_ValidInput()
        {
            var transformBuilder = new TransformBuilder();
            
            transformBuilder.Position(1.0f, 2.0f);
            
            Assert.Equal(new Vector2(1.0f, 2.0f), transformBuilder.Build().Position);
        }
        
        /// <summary>
        /// Tests that rotation valid input
        /// </summary>
        [Fact]
        public void Rotation_ValidInput()
        {
            var transformBuilder = new TransformBuilder();
            
            transformBuilder.Rotation(45.0f);
            
            Assert.Equal(new Rotation(45.0f), transformBuilder.Build().Rotation);
        }
        
        /// <summary>
        /// Tests that scale valid input
        /// </summary>
        [Fact]
        public void Scale_ValidInput()
        {
            var transformBuilder = new TransformBuilder();
            
            transformBuilder.Scale(3.0f, 4.0f);
            
            Assert.Equal(new Vector2(3.0f, 4.0f), transformBuilder.Build().Scale);
        }
    }
}