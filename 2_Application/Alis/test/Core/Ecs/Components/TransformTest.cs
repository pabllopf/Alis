// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TransformTest.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components;
using Xunit;

namespace Alis.Test.Core.Ecs.Components
{
    /// <summary>
    ///     Tests for the Transform component struct
    /// </summary>
    public class TransformTest
    {
        /// <summary>
        ///     Tests that the Position property is gettable and settable
        /// </summary>
        [Fact]
        public void Transform_PositionProperty_ShouldBeGetAndSettable()
        {
            Transform transform = new Transform();
            Vector2F newPosition = new Vector2F(10f, 20f);

            transform.Position = newPosition;
            Assert.Equal(newPosition, transform.Position);
        }

        /// <summary>
        ///     Tests that the Rotation property is gettable and settable
        /// </summary>
        [Fact]
        public void Transform_RotationProperty_ShouldBeGetAndSettable()
        {
            Transform transform = new Transform();

            transform.Rotation = 45f;
            Assert.Equal(45f, transform.Rotation);

            transform.Rotation = -90f;
            Assert.Equal(-90f, transform.Rotation);
        }

        /// <summary>
        ///     Tests that the Scale property is gettable and settable
        /// </summary>
        [Fact]
        public void Transform_ScaleProperty_ShouldBeGetAndSettable()
        {
            Transform transform = new Transform();
            Vector2F newScale = new Vector2F(2f, 3f);

            transform.Scale = newScale;
            Assert.Equal(newScale, transform.Scale);
        }

        /// <summary>
        ///     Tests that the OnStart method exists and is callable
        /// </summary>
        [Fact]
        public void Transform_OnStartMethod_ShouldExistAndBeCallable()
        {
            Transform transform = new Transform();

            transform.OnStart(null!);
        }

        /// <summary>
        ///     Tests that the OnExit method exists and is callable
        /// </summary>
        [Fact]
        public void Transform_OnExitMethod_ShouldExistAndBeCallable()
        {
            Transform transform = new Transform(new Vector2F(5f, 5f), 30f, new Vector2F(2f, 2f));

            transform.Position = new Vector2F(100f, 200f);
            transform.Rotation = 90f;
            transform.Scale = new Vector2F(5f, 5f);

            transform.OnExit(null!);
        }

        /// <summary>
        ///     Tests that Transform implements IOnStart and IOnExit interfaces
        /// </summary>
        [Fact]
        public void Transform_ShouldImplementExpectedInterfaces()
        {
            Transform transform = new Transform();

            Assert.IsAssignableFrom<IOnStart>(transform);
            Assert.IsAssignableFrom<IOnExit>(transform);
        }

        /// <summary>
        ///     Tests that Position can be set to negative values
        /// </summary>
        [Fact]
        public void Transform_Position_ShouldAcceptNegativeValues()
        {
            Transform transform = new Transform();

            transform.Position = new Vector2F(-10f, -20f);
            Assert.Equal(-10f, transform.Position.X);
            Assert.Equal(-20f, transform.Position.Y);
        }

        /// <summary>
        ///     Tests that Scale can be set to zero
        /// </summary>
        [Fact]
        public void Transform_Scale_ShouldAcceptZeroValues()
        {
            Transform transform = new Transform();

            transform.Scale = Vector2F.Zero;
            Assert.Equal(0f, transform.Scale.X);
            Assert.Equal(0f, transform.Scale.Y);
        }

        /// <summary>
        ///     Tests that Rotation can be set to any float value
        /// </summary>
        
        [InlineData(0f)]
        [InlineData(360f)]
        [InlineData(-360f)]
        [InlineData(float.MaxValue)]
        [InlineData(float.MinValue)]
        public void Transform_Rotation_ShouldAcceptAnyFloatValue(float rotation)
        {
            Transform transform = new Transform();

            transform.Rotation = rotation;
            Assert.Equal(rotation, transform.Rotation);
        }
    }
}
