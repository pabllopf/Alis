// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLocationRemainingCoverageTests.cs
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
    ///     Tests the remaining uncovered methods of <see cref="GameObjectLocation" /> struct.
    /// </summary>
    public class GameObjectLocationRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that the two-parameter constructor sets <see cref="GameObjectLocation.Index" /> correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeAndIndex_SetsProperties()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 5);

            Assert.Equal(5, loc.Index);
        }

        /// <summary>
        ///     Tests that the three-parameter constructor sets <see cref="GameObjectLocation.Flags" /> correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeIndexAndFlags_SetsFlags()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.None);

            Assert.Equal(GameObjectFlags.None, loc.Flags);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.Default" /> returns a location with <see cref="int.MaxValue" /> index.
        /// </summary>
        [Fact]
        public void Default_ReturnsLocationWithMaxIndex()
        {
            Assert.Equal(int.MaxValue, GameObjectLocation.Default.Index);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEvent" /> returns <see langword="true" /> when flags match.
        /// </summary>
        [Fact]
        public void HasEvent_WithMatchingFlag_ReturnsTrue()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.AddComp);

            Assert.True(loc.HasEvent(GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEvent" /> returns <see langword="false" /> when flags do not match.
        /// </summary>
        [Fact]
        public void HasEvent_WithNonMatchingFlag_ReturnsFalse()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.None);

            Assert.False(loc.HasEvent(GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that the static <see cref="GameObjectLocation.HasEventFlag" /> returns <see langword="true" /> for matching flags.
        /// </summary>
        [Fact]
        public void HasEventFlag_Static_WithMatchingFlag_ReturnsTrue()
        {
            Assert.True(GameObjectLocation.HasEventFlag(GameObjectFlags.AddComp, GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests that the static <see cref="GameObjectLocation.HasEventFlag" /> returns <see langword="false" /> for non-matching flags.
        /// </summary>
        [Fact]
        public void HasEventFlag_Static_WithNonMatchingFlag_ReturnsFalse()
        {
            Assert.False(GameObjectLocation.HasEventFlag(GameObjectFlags.None, GameObjectFlags.AddComp));
        }

        /// <summary>
        ///     Tests the three-parameter constructor with non-default flags.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeIndexAndNonDefaultFlags_SetsAllFields()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 42, GameObjectFlags.AddComp);

            Assert.Equal(42, loc.Index);
            Assert.Equal(GameObjectFlags.AddComp, loc.Flags);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEvent" /> with combined instance flags matches correctly.
        /// </summary>
        [Fact]
        public void HasEvent_WithCombinedFlags_ReturnsTrueForAnyMatch()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.AddComp | GameObjectFlags.RemoveComp);

            Assert.True(loc.HasEvent(GameObjectFlags.AddComp));
            Assert.True(loc.HasEvent(GameObjectFlags.RemoveComp));
            Assert.True(loc.HasEvent(GameObjectFlags.AddComp | GameObjectFlags.RemoveComp));
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEvent" /> with zero flags returns false.
        /// </summary>
        [Fact]
        public void HasEvent_WithZeroFlags_ReturnsFalse()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0, GameObjectFlags.AddComp);

            Assert.False(loc.HasEvent(GameObjectFlags.None));
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.HasEventFlag" /> with no target flags returns false.
        /// </summary>
        [Fact]
        public void HasEventFlag_Static_WithNoTargetFlags_ReturnsFalse()
        {
            Assert.False(GameObjectLocation.HasEventFlag(GameObjectFlags.AddComp, GameObjectFlags.None));
            Assert.False(GameObjectLocation.HasEventFlag(GameObjectFlags.None, GameObjectFlags.None));
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.Version" /> can be set and retrieved.
        /// </summary>
        [Fact]
        public void Version_SetAndGet_ReturnsCorrectValue()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0);
            loc.Version = 99;

            Assert.Equal((ushort)99, loc.Version);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.Default" /> has the expected default values.
        /// </summary>
        [Fact]
        public void Default_ReturnsExpectedLocation()
        {
            Assert.Equal(int.MaxValue, GameObjectLocation.Default.Index);
            Assert.Equal(GameObjectFlags.None, GameObjectLocation.Default.Flags);
        }

        /// <summary>
        ///     Tests that a default-constructed <see cref="GameObjectLocation" /> has zero-initialized fields.
        /// </summary>
        [Fact]
        public void DefaultStructValue_HasZeroInitializedFields()
        {
            GameObjectLocation loc = default;

            Assert.Equal(0, loc.Index);
            Assert.Equal(GameObjectFlags.None, loc.Flags);
            Assert.Equal((ushort)0, loc.Version);
        }

        /// <summary>
        ///     Tests that <see cref="GameObjectLocation.ArchetypeId" /> throws when archetype is null.
        /// </summary>
        [Fact]
        public void ArchetypeId_WithNullArchetype_ThrowsNullReferenceException()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 0);

            _ = Assert.Throws<NullReferenceException>(() => loc.ArchetypeId);
        }

        /// <summary>
        ///     Tests that the two-parameter constructor sets <see cref="GameObjectLocation.Archetype" /> correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeAndIndex_SetsArchetype()
        {
            GameObjectLocation loc = new GameObjectLocation(null!, 5);

            Assert.Null(loc.Archetype);
        }
    }
}
