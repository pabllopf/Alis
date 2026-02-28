// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLocationTest.cs
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

using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="GameObjectLocation"/> struct.
    /// </summary>
    public class GameObjectLocationTest
    {
        /// <summary>
        ///     Tests that constructor with archetype and index initializes correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypeAndIndex_ShouldInitializeCorrectly()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            
            // Act
            GameObjectLocation location = new GameObjectLocation(archetype, 5);
            
            // Assert
            Assert.Equal(archetype, location.Archetype);
            Assert.Equal(5, location.Index);
            Assert.Equal(GameObjectFlags.None, location.Flags);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that constructor with flags initializes all fields correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithFlags_ShouldInitializeAllFields()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectFlags flags = GameObjectFlags.AddComp;
            
            // Act
            GameObjectLocation location = new GameObjectLocation(archetype, 10, flags);
            
            // Assert
            Assert.Equal(archetype, location.Archetype);
            Assert.Equal(10, location.Index);
            Assert.Equal(flags, location.Flags);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that archetype id returns correct archetype id.
        /// </summary>
        [Fact]
        public void ArchetypeId_ShouldReturnCorrectId()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectLocation location = new GameObjectLocation(archetype, 0);
            
            // Act
            var archetypeId = location.ArchetypeId;
            
            // Assert
            Assert.Equal(archetype.Id, archetypeId);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that default property returns valid default location.
        /// </summary>
        [Fact]
        public void Default_ShouldReturnValidDefaultLocation()
        {
            // Act
            GameObjectLocation defaultLocation = GameObjectLocation.Default;
            
            // Assert
            Assert.Equal(int.MaxValue, defaultLocation.Index);
            // Note: Default archetype may be null in the default static property
        }
        
        /// <summary>
        ///     Tests that has event with no flags returns false.
        /// </summary>
        [Fact]
        public void HasEvent_WithNoFlags_ShouldReturnFalse()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectLocation location = new GameObjectLocation(archetype, 0, GameObjectFlags.None);
            
            // Act
            bool hasEvent = location.HasEvent(GameObjectFlags.AddComp);
            
            // Assert
            Assert.False(hasEvent);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that has event with matching flag returns true.
        /// </summary>
        [Fact]
        public void HasEvent_WithMatchingFlag_ShouldReturnTrue()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectLocation location = new GameObjectLocation(archetype, 0, GameObjectFlags.AddComp);
            
            // Act
            bool hasEvent = location.HasEvent(GameObjectFlags.AddComp);
            
            // Assert
            Assert.True(hasEvent);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that has event with non matching flag returns false.
        /// </summary>
        [Fact]
        public void HasEvent_WithNonMatchingFlag_ShouldReturnFalse()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectLocation location = new GameObjectLocation(archetype, 0, GameObjectFlags.AddComp);
            
            // Act
            bool hasEvent = location.HasEvent(GameObjectFlags.RemoveComp);
            
            // Assert
            Assert.False(hasEvent);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that has event with multiple flags returns true if any match.
        /// </summary>
        [Fact]
        public void HasEvent_WithMultipleFlags_ShouldReturnTrueIfAnyMatch()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectFlags flags = GameObjectFlags.AddComp | GameObjectFlags.RemoveComp;
            GameObjectLocation location = new GameObjectLocation(archetype, 0, flags);
            
            // Act
            bool hasEvent1 = location.HasEvent(GameObjectFlags.AddComp);
            bool hasEvent2 = location.HasEvent(GameObjectFlags.RemoveComp);
            
            // Assert
            Assert.True(hasEvent1);
            Assert.True(hasEvent2);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that version field can be set and retrieved.
        /// </summary>
        [Fact]
        public void Version_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectLocation location = new GameObjectLocation(archetype, 0);
            
            // Act
            location.Version = 42;
            
            // Assert
            Assert.Equal((ushort)42, location.Version);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that index can be negative.
        /// </summary>
        [Fact]
        public void Index_WithNegativeValue_ShouldBeStored()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            
            // Act
            GameObjectLocation location = new GameObjectLocation(archetype, -1);
            
            // Assert
            Assert.Equal(-1, location.Index);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that flags can be modified after construction.
        /// </summary>
        [Fact]
        public void Flags_CanBeModified_AfterConstruction()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            GameObjectLocation location = new GameObjectLocation(archetype, 0);
            
            // Act
            location.Flags = GameObjectFlags.Tagged;
            
            // Assert
            Assert.Equal(GameObjectFlags.Tagged, location.Flags);
            
            world.Dispose();
        }
    }
}

