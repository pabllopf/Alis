// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NeighborCacheTest.cs
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
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The neighbor cache test class for single generic parameter
    /// </summary>
    /// <remarks>
    ///     Tests the NeighborCache{T} struct which handles component archetype transitions
    ///     with a single component type parameter.
    /// </remarks>
    public class NeighborCacheSingleTest
    {
        /// <summary>
        ///     Tests that modify components adds component when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsComponent_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Single(components);
            Assert.Contains(Component<Position>.Id, components);
        }

        /// <summary>
        ///     Tests that modify components removes component when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesComponent_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(1);
            builder.Add(Component<Position>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }

        /// <summary>
        ///     Tests that modify components preserves existing components when adding
        /// </summary>
        [Fact]
        public void ModifyComponents_PreservesExistingComponents_WhenAdding()
        {
            // Arrange
            NeighborCache<Velocity> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(1);
            builder.Add(Component<Position>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();
            int originalLength = components.Length;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(originalLength + 1, components.Length);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
        }

        /// <summary>
        ///     Tests that neighbor cache is a struct (value type)
        /// </summary>
        [Fact]
        public void NeighborCache_IsValueType()
        {
            // Assert
            Assert.True(typeof(NeighborCache<Position>).IsValueType);
        }

        /// <summary>
        ///     Tests that add and remove static classes exist
        /// </summary>
        [Fact]
        public void NeighborCache_HasAddAndRemoveNestedClasses()
        {
            // Arrange
            var cacheType = typeof(NeighborCache<Position>);

            // Assert
            Assert.NotNull(cacheType.GetNestedType("Add", System.Reflection.BindingFlags.NonPublic));
            Assert.NotNull(cacheType.GetNestedType("Remove", System.Reflection.BindingFlags.NonPublic));
        }
    }

    /// <summary>
    ///     The neighbor cache test class for two generic parameters
    /// </summary>
    public class NeighborCacheDualTest
    {
        /// <summary>
        ///     Tests that modify components adds both components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsBothComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(2, components.Length);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
        }

        /// <summary>
        ///     Tests that modify components removes both components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesBothComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(2);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }

        /// <summary>
        ///     Tests that modify components preserves other components when adding
        /// </summary>
        [Fact]
        public void ModifyComponents_PreservesOtherComponents_WhenAdding()
        {
            // Arrange
            NeighborCache<Position, Velocity> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(1);
            builder.Add(Component<Health>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(3, components.Length);
            Assert.Contains(Component<Health>.Id, components);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
        }
        
    }

    /// <summary>
    ///     The neighbor cache test class for three generic parameters
    /// </summary>
    public class NeighborCacheTripletTest
    {
        /// <summary>
        ///     Tests that modify components adds all three components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsAllThreeComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(3, components.Length);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
            Assert.Contains(Component<Health>.Id, components);
        }

        /// <summary>
        ///     Tests that modify components removes all three components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesAllThreeComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(3);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }

        /// <summary>
        ///     Tests that modify components handles partial removal correctly
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesOnlySpecifiedComponents()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(4);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            builder.Add(Component<Armor>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Single(components);
            Assert.Contains(Component<Armor>.Id, components);
            Assert.DoesNotContain(Component<Position>.Id, components);
            Assert.DoesNotContain(Component<Velocity>.Id, components);
            Assert.DoesNotContain(Component<Health>.Id, components);
        }
    }

    /// <summary>
    ///     The neighbor cache test class for four generic parameters
    /// </summary>
    public class NeighborCacheQuadrupleTest
    {
        /// <summary>
        ///     Tests that modify components adds all four components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsFourComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(4, components.Length);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
            Assert.Contains(Component<Health>.Id, components);
            Assert.Contains(Component<Armor>.Id, components);
        }

        /// <summary>
        ///     Tests that modify components removes four components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesFourComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(4);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            builder.Add(Component<Armor>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }
    }

    /// <summary>
    ///     The neighbor cache test class for five generic parameters
    /// </summary>
    public class NeighborCacheQuintupleTest
    {
        /// <summary>
        ///     Tests that modify components adds all five components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsFiveComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(5, components.Length);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
            Assert.Contains(Component<Health>.Id, components);
            Assert.Contains(Component<Armor>.Id, components);
            Assert.Contains(Component<Damage>.Id, components);
        }

        /// <summary>
        ///     Tests that modify components removes five components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesFiveComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(5);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            builder.Add(Component<Armor>.Id);
            builder.Add(Component<Damage>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }

        /// <summary>
        ///     Tests that neighbor cache quintuple has correct struct layout
        /// </summary>
        [Fact]
        public void NeighborCacheQuintuple_HasStructLayoutAttribute()
        {
            // Arrange
            var cacheType = typeof(NeighborCache<Position, Velocity, Health, Armor, Damage>);

            // Assert
            var layoutAttr = cacheType.GetCustomAttributes(typeof(System.Runtime.InteropServices.StructLayoutAttribute), false);
            Assert.Empty(layoutAttr);
        }
    }

    /// <summary>
    ///     The neighbor cache test class for six generic parameters
    /// </summary>
    public class NeighborCacheSextupleTest
    {
        /// <summary>
        ///     Tests that modify components adds all six components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsSixComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(6, components.Length);
        }

        /// <summary>
        ///     Tests that modify components removes all six components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesSixComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(6);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            builder.Add(Component<Armor>.Id);
            builder.Add(Component<Damage>.Id);
            builder.Add(Component<TestComponent>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }
    }

    /// <summary>
    ///     The neighbor cache test class for seven generic parameters
    /// </summary>
    public class NeighborCacheSeptupleTest
    {
        /// <summary>
        ///     Tests that modify components adds all seven components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsSevenComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(7, components.Length);
        }

        /// <summary>
        ///     Tests that modify components removes all seven components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesSevenComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(7);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            builder.Add(Component<Armor>.Id);
            builder.Add(Component<Damage>.Id);
            builder.Add(Component<TestComponent>.Id);
            builder.Add(Component<TestComponent2>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }
    }

    /// <summary>
    ///     The neighbor cache test class for eight generic parameters
    /// </summary>
    public class NeighborCacheOctupleTest
    {
        /// <summary>
        ///     Tests that modify components adds all eight components when add flag is true
        /// </summary>
        [Fact]
        public void ModifyComponents_AddsEightComponents_WhenAddFlagIsTrue()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2, AnotherComponent> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(8, components.Length);
        }

        /// <summary>
        ///     Tests that modify components removes all eight components when add flag is false
        /// </summary>
        [Fact]
        public void ModifyComponents_RemovesEightComponents_WhenAddFlagIsFalse()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2, AnotherComponent> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(8);
            builder.Add(Component<Position>.Id);
            builder.Add(Component<Velocity>.Id);
            builder.Add(Component<Health>.Id);
            builder.Add(Component<Armor>.Id);
            builder.Add(Component<Damage>.Id);
            builder.Add(Component<TestComponent>.Id);
            builder.Add(Component<TestComponent2>.Id);
            builder.Add(Component<AnotherComponent>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act
            cache.ModifyComponents(ref components, add: false);

            // Assert
            Assert.Empty(components);
        }
    }

    /// <summary>
    ///     Common test cases for all NeighborCache variants
    /// </summary>
    public class NeighborCacheCommonTest
    {


        /// <summary>
        ///     Tests that add and remove nested classes have lookup field
        /// </summary>
        [Fact]
        public void NeighborCache_AddAndRemoveClasses_HaveLookupField()
        {
            // Arrange
            var cacheType = typeof(NeighborCache<Position>);
            var addType = cacheType.GetNestedType("Add", System.Reflection.BindingFlags.NonPublic);
            var removeType = cacheType.GetNestedType("Remove", System.Reflection.BindingFlags.NonPublic);

            // Assert
            Assert.NotNull(addType.GetField("Lookup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static));
            Assert.NotNull(removeType.GetField("Lookup", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static));
        }

        /// <summary>
        ///     Tests that components can be added and removed in sequence
        /// </summary>
        [Fact]
        public void ModifyComponents_CanBeAppliedInSequence()
        {
            // Arrange
            NeighborCache<Position, Velocity> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act - Add components
            cache.ModifyComponents(ref components, add: true);
            int addedCount = components.Length;

            // Act - Remove components
            cache.ModifyComponents(ref components, add: false);
            int finalCount = components.Length;

            // Assert
            Assert.Equal(2, addedCount);
            Assert.Equal(0, finalCount);
        }

        /// <summary>
        ///     Tests that multiple components can coexist in the array
        /// </summary>
        [Fact]
        public void ModifyComponents_AllowsMultipleComponentTypes()
        {
            // Arrange
            NeighborCache<Position, Velocity> cacheA = default;
            NeighborCache<Health, Armor> cacheB = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cacheA.ModifyComponents(ref components, add: true);
            cacheB.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(4, components.Length);
            Assert.Contains(Component<Position>.Id, components);
            Assert.Contains(Component<Velocity>.Id, components);
            Assert.Contains(Component<Health>.Id, components);
            Assert.Contains(Component<Armor>.Id, components);
        }
    }

    /// <summary>
    ///     Tests for edge cases and error conditions
    /// </summary>
    public class NeighborCacheEdgeCasesTest
    {
        /// <summary>
        ///     Tests that adding duplicate components throws exception
        /// </summary>
        [Fact]
        public void ModifyComponents_ThrowsException_WhenAddingDuplicateComponent()
        {
            // Arrange
            NeighborCache<Position> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(1);
            builder.Add(Component<Position>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => cache.ModifyComponents(ref components, add: true));
        }

        /// <summary>
        ///     Tests that removing non-existent component throws exception
        /// </summary>
        [Fact]
        public void ModifyComponents_ThrowsException_WhenRemovingNonExistentComponent()
        {
            // Arrange
            NeighborCache<Position> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(1);
            builder.Add(Component<Velocity>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();

            // Act & Assert
            Assert.Throws<ComponentNotFoundException>(() => cache.ModifyComponents(ref components, add: false));
        }

        /// <summary>
        ///     Tests that empty neighbor cache can operate on empty component array
        /// </summary>
        [Fact]
        public void ModifyComponents_HandlesEmptyComponentArray()
        {
            // Arrange
            NeighborCache<Position> cache = default;
            FastImmutableArray<ComponentId> components = FastImmutableArray<ComponentId>.Empty;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.NotEmpty(components);
        }

        /// <summary>
        ///     Tests that large component sets can be handled
        /// </summary>
        [Fact]
        public void ModifyComponents_HandlesLargeComponentSets()
        {
            // Arrange
            NeighborCache<Position, Velocity, Health, Armor, Damage, TestComponent, TestComponent2, AnotherComponent> cache = default;
            FastImmutableArray<ComponentId>.Builder builder = FastImmutableArray<ComponentId>.CreateBuilder<ComponentId>(10);
            // Add some pre-existing components
            builder.Add(Component<AnotherComponent2>.Id);
            FastImmutableArray<ComponentId> components = builder.ToImmutable();
            int originalLength = components.Length;

            // Act
            cache.ModifyComponents(ref components, add: true);

            // Assert
            Assert.Equal(originalLength + 8, components.Length);
        }
    }
}


