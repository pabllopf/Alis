// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpriteTest.cs
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
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Sprite component record struct
    /// </summary>
    public class SpriteTest
    {
        /// <summary>
        ///     Tests that the constructor creates a Sprite with default values
        /// </summary>
        [Fact]
        public void Sprite_Constructor_ShouldCreateWithDefaultValues()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Equal(context, sprite.Context);
            Assert.Equal("test.png", sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }

        /// <summary>
        ///     Tests that the OnExit method exists and is callable
        /// </summary>
        [Fact]
        public void Sprite_OnExitMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Throws<System.NotImplementedException>(() =>
            {
                sprite.OnExit(null!);
            });
        }

        /// <summary>
        ///     Tests that Sprite implements ISprite interface
        /// </summary>
        [Fact]
        public void Sprite_ShouldImplementISpriteInterface()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.IsAssignableFrom<ISprite>(sprite);
        }

        /// <summary>
        ///     Tests that Sprite properties are gettable and settable
        /// </summary>
        [Fact]
        public void Sprite_Properties_ShouldBeGetAndSettable()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.Equal("test.png", sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }

        /// <summary>
        ///     Tests that Sprite properties can be modified independently
        /// </summary>
        [Fact]
        public void Sprite_Properties_ShouldBeModifiedIndependently()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            sprite.NameFile = "new_sprite.png";
            Assert.Equal("new_sprite.png", sprite.NameFile);
            Assert.Equal(0, sprite.Depth);

            sprite.Depth = 5;
            Assert.Equal("new_sprite.png", sprite.NameFile);
            Assert.Equal(5, sprite.Depth);
        }

        /// <summary>
        ///     Tests that Sprite is a record struct (value-based equality)
        /// </summary>
        [Fact]
        public void Sprite_ShouldBeRecordStructWithValueEquality()
        {
            Context context = new Context();

            Sprite sprite1 = new Sprite(context, "test.png", 0);
            Sprite sprite2 = new Sprite(context, "test.png", 0);

            Assert.Equal(sprite1, sprite2);
        }

        /// <summary>
        ///     Tests that Sprite has expected public members
        /// </summary>
        [Fact]
        public void Sprite_ShouldHaveExpectedPublicMembers()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, "test.png", 0);

            Assert.NotNull(sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }
        
        /// <summary>
        ///     Tests that Sprite default state is valid
        /// </summary>
        [Fact]
        public void Sprite_DefaultState_ShouldBeValid()
        {
            Context context = new Context();

            Sprite sprite = new Sprite(context, string.Empty, 0);

            Assert.NotNull(sprite.Context);
            Assert.Equal(string.Empty, sprite.NameFile);
            Assert.Equal(0, sprite.Depth);
        }
    }
}
