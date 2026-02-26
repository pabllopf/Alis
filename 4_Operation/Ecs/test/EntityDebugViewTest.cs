// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityDebugViewTest.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="EntityDebugView"/> class.
    /// </summary>
    public class EntityDebugViewTest
    {
        /// <summary>
        ///     Tests that constructor with valid entity should initialize properties correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithValidEntity_ShouldInitializeProperties()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position());
            entity.Add(new Velocity());
            
            // Act
            EntityDebugView debugView = new EntityDebugView(entity);
            
            // Assert
            Assert.NotNull(debugView);
            Assert.NotNull(debugView.ComponentTypes);
            Assert.NotNull(debugView.Tags);
            Assert.NotNull(debugView.Components);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that component types returns correct component types for entity.
        /// </summary>
        [Fact]
        public void ComponentTypes_WithComponents_ShouldReturnCorrectTypes()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position());
            entity.Add(new Velocity());
            
            // Act
            EntityDebugView debugView = new EntityDebugView(entity);
            var componentTypes = debugView.ComponentTypes;
            
            // Assert
            Assert.Equal(2, componentTypes.Length);
            Assert.Contains(componentTypes, c => c.Type == typeof(Position));
            Assert.Contains(componentTypes, c => c.Type == typeof(Velocity));
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that tags returns correct tag types for entity.
        /// </summary>
        [Fact]
        public void Tags_WithTags_ShouldReturnCorrectTags()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Tag<PlayerTag>();
            
            // Act
            EntityDebugView debugView = new EntityDebugView(entity);
            var tags = debugView.Tags;
            
            // Assert
            Assert.Single(tags);
            Assert.Equal(typeof(PlayerTag), tags[0].Type);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that components returns dictionary with all components.
        /// </summary>
        [Fact]
        public void Components_WithMultipleComponents_ShouldReturnDictionary()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position position = new Position { X = 10, Y = 20 };
            Velocity velocity = new Velocity { VX = 1, VY = 2 };
            entity.Add(position);
            entity.Add(velocity);
            
            // Act
            EntityDebugView debugView = new EntityDebugView(entity);
            Dictionary<Type, object> components = debugView.Components;
            
            // Assert
            Assert.Equal(2, components.Count);
            Assert.True(components.ContainsKey(typeof(Position)));
            Assert.True(components.ContainsKey(typeof(Velocity)));
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that components with dead entity should return empty dictionary.
        /// </summary>
        [Fact]
        public void Components_WithDeadEntity_ShouldReturnEmptyDictionary()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position());
            entity.Delete();
            
            // Act
            EntityDebugView debugView = new EntityDebugView(entity);
            Dictionary<Type, object> components = debugView.Components;
            
            // Assert
            Assert.Empty(components);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that components with no components should return empty dictionary.
        /// </summary>
        [Fact]
        public void Components_WithNoComponents_ShouldReturnEmptyDictionary()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            
            // Act
            EntityDebugView debugView = new EntityDebugView(entity);
            Dictionary<Type, object> components = debugView.Components;
            
            // Assert
            Assert.Empty(components);
            
            world.Dispose();
        }
    }
}

