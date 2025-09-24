// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneTests.cs
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
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Helpers;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene tests class
    /// </summary>
    public class SceneTests
    {
        /// <summary>
        ///     Tests that ctor new id
        /// </summary>
        [Fact]
        public void Ctor_NewID()
        {
            using (Scene world1 = new Scene())
            {
                ushort id;
                using (Scene world2 = new Scene())
                {
                    Assert.NotEqual(world1.Id, id = world2.Id);
                }
            }
        }

        /// <summary>
        ///     Tests that create empty creates entity
        /// </summary>
        [Fact]
        public void CreateEmpty_CreatesEntity()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create();

                Assert.True(entity.IsAlive);
                Assert.Empty(entity.TagTypes);
                Assert.Empty(entity.ComponentTypes);
            }
        }

        /// <summary>
        ///     Tests that create from objects creates entity
        /// </summary>
        [Fact]
        public void CreateFromObjects_CreatesEntity()
        {
            Component.RegisterComponent<int>();
            Component.RegisterComponent<Class1>();
            Component.RegisterComponent<Struct1>();
            CreateEntityTest(w => w.CreateFromObjects(new object[] {6, new Class1(), new Struct1()}));
        }

        /// <summary>
        ///     Tests that create generic creates entity
        /// </summary>
        [Fact]
        public void CreateGeneric_CreatesEntity()
        {
            CreateEntityTest(w => w.Create(6, new Class1(), new Struct1()));
        }

        /// <summary>
        ///     Tests that custom query custom rule applies
        /// </summary>
        [Fact]
        public void CustomQuery_CustomRuleApplies()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.CustomQuery(Rule.Delegate(e => e.Types.Length == 3));

                scene.Create(1, new Class1(), new Struct1(1));
                scene.Create(1, new Class2(), new Struct2(1));
                scene.Create(1, new Class1());

                Assert.Equal(2, query.EntityCount());
                query.AssertEntitiesNotDefault();
            }
        }

        /// <summary>
        ///     Tests that custom query rule applies
        /// </summary>
        [Fact]
        public void CustomQuery_RuleApplies()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.CustomQuery(
                    Rule.HasComponent(Component<int>.Id),
                    Rule.HasComponent(Component<Class1>.Id),
                    Rule.HasComponent(Component<Struct1>.Id));

                scene.Create(1, new Class1(), new Struct1(1));
                scene.Create(1, new Class2(), new Struct2(1));
                scene.Create(1, new Class1());

                Assert.Equal(1, query.EntityCount());
                query.AssertEntitiesNotDefault();
            }
        }

        /// <summary>
        ///     Tests that custom query over empty archetype
        /// </summary>
        [Fact]
        public void CustomQuery_OverEmptyArchetype()
        {
            using (Scene scene = new Scene())
            {
                Query query = scene.CustomQuery(Rule.IncludeDisabledRule);

                scene.Create(1, new Class1(), new Struct1(1));
                scene.Create(1, new Class2(), new Struct2(1));
                scene.Create(1, new Class1());

                Assert.Equal(3, query.EntityCount());
                query.AssertEntitiesNotDefault();
            }
        }

        /// <summary>
        ///     Tests that query includes components
        /// </summary>
        [Fact]
        public void Query_IncludesComponents()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(1, new Class1(), new Struct1(1));
                scene.Create(1, new Class1(), new Struct1(1));
                scene.Create(1, new Class1(), new Struct1(1));

                scene.Create(1, new Class2(), new Struct2());

                Query query = scene.Query<With<int>, With<Class1>, With<Struct1>>();

                query.AssertEntitiesNotDefault();
                Assert.Equal(3, query.EntityCount());
            }
        }

        /// <summary>
        ///     Tests that component added invoked
        /// </summary>
        [Fact]
        public void ComponentAdded_Invoked()
        {
            using (Scene scene = new Scene())
            {
                bool invoked = false;
                scene.ComponentAdded += (e, c) => invoked = true;

                scene.Create().Add<Struct1>(default(Struct1));

                Assert.True(invoked);
            }
        }

        /// <summary>
        ///     Tests that component removed invoked
        /// </summary>
        [Fact]
        public void ComponentRemoved_Invoked()
        {
            using (Scene scene = new Scene())
            {
                bool invoked = false;
                scene.ComponentRemoved += (e, c) => invoked = true;

                scene.Create<Struct1>(default(Struct1)).Remove<Struct1>();

                Assert.True(invoked);
            }
        }

        /// <summary>
        ///     Tests that entity delete invoked
        /// </summary>
        [Fact]
        public void EntityDelete_Invoked()
        {
            using (Scene scene = new Scene())
            {
                bool invoked = false;
                scene.EntityDeleted += e => invoked = true;

                scene.Create().Delete();

                Assert.True(invoked);
            }
        }

        /// <summary>
        ///     Tests that entity created invoked
        /// </summary>
        [Fact]
        public void EntityCreated_Invoked()
        {
            using (Scene scene = new Scene())
            {
                bool invoked = false;
                scene.EntityCreated += e => invoked = true;

                scene.Create();

                Assert.True(invoked);
            }
        }

        /// <summary>
        ///     Tests that tag added invoked
        /// </summary>
        [Fact]
        public void TagAdded_Invoked()
        {
            using (Scene scene = new Scene())
            {
                scene.Create().Tag<Struct1>();

                scene.TagTagged += (e, t) => Assert.True(true);
            }
        }

        /// <summary>
        ///     Tests that tag removed invoked
        /// </summary>
        [Fact]
        public void TagRemoved_Invoked()
        {
            using (Scene scene = new Scene())
            {
                GameObject e = scene.Create();
                e.Tag<Struct1>();
                e.Detach<Struct1>();

                scene.TagDetached += (e, t) => Assert.True(true);
            }
        }
        
        /// <summary>
        ///     Tests that entity create during system acsess components
        /// </summary>
        [Fact]
        public void EntityCreate_DuringSystem_AcsessComponents()
        {
            using (Scene scene = new Scene())
            {
                foreach (GameObject entity in Enumerable.Range(0, 100).Select(i => scene.Create(i, (float) (i * 2))).ToArray().Where(c => c.Get<int>() % 2 == 0))
                {
                    entity.Delete();
                }

                List<GameObject> newEntities = new List<GameObject>();

                foreach (GameObject _ in scene.Query<With<int>, With<float>>().EnumerateWithEntities())
                {
                    GameObject e1 = scene.Create(42, 42f);
                    GameObject e2 = scene.Create(42);

                    Assert.Equal(42, e1.Get<int>());
                    Assert.Equal(42f, e1.Get<float>());
                    Assert.Equal(new[] {Component<int>.Id, Component<float>.Id}, e1.ComponentTypes);

                    Assert.Equal(42, e2.Get<int>());
                    Assert.Equal(new[] {Component<int>.Id}, e2.ComponentTypes);

                    newEntities.Add(e1);
                }

                Assert.All(newEntities, e => Assert.Equal(42, e.Get<int>()));
                Assert.All(newEntities, e => Assert.Equal(42f, e.Get<float>()));
            }
        }

        /// <summary>
        ///     Creates the entity test using the specified create
        /// </summary>
        /// <param name="create">The create</param>
        private static void CreateEntityTest(Func<Scene, GameObject> create)
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = create(scene);

                Assert.True(entity.IsAlive);
                Assert.Equal(3, entity.ComponentTypes.Length);
                Assert.Empty(entity.TagTypes);

                Assert.Contains(Component<int>.Id, entity.ComponentTypes);
                Assert.Contains(Component<Class1>.Id, entity.ComponentTypes);
                Assert.Contains(Component<Struct1>.Id, entity.ComponentTypes);

                Assert.Equal(6, entity.Get<int>());
            }
        }
    }
}