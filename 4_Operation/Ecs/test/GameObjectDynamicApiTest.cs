// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectDynamicApiTest.cs
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
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests dynamic and non-generic APIs on <see cref="GameObject" />.
    /// </summary>
    public class GameObjectDynamicApiTest
    {
        /// <summary>
        ///     Tests that game object has and try has by type and component id work
        /// </summary>
        [Fact]
        public void GameObject_HasAndTryHas_ByTypeAndComponentId_Work()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            ComponentId posId = Component<Position>.Id;
            ComponentId velId = Component<Velocity>.Id;

            Assert.True(entity.Has(typeof(Position)));
            Assert.True(entity.Has(posId));
            Assert.True(entity.TryHas(typeof(Position)));
            Assert.True(entity.TryHas(posId));

            Assert.False(entity.Has(typeof(Velocity)));
            Assert.False(entity.Has(velId));
            Assert.False(entity.TryHas(typeof(Velocity)));
            Assert.False(entity.TryHas(velId));
        }

        /// <summary>
        ///     Tests that game object get and set by component id work
        /// </summary>
        [Fact]
        public void GameObject_GetAndSet_ByComponentId_Work()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 3, Y = 4});
            ComponentId posId = Component<Position>.Id;

            object boxed = entity.Get(posId);
            Assert.IsType<Position>(boxed);
            Assert.Equal(3, ((Position) boxed).X);

            entity.Set(posId, new Position {X = 30, Y = 40});
            Position updated = entity.Get<Position>();
            Assert.Equal(30, updated.X);
            Assert.Equal(40, updated.Y);
        }

        /// <summary>
        ///     Tests that game object get and set by type work
        /// </summary>
        [Fact]
        public void GameObject_GetAndSet_ByType_Work()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Velocity {X = 1, Y = 2});

            object boxed = entity.Get(typeof(Velocity));
            Assert.IsType<Velocity>(boxed);
            Assert.Equal(1, ((Velocity) boxed).X);

            entity.Set(typeof(Velocity), new Velocity {X = 11, Y = 22});
            Velocity updated = entity.Get<Velocity>();
            Assert.Equal(11, updated.X);
            Assert.Equal(22, updated.Y);
        }

        /// <summary>
        ///     Tests that game object try get by type returns expected result
        /// </summary>
        [Fact]
        public void GameObject_TryGet_ByType_ReturnsExpectedResult()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Health {Value = 99});

            bool foundHealth = entity.TryGet(typeof(Health), out object healthObj);
            bool foundVelocity = entity.TryGet(typeof(Velocity), out object velocityObj);

            Assert.True(foundHealth);
            Assert.IsType<Health>(healthObj);
            Assert.Equal(99, ((Health) healthObj).Value);

            Assert.False(foundVelocity);
            Assert.Null(velocityObj);
        }

        /// <summary>
        ///     Tests that game object add boxed adds component
        /// </summary>
        [Fact]
        public void GameObject_AddBoxed_AddsComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.AddBoxed(new Position {X = 7, Y = 8});

            Assert.True(entity.Has<Position>());
            Assert.Equal(7, entity.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that game object add as by type adds component as specified type
        /// </summary>
        [Fact]
        public void GameObject_AddAs_ByType_AddsComponentAsSpecifiedType()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.AddAs(typeof(TestComponent), new TestComponent {Value = 123});

            Assert.True(entity.Has<TestComponent>());
            Assert.Equal(123, entity.Get<TestComponent>().Value);
        }

        /// <summary>
        ///     Tests that game object add as by component id adds component as specified type
        /// </summary>
        [Fact]
        public void GameObject_AddAs_ByComponentId_AddsComponentAsSpecifiedType()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            ComponentId compId = Component<AnotherComponent2>.Id;

            entity.AddAs(compId, new AnotherComponent2 {Name = "boxed"});

            Assert.True(entity.Has<AnotherComponent2>());
            Assert.Equal("boxed", entity.Get<AnotherComponent2>().Name);
        }

        /// <summary>
        ///     Tests that game object remove by type and by component id work
        /// </summary>
        [Fact]
        public void GameObject_Remove_ByTypeAndByComponentId_Work()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            entity.Remove(typeof(Position));
            Assert.False(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());

            entity.Remove(Component<Velocity>.Id);
            Assert.False(entity.Has<Velocity>());
        }


        /// <summary>
        ///     Tests that game object on component added generic raises with concrete type
        /// </summary>
        [Fact]
        public void GameObject_OnComponentAddedGeneric_RaisesWithConcreteType()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            CaptureGenericAction action = new CaptureGenericAction();

            entity.OnComponentAddedGeneric += action;
            entity.Add(new Health {Value = 77});

            Assert.Equal(1, action.Calls);
            Assert.Contains(typeof(Health), action.SeenTypes);
        }

        /// <summary>
        ///     Tests that game object on component removed generic raises with concrete type
        /// </summary>
        [Fact]
        public void GameObject_OnComponentRemovedGeneric_RaisesWithConcreteType()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 5, Y = 6});
            CaptureGenericAction action = new CaptureGenericAction();

            entity.OnComponentRemovedGeneric += action;
            entity.Remove<Position>();

            Assert.Equal(1, action.Calls);
            Assert.Contains(typeof(Position), action.SeenTypes);
        }

        /// <summary>
        ///     Tests that game object enumerate components invokes action for each component
        /// </summary>
        [Fact]
        public void GameObject_EnumerateComponents_InvokesActionForEachComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 1}, new Velocity {X = 2, Y = 2}, new Health {Value = 3});
            CaptureComponentTypesAction action = new CaptureComponentTypesAction();

            entity.EnumerateComponents(action);

            Assert.Equal(3, action.Calls);
            Assert.Contains(typeof(Position), action.SeenTypes);
            Assert.Contains(typeof(Velocity), action.SeenTypes);
            Assert.Contains(typeof(Health), action.SeenTypes);
        }

        /// <summary>
        ///     Tests that game object metadata properties are consistent
        /// </summary>
        [Fact]
        public void GameObject_MetadataProperties_AreConsistent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 2, Y = 3});

            Assert.Equal(scene, entity.Scene);
            Assert.Equal(GameObject.EntityTypeOf([Component<Position>.Id]), entity.Type);
            Assert.Contains(Component<Position>.Id, entity.ComponentTypes);
        }

        /// <summary>
        ///     Tests that game object try has on deleted entity returns false without throwing
        /// </summary>
        [Fact]
        public void GameObject_TryHas_OnDeletedEntity_ReturnsFalseWithoutThrowing()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 1});
            entity.Delete();

            Assert.False(entity.TryHas<Position>());
            Assert.False(entity.TryHas(typeof(Position)));
            Assert.False(entity.TryHas(Component<Position>.Id));
        }

        /// <summary>
        ///     The capture component types action class
        /// </summary>
        /// <seealso cref="IGenericAction" />
        private sealed class CaptureComponentTypesAction : IGenericAction
        {
            /// <summary>
            ///     The calls
            /// </summary>
            internal int Calls;

            /// <summary>
            ///     Gets the value of the seen types
            /// </summary>
            internal HashSet<Type> SeenTypes { get; } = new HashSet<Type>();

            /// <summary>
            ///     Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type)
            {
                Calls++;
                SeenTypes.Add(typeof(T));
            }
        }

        /// <summary>
        ///     The capture generic action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}" />
        private sealed class CaptureGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     The calls
            /// </summary>
            internal int Calls;

            /// <summary>
            ///     Gets the value of the seen types
            /// </summary>
            internal HashSet<Type> SeenTypes { get; } = new HashSet<Type>();

            /// <summary>
            ///     Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                Calls++;
                SeenTypes.Add(typeof(T));
            }
        }
    }
}