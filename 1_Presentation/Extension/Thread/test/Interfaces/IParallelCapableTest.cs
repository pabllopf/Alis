// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IParallelCapableTest.cs
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
using Alis.Extension.Thread.Interfaces;
using Xunit;

namespace Alis.Extension.Thread.Test.Interfaces
{
    /// <summary>
    /// The component with interface
    /// </summary>
    internal struct ComponentWithInterface : IParallelCapable
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    /// The class with interface class
    /// </summary>
    /// <seealso cref="IParallelCapable"/>
    internal class ClassWithInterface : IParallelCapable
    {
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public int Value { get; set; }
    }

    /// <summary>
    /// The component without interface
    /// </summary>
    internal struct ComponentWithoutInterface
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value;
    }

    /// <summary>
    /// The component with multiple interfaces
    /// </summary>
    internal struct ComponentWithMultipleInterfaces : IParallelCapable, IDisposable
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value;

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
        }
    }

    /// <summary>
    ///     The i parallel capable test class
    /// </summary>
    public class IParallelCapableTest
    {
        /// <summary>
        ///     Tests that interface can be implemented by struct
        /// </summary>
        [Fact]
        public void Interface_CanBeImplementedByStruct()
        {
            // Act
            bool isAssignable = typeof(IParallelCapable).IsAssignableFrom(typeof(ComponentWithInterface));

            // Assert
            Assert.True(isAssignable);
        }

        /// <summary>
        ///     Tests that interface can be implemented by class
        /// </summary>
        [Fact]
        public void Interface_CanBeImplementedByClass()
        {
            // Act
            bool isAssignable = typeof(IParallelCapable).IsAssignableFrom(typeof(ClassWithInterface));

            // Assert
            Assert.True(isAssignable);
        }

        /// <summary>
        ///     Tests that struct implementing interface can be instantiated
        /// </summary>
        [Fact]
        public void Struct_ImplementingInterface_CanBeInstantiated()
        {
            // Act
            ComponentWithInterface component = new ComponentWithInterface {Value = 42};

            // Assert
            Assert.Equal(42, component.Value);
            Assert.IsAssignableFrom<IParallelCapable>(component);
        }

        /// <summary>
        ///     Tests that class implementing interface can be instantiated
        /// </summary>
        [Fact]
        public void Class_ImplementingInterface_CanBeInstantiated()
        {
            // Act
            ClassWithInterface component = new ClassWithInterface {Value = 42};

            // Assert
            Assert.Equal(42, component.Value);
            Assert.IsAssignableFrom<IParallelCapable>(component);
        }

        /// <summary>
        ///     Tests that component without interface is not assignable
        /// </summary>
        [Fact]
        public void Component_WithoutInterface_IsNotAssignable()
        {
            // Act
            bool isAssignable = typeof(IParallelCapable).IsAssignableFrom(typeof(ComponentWithoutInterface));

            // Assert
            Assert.False(isAssignable);
        }

        /// <summary>
        ///     Tests that interface is marker interface with no methods
        /// </summary>
        [Fact]
        public void Interface_IsMarkerInterfaceWithNoMethods()
        {
            // Act
            var methods = typeof(IParallelCapable).GetMethods();

            // Assert
            Assert.Empty(methods);
        }

        /// <summary>
        ///     Tests that interface is marker interface with no properties
        /// </summary>
        [Fact]
        public void Interface_IsMarkerInterfaceWithNoProperties()
        {
            // Act
            var properties = typeof(IParallelCapable).GetProperties();

            // Assert
            Assert.Empty(properties);
        }

        /// <summary>
        ///     Tests that interface can be combined with other interfaces
        /// </summary>
        [Fact]
        public void Interface_CanBeCombinedWithOtherInterfaces()
        {
            // Act
            bool implementsParallelCapable = typeof(IParallelCapable).IsAssignableFrom(typeof(ComponentWithMultipleInterfaces));
            bool implementsDisposable = typeof(IDisposable).IsAssignableFrom(typeof(ComponentWithMultipleInterfaces));

            // Assert
            Assert.True(implementsParallelCapable);
            Assert.True(implementsDisposable);
        }

        /// <summary>
        ///     Tests that interface can be checked at runtime
        /// </summary>
        [Fact]
        public void Interface_CanBeCheckedAtRuntime()
        {
            // Arrange
            object component = new ComponentWithInterface {Value = 10};

            // Act
            bool isParallelCapable = component is IParallelCapable;

            // Assert
            Assert.True(isParallelCapable);
        }

        /// <summary>
        ///     Tests that interface can be cast
        /// </summary>
        [Fact]
        public void Interface_CanBeCast()
        {
            // Arrange
            ComponentWithInterface component = new ComponentWithInterface {Value = 20};

            // Act
            IParallelCapable parallelCapable = component;

            // Assert
            Assert.NotNull(parallelCapable);
        }

        /// <summary>
        ///     Tests that get interfaces returns correct interface
        /// </summary>
        [Fact]
        public void GetInterfaces_ReturnsCorrectInterface()
        {
            // Arrange
            Type type = typeof(ComponentWithInterface);

            // Act
            Type[] interfaces = type.GetInterfaces();

            // Assert
            Assert.Contains(typeof(IParallelCapable), interfaces);
        }

        /// <summary>
        ///     Tests that interface is public
        /// </summary>
        [Fact]
        public void Interface_IsPublic()
        {
            // Act
            bool isPublic = typeof(IParallelCapable).IsPublic;

            // Assert
            Assert.True(isPublic);
        }

        /// <summary>
        ///     Tests that interface is interface type
        /// </summary>
        [Fact]
        public void Interface_IsInterfaceType()
        {
            // Act
            bool isInterface = typeof(IParallelCapable).IsInterface;

            // Assert
            Assert.True(isInterface);
        }

        /// <summary>
        ///     Tests that multiple types can implement interface
        /// </summary>
        [Fact]
        public void MultipleTypes_CanImplementInterface()
        {
            // Arrange
            Type[] types = new[]
            {
                typeof(ComponentWithInterface),
                typeof(ClassWithInterface),
                typeof(ComponentWithMultipleInterfaces)
            };

            // Act & Assert
            foreach (Type type in types)
            {
                Assert.True(typeof(IParallelCapable).IsAssignableFrom(type));
            }
        }

        /// <summary>
        ///     Tests that interface can be used as type constraint
        /// </summary>
        [Fact]
        public void Interface_CanBeUsedAsTypeConstraint()
        {
            // Act
            var result = ProcessParallelCapable(new ComponentWithInterface {Value = 100});

            // Assert
            Assert.Equal(100, result);
        }

        /// <summary>
        /// Processes the parallel capable using the specified component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        private int ProcessParallelCapable<T>(T component) where T : struct, IParallelCapable
        {
            if (component is ComponentWithInterface comp)
            {
                return comp.Value;
            }

            return 0;
        }

        /// <summary>
        ///     Tests that interface namespace is correct
        /// </summary>
        [Fact]
        public void Interface_NamespaceIsCorrect()
        {
            // Act
            string namespaceName = typeof(IParallelCapable).Namespace;

            // Assert
            Assert.Equal("Alis.Extension.Thread.Interfaces", namespaceName);
        }

        /// <summary>
        ///     Tests that interface name is correct
        /// </summary>
        [Fact]
        public void Interface_NameIsCorrect()
        {
            // Act
            string name = typeof(IParallelCapable).Name;

            // Assert
            Assert.Equal("IParallelCapable", name);
        }

        /// <summary>
        ///     Tests that interface has no base interfaces
        /// </summary>
        [Fact]
        public void Interface_HasNoBaseInterfaces()
        {
            // Act
            Type[] baseInterfaces = typeof(IParallelCapable).GetInterfaces();

            // Assert
            Assert.Empty(baseInterfaces);
        }
    }
}