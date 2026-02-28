// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeEdgeTypeTest.cs
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

namespace Alis.Core.Ecs.Test.Kernel.Archetypes
{
    /// <summary>
    ///     Tests the <see cref="ArchetypeEdgeType"/> enum.
    /// </summary>
    public class ArchetypeEdgeTypeTest
    {
        /// <summary>
        ///     Tests that add component has correct value.
        /// </summary>
        [Fact]
        public void Add_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;
            
            // Assert
            Assert.Equal((ushort)49157, (ushort)edgeType);
        }
        
        /// <summary>
        ///     Tests that remove component has correct value.
        /// </summary>
        [Fact]
        public void RemoveComponent_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.RemoveComponent;
            
            // Assert
            Assert.Equal((ushort)24593, (ushort)edgeType);
        }
        
        /// <summary>
        ///     Tests that add tag has correct value.
        /// </summary>
        [Fact]
        public void AddTag_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddTag;
            
            // Assert
            Assert.Equal((ushort)12289, (ushort)edgeType);
        }
        
        /// <summary>
        ///     Tests that remove tag has correct value.
        /// </summary>
        [Fact]
        public void RemoveTag_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.RemoveTag;
            
            // Assert
            Assert.Equal((ushort)6151, (ushort)edgeType);
        }
        
        /// <summary>
        ///     Tests that all edge types have unique values.
        /// </summary>
        [Fact]
        public void AllEdgeTypes_ShouldHaveUniqueValues()
        {
            // Arrange
            ushort Add = (ushort)ArchetypeEdgeType.AddComponent;
            ushort removeComponent = (ushort)ArchetypeEdgeType.RemoveComponent;
            ushort addTag = (ushort)ArchetypeEdgeType.AddTag;
            ushort removeTag = (ushort)ArchetypeEdgeType.RemoveTag;
            
            // Assert
            Assert.NotEqual(Add, removeComponent);
            Assert.NotEqual(Add, addTag);
            Assert.NotEqual(Add, removeTag);
            Assert.NotEqual(removeComponent, addTag);
            Assert.NotEqual(removeComponent, removeTag);
            Assert.NotEqual(addTag, removeTag);
        }
        
        /// <summary>
        ///     Tests that edge type can be compared.
        /// </summary>
        [Fact]
        public void EdgeType_CanBeCompared()
        {
            // Arrange
            ArchetypeEdgeType type1 = ArchetypeEdgeType.AddComponent;
            ArchetypeEdgeType type2 = ArchetypeEdgeType.AddComponent;
            ArchetypeEdgeType type3 = ArchetypeEdgeType.RemoveComponent;
            
            // Act & Assert
            Assert.Equal(type1, type2);
            Assert.NotEqual(type1, type3);
        }
        
        /// <summary>
        ///     Tests that edge type can be cast to ushort.
        /// </summary>
        [Fact]
        public void EdgeType_CanBeCastToUShort()
        {
            // Arrange
            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;
            
            // Act
            ushort value = (ushort)edgeType;
            
            // Assert
            Assert.Equal((ushort)49157, value);
        }
        
        /// <summary>
        ///     Tests that ushort can be cast to edge type.
        /// </summary>
        [Fact]
        public void UShort_CanBeCastToEdgeType()
        {
            // Arrange
            ushort value = 49157;
            
            // Act
            ArchetypeEdgeType edgeType = (ArchetypeEdgeType)value;
            
            // Assert
            Assert.Equal(ArchetypeEdgeType.AddComponent, edgeType);
        }
        
        /// <summary>
        ///     Tests that edge type values are within ushort range.
        /// </summary>
        [Fact]
        public void EdgeTypeValues_ShouldBeWithinUShortRange()
        {
            // Arrange & Act
            ushort Add = (ushort)ArchetypeEdgeType.AddComponent;
            ushort removeComponent = (ushort)ArchetypeEdgeType.RemoveComponent;
            ushort addTag = (ushort)ArchetypeEdgeType.AddTag;
            ushort removeTag = (ushort)ArchetypeEdgeType.RemoveTag;
            
            // Assert
            Assert.True(Add >= ushort.MinValue && Add <= ushort.MaxValue);
            Assert.True(removeComponent >= ushort.MinValue && removeComponent <= ushort.MaxValue);
            Assert.True(addTag >= ushort.MinValue && addTag <= ushort.MaxValue);
            Assert.True(removeTag >= ushort.MinValue && removeTag <= ushort.MaxValue);
        }
    }
}

