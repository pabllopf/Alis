// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The ref test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Ref{T}"/> ref struct which provides
    ///     a wrapper over a reference to a component of type T.
    /// </remarks>
    public class RefTest
    {
        /// <summary>
        ///     Tests that ref can wrap component reference
        /// </summary>
        /// <remarks>
        ///     Verifies that Ref can properly wrap a component reference.
        /// </remarks>
        [Fact]
        public void Ref_CanWrapComponentReference()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new TestComponent { Value = 42, Name = "Test" });

            // Act
            ref TestComponent component = ref entity.Get<TestComponent>();

            // Assert
            Assert.Equal(42, component.Value);
            Assert.Equal("Test", component.Name);
        }

        /// <summary>
        ///     Tests that ref allows modification of component
        /// </summary>
        /// <remarks>
        ///     Tests that modifications through Ref are reflected in the original component.
        /// </remarks>
        [Fact]
        public void Ref_AllowsModificationOfComponent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new TestComponent { Value = 10 });

            // Act
            ref TestComponent component = ref entity.Get<TestComponent>();
            component.Value = 100;

            // Assert
            Assert.Equal(100, entity.Get<TestComponent>().Value);
        }

        /// <summary>
        ///     Tests that ref modifications are persistent
        /// </summary>
        /// <remarks>
        ///     Validates that modifications through Ref persist across multiple accesses.
        /// </remarks>
        [Fact]
        public void Ref_ModificationsArePersistent()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new TestComponent { Value = 5, Name = "Initial" });

            // Act
            ref TestComponent comp1 = ref entity.Get<TestComponent>();
            comp1.Value = 50;
            comp1.Name = "Modified";

            ref TestComponent comp2 = ref entity.Get<TestComponent>();

            // Assert
            Assert.Equal(50, comp2.Value);
            Assert.Equal("Modified", comp2.Name);
        }

        /// <summary>
        ///     Tests that ref works with value types
        /// </summary>
        /// <remarks>
        ///     Tests that Ref properly works with value type components.
        /// </remarks>
        [Fact]
        public void Ref_WorksWithValueTypes()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(100);

            // Act
            ref int value = ref entity.Get<int>();
            value = 200;

            // Assert
            Assert.Equal(200, entity.Get<int>());
        }

        /// <summary>
        ///     Tests that ref can be used in iterations
        /// </summary>
        /// <remarks>
        ///     Tests that Ref can be used when iterating through query results.
        /// </remarks>
        [Fact]
        public void Ref_CanBeUsedInIterations()
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                scene.Create(new TestComponent { Value = i });
            }

            // Act
            var query = scene.Query<With<TestComponent>>();
            foreach (var component in query.Enumerate<TestComponent>())
            {
                component.Item1.Value.Value *= 2;
            }

            // Assert
            int expectedValue = 0;
            foreach (var component in query.Enumerate<TestComponent>())
            {
                Assert.Equal(expectedValue * 2, component.Item1.Value.Value);
                expectedValue++;
            }
        }

        /// <summary>
        ///     Tests that ref allows field access
        /// </summary>
        /// <remarks>
        ///     Validates that Ref allows direct field access to the wrapped component.
        /// </remarks>
        [Fact]
        public void Ref_AllowsFieldAccess()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new TestComponent { Value = 123, Name = "FieldTest" });

            // Act
            ref TestComponent component = ref entity.Get<TestComponent>();
            int value = component.Value;
            string name = component.Name;

            // Assert
            Assert.Equal(123, value);
            Assert.Equal("FieldTest", name);
        }

        /// <summary>
        ///     Tests that multiple refs to same component reference same data
        /// </summary>
        /// <remarks>
        ///     Tests that multiple Ref instances to the same component reference the same data.
        /// </remarks>
        [Fact]
        public void MultipleRefs_ToSameComponent_ReferenceSameData()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new TestComponent { Value = 77 });

            // Act
            ref TestComponent ref1 = ref entity.Get<TestComponent>();
            ref1.Value = 88;

            ref TestComponent ref2 = ref entity.Get<TestComponent>();

            // Assert
            Assert.Equal(88, ref2.Value);
        }

        /// <summary>
        ///     Tests that ref works with complex types
        /// </summary>
        /// <remarks>
        ///     Tests that Ref properly handles complex component types.
        /// </remarks>
        [Fact]
        public void Ref_WorksWithComplexTypes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new ComplexComponent
            {
                Id = 1,
                Name = "Complex",
                Values = new[] {1.0f, 2.0f, 3.0f}
            });

            // Act
            ref ComplexComponent component = ref entity.Get<ComplexComponent>();
            component.Id = 10;
            component.Values[0] = 10.0f;

            // Assert
            Assert.Equal(10, entity.Get<ComplexComponent>().Id);
            Assert.Equal(10.0f, entity.Get<ComplexComponent>().Values[0]);
        }
    }
}

