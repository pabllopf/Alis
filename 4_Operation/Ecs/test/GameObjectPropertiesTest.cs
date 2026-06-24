// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectPropertiesTest.cs
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
    ///     Tests for the public properties of <see cref="GameObject" />:
    ///     <see cref="GameObject.IsAlive" />, <see cref="GameObject.IsNull" />,
    ///     <see cref="GameObject.Scene" />, <see cref="GameObject.ComponentTypes" />
    ///     and <see cref="GameObject.Type" />.
    /// </summary>
    public class GameObjectPropertiesTest
    {
        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     IsAlive returns true immediately after the entity is created.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsTrue_ForNewlyCreatedEntity()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

            Assert.True(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive returns false after the entity has been deleted.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsFalse_AfterDeletion()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 3, Y = 4});

            gameObject.Delete();

            Assert.False(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive returns false for the default (null) GameObject.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsFalse_ForDefaultGameObject()
        {
            GameObject gameObject = default(GameObject);

            Assert.False(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive returns false for <see cref="GameObject.Null" />.
        /// </summary>
        [Fact]
        public void IsAlive_ReturnsFalse_ForGameObjectNull()
        {
            GameObject gameObject = GameObject.Null;

            Assert.False(gameObject.IsAlive);
        }

        /// <summary>
        ///     IsAlive stays true as long as the entity has not been deleted,
        ///     even after adding and removing components.
        /// </summary>
        [Fact]
        public void IsAlive_RemainsTrue_AfterAddAndRemoveComponents()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 0, Y = 0});

            gameObject.Add(new Velocity {X = 1, Y = 1});
            gameObject.Remove<Velocity>();

            Assert.True(gameObject.IsAlive);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     IsNull returns true for the default-constructed GameObject.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsTrue_ForDefaultConstructor()
        {
            GameObject gameObject = new GameObject();

            Assert.True(gameObject.IsNull);
        }

        /// <summary>
        ///     IsNull returns true for <c>default(GameObject)</c>.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsTrue_ForDefaultKeyword()
        {
            GameObject gameObject = default(GameObject);

            Assert.True(gameObject.IsNull);
        }

        /// <summary>
        ///     IsNull returns true for <see cref="GameObject.Null" />.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsTrue_ForStaticNullProperty()
        {
            Assert.True(GameObject.Null.IsNull);
        }

        /// <summary>
        ///     IsNull returns false for a real entity created inside a scene.
        /// </summary>
        [Fact]
        public void IsNull_ReturnsFalse_ForCreatedEntity()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent {Value = 5});

            Assert.False(gameObject.IsNull);
        }

        /// <summary>
        ///     IsNull remains false after the entity is deleted (deletion does not
        ///     reset the packed value to zero).
        /// </summary>
        [Fact]
        public void IsNull_ReturnsFalse_EvenAfterDeletion()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new TestComponent {Value = 7});

            gameObject.Delete();

            Assert.False(gameObject.IsNull);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Scene returns the same scene instance that was used to create the entity.
        /// </summary>
        [Fact]
        public void Scene_ReturnsSameSceneInstance_ThatCreatedEntity()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 1, Y = 1});

            Assert.Equal(scene, gameObject.Scene);
        }

        /// <summary>
        ///     Scene throws <see cref="InvalidOperationException" /> for the null GameObject.
        /// </summary>
        [Fact]
        public void Scene_Throws_ForNullGameObject()
        {
            GameObject gameObject = GameObject.Null;

            Assert.Throws<InvalidOperationException>(() => { _ = gameObject.Scene; });
        }

        /// <summary>
        ///     Scene returns a non-null value for a live entity.
        /// </summary>
        [Fact]
        public void Scene_IsNotNull_ForLiveEntity()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Velocity {X = 2, Y = 3});

            Assert.NotNull(gameObject.Scene);
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     ComponentTypes contains exactly the single component type the entity was created with.
        /// </summary>
        [Fact]
        public void ComponentTypes_ContainsSingleComponentType_WhenCreatedWithOneComponent()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 10, Y = 20});

            FastImmutableArray<ComponentId> types = gameObject.ComponentTypes;

            Assert.Contains(Component<Position>.Id, types);
        }

        /// <summary>
        ///     ComponentTypes contains all component types when the entity was created with several.
        /// </summary>
        [Fact]
        public void ComponentTypes_ContainsAllComponentTypes_WhenCreatedWithMultiple()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position {X = 0, Y = 0},
                new Velocity {X = 1, Y = 1},
                new Health {Value = 100});

            FastImmutableArray<ComponentId> types = gameObject.ComponentTypes;

            Assert.Contains(Component<Position>.Id, types);
            Assert.Contains(Component<Velocity>.Id, types);
            Assert.Contains(Component<Health>.Id, types);
        }

        /// <summary>
        ///     ComponentTypes updates after a new component is added.
        /// </summary>
        [Fact]
        public void ComponentTypes_Updates_AfterComponentAdded()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 5, Y = 5});

            gameObject.Add(new Velocity {X = 1, Y = 1});

            Assert.Contains(Component<Velocity>.Id, gameObject.ComponentTypes);
        }

        /// <summary>
        ///     ComponentTypes no longer contains a removed component.
        /// </summary>
        [Fact]
        public void ComponentTypes_DoesNotContain_RemovedComponent()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4});

            gameObject.Remove<Velocity>();

            Assert.DoesNotContain(Component<Velocity>.Id, gameObject.ComponentTypes);
            Assert.Contains(Component<Position>.Id, gameObject.ComponentTypes);
        }

        /// <summary>
        ///     ComponentTypes throws for a dead (deleted) entity.
        /// </summary>
        [Fact]
        public void ComponentTypes_Throws_ForDeadEntity()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 1, Y = 1});
            gameObject.Delete();

            Assert.Throws<InvalidOperationException>(() => { _ = gameObject.ComponentTypes; });
        }

        // ─────────────────────────────────────────────────────────────────────

        /// <summary>
        ///     Type matches <see cref="GameObject.EntityTypeOf" /> for the same component set.
        /// </summary>
        [Fact]
        public void Type_MatchesEntityTypeOf_ForSameComponentSet()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 0, Y = 0});

            GameObjectType expected = GameObject.EntityTypeOf([Component<Position>.Id]);

            Assert.Equal(expected, gameObject.Type);
        }

        /// <summary>
        ///     Two entities with the same component set share the same <see cref="GameObjectType" />.
        /// </summary>
        [Fact]
        public void Type_IsSame_ForEntitiesWithIdenticalComponentSets()
        {
            using Scene scene = new Scene();
            GameObject a = scene.Create(new Velocity {X = 1, Y = 1});
            GameObject b = scene.Create(new Velocity {X = 2, Y = 2});

            Assert.Equal(a.Type, b.Type);
        }

        /// <summary>
        ///     Two entities with different component sets have different <see cref="GameObjectType" />s.
        /// </summary>
        [Fact]
        public void Type_IsDifferent_ForEntitiesWithDifferentComponentSets()
        {
            using Scene scene = new Scene();
            GameObject a = scene.Create(new Position {X = 1, Y = 1});
            GameObject b = scene.Create(new Velocity {X = 1, Y = 1});

            Assert.NotEqual(a.Type, b.Type);
        }

        /// <summary>
        ///     Type changes after a component is added.
        /// </summary>
        [Fact]
        public void Type_Changes_AfterComponentAdded()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(new Position {X = 0, Y = 0});
            GameObjectType typeBefore = gameObject.Type;

            gameObject.Add(new Velocity {X = 1, Y = 1});

            Assert.NotEqual(typeBefore, gameObject.Type);
        }

        /// <summary>
        ///     Type changes after a component is removed.
        /// </summary>
        [Fact]
        public void Type_Changes_AfterComponentRemoved()
        {
            using Scene scene = new Scene();
            GameObject gameObject = scene.Create(
                new Position {X = 0, Y = 0},
                new Velocity {X = 1, Y = 1});

            GameObjectType typeBefore = gameObject.Type;

            gameObject.Remove<Velocity>();

            Assert.NotEqual(typeBefore, gameObject.Type);
        }

    /// <summary>
    ///     Type throws for a dead (deleted) entity.
    /// </summary>
    [Fact]
    public void Type_Throws_ForDeadEntity()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 1});
        gameObject.Delete();

        Assert.Throws<InvalidOperationException>(() => { _ = gameObject.Type; });
    }

    /// <summary>
    ///     Has with type returns true when the component exists.
    /// </summary>
    [Fact]
    public void Has_WithType_ReturnsTrue_WhenComponentExists()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        Assert.True(gameObject.Has(typeof(Position)));
    }

    /// <summary>
    ///     Has with type returns false when the component does not exist.
    /// </summary>
    [Fact]
    public void Has_WithType_ReturnsFalse_WhenComponentDoesNotExist()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        Assert.False(gameObject.Has(typeof(Velocity)));
    }

    /// <summary>
    ///     TryHas returns true when the component exists.
    /// </summary>
    [Fact]
    public void TryHas_ReturnsTrue_WhenComponentExists()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        Assert.True(gameObject.TryHas<Position>());
    }

    /// <summary>
    ///     TryHas returns false for a dead entity without throwing.
    /// </summary>
    [Fact]
    public void TryHas_ReturnsFalse_ForDeadEntity()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});
        gameObject.Delete();

        Assert.False(gameObject.TryHas<Position>());
    }

    /// <summary>
    ///     TryHas with type returns true when the component exists.
    /// </summary>
    [Fact]
    public void TryHas_WithType_ReturnsTrue_WhenComponentExists()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        Assert.True(gameObject.TryHas(typeof(Position)));
    }

    /// <summary>
    ///     Get with component id returns a boxed component.
    /// </summary>
    [Fact]
    public void Get_WithComponentId_ReturnsBoxedComponent()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 5, Y = 10});

        object result = gameObject.Get(Component<Position>.Id);

        Position pos = Assert.IsType<Position>(result);
        Assert.Equal(5f, pos.X);
        Assert.Equal(10f, pos.Y);
    }

    /// <summary>
    ///     Get with type returns a boxed component.
    /// </summary>
    [Fact]
    public void Get_WithType_ReturnsBoxedComponent()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 3, Y = 7});

        object result = gameObject.Get(typeof(Position));

        Position pos = Assert.IsType<Position>(result);
        Assert.Equal(3f, pos.X);
        Assert.Equal(7f, pos.Y);
    }

    /// <summary>
    ///     Get with component id throws component not found exception when component does not exist.
    /// </summary>
    [Fact]
    public void Get_WithComponentId_ThrowsComponentNotFoundException_WhenComponentDoesNotExist()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        Assert.Throws<ComponentNotFoundException>(() => gameObject.Get(Component<Velocity>.Id));
    }

    /// <summary>
    ///     Set with component id updates the component value.
    /// </summary>
    [Fact]
    public void Set_WithComponentId_SetsComponentValue()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        gameObject.Set(Component<Position>.Id, new Position {X = 10, Y = 20});

        object result = gameObject.Get(Component<Position>.Id);
        Position pos = Assert.IsType<Position>(result);
        Assert.Equal(10f, pos.X);
        Assert.Equal(20f, pos.Y);
    }

    /// <summary>
    ///     Set with type updates the component value.
    /// </summary>
    [Fact]
    public void Set_WithType_SetsComponentValue()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 5, Y = 5});

        gameObject.Set(typeof(Position), new Position {X = 99, Y = 100});

        ref Position pos = ref gameObject.Get<Position>();
        Assert.Equal(99f, pos.X);
        Assert.Equal(100f, pos.Y);
    }

    /// <summary>
    ///     Try get returns true when the component exists.
    /// </summary>
    [Fact]
    public void TryGet_ReturnsTrue_WhenComponentExists()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        bool result = gameObject.TryGet<Position>(out Ref<Position> value);

        Assert.True(result);
        Assert.Equal(1f, value.Value.X);
        Assert.Equal(2f, value.Value.Y);
    }

    /// <summary>
    ///     Try get returns false when the component does not exist.
    /// </summary>
    [Fact]
    public void TryGet_ReturnsFalse_WhenComponentDoesNotExist()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

        bool result = gameObject.TryGet<Velocity>(out Ref<Velocity> value);

        Assert.False(result);
    }

    /// <summary>
    ///     Try get returns false for a dead entity without throwing.
    /// </summary>
    [Fact]
    public void TryGet_ReturnsFalse_ForDeadEntity()
    {
        using Scene scene = new Scene();
        GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});
        gameObject.Delete();

        bool result = gameObject.TryGet<Position>(out Ref<Position> value);

        Assert.False(result);
    }
}
}