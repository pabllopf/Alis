// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectFlagsTest.cs
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

using System;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object flags test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="GameObjectFlags"/> enumeration which provides flag-based
    ///     states for game objects in the ECS system.
    /// </remarks>
    public class GameObjectFlagsTest
    {
        /// <summary>
        ///     Tests that none flag has zero value
        /// </summary>
        /// <remarks>
        ///     Verifies that the None flag has a value of zero, which is the default state.
        /// </remarks>
        [Fact]
        public void None_Flag_HasZeroValue()
        {
            // Assert
            Assert.Equal(0, (int)GameObjectFlags.None);
        }

        /// <summary>
        ///     Tests that tagged flag has correct bit position
        /// </summary>
        /// <remarks>
        ///     Validates that the Tagged flag is set to the first bit position.
        /// </remarks>
        [Fact]
        public void Tagged_Flag_HasCorrectBitPosition()
        {
            // Assert
            Assert.Equal(1, (int)GameObjectFlags.Tagged);
        }

        /// <summary>
        ///     Tests that detach flag has correct bit position
        /// </summary>
        /// <remarks>
        ///     Validates that the Detach flag is set to the second bit position.
        /// </remarks>
        [Fact]
        public void Detach_Flag_HasCorrectBitPosition()
        {
            // Assert
            Assert.Equal(2, (int)GameObjectFlags.Detach);
        }

        /// <summary>
        ///     Tests that add comp flag has correct bit position
        /// </summary>
        /// <remarks>
        ///     Validates that the AddComp flag is set to the third bit position.
        /// </remarks>
        [Fact]
        public void AddComp_Flag_HasCorrectBitPosition()
        {
            // Assert
            Assert.Equal(4, (int)GameObjectFlags.AddComp);
        }

        /// <summary>
        ///     Tests that flags can be combined
        /// </summary>
        /// <remarks>
        ///     Tests that multiple flags can be combined using bitwise OR operations.
        /// </remarks>
        [Fact]
        public void Flags_CanBeCombined()
        {
            // Arrange & Act
            GameObjectFlags combined = GameObjectFlags.Tagged | GameObjectFlags.Detach;

            // Assert
            Assert.Equal(3, (int)combined);
            Assert.True(combined.HasFlag(GameObjectFlags.Tagged));
            Assert.True(combined.HasFlag(GameObjectFlags.Detach));
        }

        /// <summary>
        ///     Tests that events flag combines multiple flags
        /// </summary>
        /// <remarks>
        ///     Validates that the Events flag is a combination of multiple other flags.
        /// </remarks>
        [Fact]
        public void Events_Flag_CombinesMultipleFlags()
        {
            // Arrange
            GameObjectFlags events = GameObjectFlags.Events;

            // Assert
            Assert.True(events.HasFlag(GameObjectFlags.Tagged));
            Assert.True(events.HasFlag(GameObjectFlags.Detach));
            Assert.True(events.HasFlag(GameObjectFlags.AddComp));
            Assert.True(events.HasFlag(GameObjectFlags.RemoveComp));
            Assert.True(events.HasFlag(GameObjectFlags.OnDelete));
            Assert.True(events.HasFlag(GameObjectFlags.WorldCreate));
        }

        /// <summary>
        ///     Tests that flags can be checked with has flag
        /// </summary>
        /// <remarks>
        ///     Tests that individual flags can be checked using the HasFlag method.
        /// </remarks>
        [Fact]
        public void Flags_CanBeCheckedWithHasFlag()
        {
            // Arrange
            GameObjectFlags flags = GameObjectFlags.AddComp | GameObjectFlags.RemoveComp;

            // Assert
            Assert.True(flags.HasFlag(GameObjectFlags.AddComp));
            Assert.True(flags.HasFlag(GameObjectFlags.RemoveComp));
            Assert.False(flags.HasFlag(GameObjectFlags.Tagged));
        }

        /// <summary>
        ///     Tests that flags can be removed with bitwise and not
        /// </summary>
        /// <remarks>
        ///     Tests that flags can be removed using bitwise AND with NOT operations.
        /// </remarks>
        [Fact]
        public void Flags_CanBeRemovedWithBitwiseAndNot()
        {
            // Arrange
            GameObjectFlags flags = GameObjectFlags.Tagged | GameObjectFlags.Detach | GameObjectFlags.AddComp;

            // Act
            flags &= ~GameObjectFlags.Detach;

            // Assert
            Assert.True(flags.HasFlag(GameObjectFlags.Tagged));
            Assert.False(flags.HasFlag(GameObjectFlags.Detach));
            Assert.True(flags.HasFlag(GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that world create flag has correct value
        /// </summary>
        /// <remarks>
        ///     Validates the WorldCreate flag has the expected bit value.
        /// </remarks>
        [Fact]
        public void WorldCreate_Flag_HasCorrectValue()
        {
            // Assert
            Assert.Equal(128, (int)GameObjectFlags.WorldCreate);
        }

        /// <summary>
        ///     Tests that has world command buffer remove flag has correct value
        /// </summary>
        /// <remarks>
        ///     Validates the HasWorldCommandBufferRemove flag has the expected bit value.
        /// </remarks>
        [Fact]
        public void HasWorldCommandBufferRemove_Flag_HasCorrectValue()
        {
            // Assert
            Assert.Equal(256, (int)GameObjectFlags.HasWorldCommandBufferRemove);
        }

        /// <summary>
        ///     Tests that has world command buffer add flag has correct value
        /// </summary>
        /// <remarks>
        ///     Validates the HasWorldCommandBufferAdd flag has the expected bit value.
        /// </remarks>
        [Fact]
        public void HasWorldCommandBufferAdd_Flag_HasCorrectValue()
        {
            // Assert
            Assert.Equal(512, (int)GameObjectFlags.HasWorldCommandBufferAdd);
        }

        /// <summary>
        ///     Tests that flags is flags attribute applied
        /// </summary>
        /// <remarks>
        ///     Verifies that the GameObjectFlags enum has the Flags attribute applied.
        /// </remarks>
        [Fact]
        public void GameObjectFlags_HasFlagsAttribute()
        {
            // Arrange
            Type flagsType = typeof(GameObjectFlags);

            // Act
            bool hasFlagsAttribute = Attribute.IsDefined(flagsType, typeof(FlagsAttribute));

            // Assert
            Assert.True(hasFlagsAttribute);
        }

        /// <summary>
        ///     Tests that none flag equals default value
        /// </summary>
        /// <remarks>
        ///     Confirms that the None flag is equal to the default enum value.
        /// </remarks>
        [Fact]
        public void None_Flag_EqualsDefaultValue()
        {
            // Arrange
            GameObjectFlags defaultValue = default;

            // Assert
            Assert.Equal(GameObjectFlags.None, defaultValue);
        }
    }
}

