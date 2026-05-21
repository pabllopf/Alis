

using System;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object flags test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="GameObjectFlags" /> enumeration which provides flag-based
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
            Assert.Equal(0, (int) GameObjectFlags.None);
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
            Assert.Equal(4, (int) GameObjectFlags.AddComp);
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
            GameObjectFlags events = GameObjectFlags.Events;

            // Assert

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
            GameObjectFlags flags = GameObjectFlags.AddComp | GameObjectFlags.RemoveComp;

            Assert.True(flags.HasFlag(GameObjectFlags.AddComp));
            Assert.True(flags.HasFlag(GameObjectFlags.RemoveComp));
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
            Assert.Equal(128, (int) GameObjectFlags.WorldCreate);
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
            Assert.Equal(256, (int) GameObjectFlags.HasWorldCommandBufferRemove);
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
            Assert.Equal(512, (int) GameObjectFlags.HasWorldCommandBufferAdd);
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
            Type flagsType = typeof(GameObjectFlags);

            bool hasFlagsAttribute = Attribute.IsDefined(flagsType, typeof(FlagsAttribute));

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
            GameObjectFlags defaultValue = default(GameObjectFlags);

            Assert.Equal(GameObjectFlags.None, defaultValue);
        }
    }
}