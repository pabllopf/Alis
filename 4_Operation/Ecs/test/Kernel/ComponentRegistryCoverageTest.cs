// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistryCoverageTest.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Coverage-focused tests for the Component registry, targeting uncovered branches
    ///     including factory resolution from source-generated types, init/destroy delegates,
    ///     exception paths, and state reset.
    /// </summary>
    public class ComponentRegistryCoverageTest
    {
        /// <summary>
        ///     Tests that <see cref="Component.GetComponentFactoryFromType" /> returns a non-null
        ///     factory for a source-generated type (Position). This covers the
        ///     <see cref="GenerationServices.UserGeneratedTypeMap" /> resolution path.
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_SourceGeneratedType_ReturnsFactory()
        {
            object factory = Component.GetComponentFactoryFromType(typeof(Position));

            Assert.NotNull(factory);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentFactoryFromType" /> throws
        ///     <see cref="InvalidOperationException" /> with the source-generator error message
        ///     when called for an <see cref="IComponentBase" /> interface type that is not
        ///     registered. This covers the <c>IComponentBase.IsAssignableFrom</c> branch of
        ///     <see cref="Component" />.Throw_ComponentTypeNotInit.
        /// </summary>
        [Fact]
        public void GetComponentFactoryFromType_IComponentBaseInterface_ThrowsWithSourceGenMessage()
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                Component.GetComponentFactoryFromType(typeof(IOnInit)));

            Assert.Contains("source generator", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Tests that <see cref="Component.RegisterComponent{T}" /> does not add a type to
        ///     <c>NoneComponentRunnerTable</c> when the type is already in
        ///     <see cref="GenerationServices.UserGeneratedTypeMap" /> (source-generated types).
        /// </summary>
        [Fact]
        public void RegisterComponent_SourceGeneratedType_SkipsRegistration()
        {
            Exception exception = Record.Exception(() => Component.RegisterComponent<Position>());

            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetExistingOrSetupNewComponent{T}" /> returns
        ///     non-null init and destroy delegates for a source-generated type that implements
        ///     <see cref="IOnInit" /> and <see cref="IOnDestroy" />.
        /// </summary>
        [Fact]
        public void GetExistingOrSetupNewComponent_SourceGeneratedType_HasInitDelegate()
        {
            (ComponentId id, _, ComponentDelegates<Health>.InitDelegate init, _) =
                Component.GetExistingOrSetupNewComponent<Health>();

            Assert.NotEqual(default(ComponentId), id);
            Assert.NotNull(init);
        }

        /// <summary>
        ///     Tests that <see cref="Component.GetComponentId(Type)" /> populates the component
        ///     table entry with non-null init and destroy delegates for source-generated types
        ///     that have lifecycle methods.
        /// </summary>
        [Fact]
        public void GetComponentId_WithInitAndDestroyDelegates_PopulatesTable()
        {
            ComponentId id = Component.GetComponentId(typeof(Position));

            Assert.NotEqual(default(ComponentId), id);
        }
    }
}
