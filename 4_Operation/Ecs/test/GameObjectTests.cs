// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTests.cs
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
using System.Linq;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The gameObject tests class
    /// </summary>
    public class GameObjectTests
    {
        static GameObjectTests()
        {
            Component.RegisterComponent<int>();
            Component.RegisterComponent<double>();
            Component.RegisterComponent<Struct1>();
            Component.RegisterComponent<Struct2>();
            Component.RegisterComponent<Struct3>();
            Component.RegisterComponent<Class1>();
            Component.RegisterComponent<Class2>();
            Component.RegisterComponent<BaseClass>();
            Component.RegisterComponent<ChildClass>();
        }
        
        /// <summary>
        ///     Tests that ctor creates null
        /// </summary>
        [Fact]
        public void Ctor_CreatesNull()
        {
            Assert.Equal(GameObject.Null, new GameObject());
            Assert.Equal(default(GameObject), new GameObject());
        }

        /// <summary>
        ///     Tests that on component added generic invoked
        /// </summary>
        [Fact]
        public void OnComponentAddedGeneric_Invoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                bool passed = false;

                entity.OnComponentAddedGeneric += new GenericAction((t, o) =>
                {
                    Assert.Equal(1, o);
                    if (t == typeof(int))
                    {
                        passed = true;
                    }
                });

                entity.Add(1);
                Assert.True(passed);
            }
        }

        /// <summary>
        ///     Tests that on component removed generic invoked
        /// </summary>
        [Fact]
        public void OnComponentRemovedGeneric_Invoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(1);
                bool passed = false;

                entity.OnComponentRemovedGeneric += new GenericAction((t, o) =>
                {
                    Assert.Equal(1, o);
                    if (t == typeof(int))
                    {
                        passed = true;
                    }
                });

                entity.Remove<int>();
                Assert.True(passed);
            }
        }

        /// <summary>
        ///     Tests that on component added invoked
        /// </summary>
        [Fact]
        public void OnComponentAdded_Invoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();
                bool passed = false;

                entity.OnComponentAdded += (t, o) =>
                {
                    Assert.Equal(1, t.Get<int>());
                    if (o.Type == typeof(int))
                    {
                        passed = true;
                    }
                };

                entity.Add(1);
                Assert.True(passed);
            }
        }

        /// <summary>
        ///     Tests that on component removed invoked
        /// </summary>
        [Fact]
        public void OnComponentRemoved_Invoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(1);
                bool passed = false;

                entity.OnComponentRemoved += (t, o) =>
                {
                    if (o.Type == typeof(int))
                    {
                        passed = true;
                    }
                };

                entity.Remove<int>();
                Assert.True(passed);
            }
        }

        /// <summary>
        ///     Tests that on delete invoked
        /// </summary>
        [Fact]
        public void OnDelete_Invoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(1);
                bool passed = false;

                entity.OnDelete += a => passed = true;
                entity.Delete();
                Assert.True(passed);
            }
        }

        /// <summary>
        ///     Tests that world is world
        /// </summary>
        [Fact]
        public void World_IsWorld()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create();
                Assert.Equal(scene, e.Scene);
            }
        }

        /// <summary>
        ///     Tests that add as adds as
        /// </summary>
        [Fact]
        public void AddAs_AddsAs()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create();
                e.AddAs(Component<BaseClass>.Id, new ChildClass());
                
                Assert.Equal(typeof(ChildClass), e.Get<BaseClass>().GetType());
                Assert.Throws<InvalidCastException>(() => e.AddAs(Component<ChildClass>.Id, new BaseClass()));
            }
        }

        /// <summary>
        ///     Tests that add default type
        /// </summary>
        [Fact]
        public void Add_DefaultType()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create();
                e.Add<int>(0);
                Assert.True(e.Has<int>());
                Assert.Equal(0, e.Get<int>());
            }
        }

        /// <summary>
        ///     Tests that add as type adds as type
        /// </summary>
        [Fact]
        public void AddAsType_AddsAsType()
        {
            Component.RegisterComponent<BaseClass>();
            Component.RegisterComponent<ChildClass>();
            Component.RegisterComponent<Class1>();

            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create();
                e.Add(typeof(ChildClass), new ChildClass());

                Assert.Equal(typeof(ChildClass), e.Get<ChildClass>().GetType());
                Assert.Throws<InvalidCastException>(() => e.AddAs(typeof(Class1), new Class2()));
            }
        }

        /// <summary>
        ///     Tests that delete no longer is alive
        /// </summary>
        [Fact]
        public void Delete_NoLongerIsAlive()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(), new Struct2(), new Struct3());

                Assert.True(e.IsAlive);
                e.Delete();
                Assert.False(e.IsAlive);
            }
        }
        
        /// <summary>
        ///     Tests that enumerate components iterates all components
        /// </summary>
        [Fact]
        public void EnumerateComponents_IteratesAllComponents()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(), new Struct2(), new Struct3());

                List<Type> types = new List<Type>();
                e.EnumerateComponents(new GenericAction((t, o) => types.Add(t)));

                Assert.Equal(new[] {typeof(Struct1), typeof(Struct2), typeof(Struct3)}, types);
                Assert.Equal(e.ComponentTypes.Select(t => t.Type), types);
            }
        }

        /// <summary>
        ///     Tests that get generic returns reference
        /// </summary>
        [Fact]
        public void GetGeneric_ReturnsReference()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(10, new Struct1(), new Struct2(), new Class1());

                Assert.Equal(10, e.Get<int>());

                e.Get<int>() = 20;

                Assert.Equal(20, e.Get<int>());
            }
        }

        /// <summary>
        ///     Tests that get returns component
        /// </summary>
        [Fact]
        public void Get_ReturnsComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(10, new Struct1(), new Struct2(), new Class1());

                Assert.Equal(10, e.Get(typeof(int)));
                Assert.Equal(10, e.Get(Component<int>.Id));
            }
        }

        /// <summary>
        ///     Tests that has returns true if has component
        /// </summary>
        [Fact]
        public void Has_ReturnsTrueIfHasComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(10, new Struct1(), new Struct2(), new Class1());

                Assert.True(e.Has(typeof(int)));
                Assert.True(e.Has(Component<int>.Id));

                Assert.False(e.Has(typeof(double)));
                Assert.False(e.Has(Component<double>.Id));

                Assert.True(e.Has<Struct1>());
                Assert.True(e.Has<Struct2>());
                Assert.True(e.Has<Class1>());
            }
        }

        /// <summary>
        ///     Tests that remove removes component
        /// </summary>
        [Fact]
        public void Remove_RemovesComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(), new Struct2(), new Struct3());

                e.Remove<Struct1>();
                e.Remove(Component<Struct2>.Id);

                Assert.Equal(1, e.ComponentTypes.Length);
            }
        }

        /// <summary>
        ///     Tests that remove many retain value
        /// </summary>
        [Fact]
        public void RemoveMany_RetainValue()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(69, 42.0, new Struct1(), new Struct2(), new Struct3());

                e.Remove<int, Struct1, Struct2, Struct3>();

                Assert.Equal(42.0, e.Get<double>());
                Assert.Equal(1, e.ComponentTypes.Length);
            }
        }

        /// <summary>
        ///     Tests that set changes object value
        /// </summary>
        [Fact]
        public void Set_ChangesObjectValue()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(-1, new Struct1(-2));

                Assert.Equal(-1, e.Get<int>());
                Assert.Equal(-2, e.Get<Struct1>().Value);

                e.Set(Component<int>.Id, 1);
                Assert.Equal(1, e.Get<int>());

                e.Set(typeof(Struct1), new Struct1(1));
                Assert.Equal(1, e.Get<Struct1>().Value);
            }
        }
        
        /// <summary>
        ///     Tests that try get returns false no component
        /// </summary>
        [Fact]
        public void TryGet_ReturnsFalseNoComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(1));

                Assert.False(e.TryGet(out Ref<int> value));
            }
        }

        /// <summary>
        ///     Tests that try get returns correct ref
        /// </summary>
        [Fact]
        public void TryGet_ReturnsCorrectRef()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(3));

                Assert.True(e.TryGet(out Ref<Struct1> value));
                Assert.Equal(3, value.Value.Value);
                value.Value.Value = 1;

                Assert.Equal(1, e.Get<Struct1>().Value);
            }
        }

        /// <summary>
        ///     Tests that try get doesnt throw
        /// </summary>
        [Fact]
        public void TryGet_DoesntThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(4));
                e.Delete();

                Assert.False(e.TryGet<Struct1>(out _));
            }
        }

        /// <summary>
        ///     Tests that try has doesnt throw
        /// </summary>
        [Fact]
        public void TryHas_DoesntThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(4));
                e.Delete();

                Assert.False(e.TryHas<Struct1>());
            }
        }

        /// <summary>
        ///     Tests that try has returns true
        /// </summary>
        [Fact]
        public void TryHas_ReturnsTrue()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create(new Struct1(4));

                Assert.True(e.TryHas<Struct1>());
            }
        }

        /// <summary>
        ///     The generic action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}" />
        /// <seealso cref="IGenericAction" />
        public class GenericAction : IGenericAction<GameObject>, IGenericAction
        {
            /// <summary>
            ///     The on action
            /// </summary>
            private readonly Action<Type, object> onAction;

            /// <summary>
            ///     Initializes a new instance of the <see cref="GenericAction" /> class
            /// </summary>
            /// <param name="onAction">The on action</param>
            public GenericAction(Action<Type, object> onAction) => this.onAction = onAction;

            /// <summary>
            ///     Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type) => onAction(typeof(T), type);

            /// <summary>
            ///     Invokes the e
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="e">The </param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject e, ref T type) => onAction(typeof(T), type);
        }
    }
}