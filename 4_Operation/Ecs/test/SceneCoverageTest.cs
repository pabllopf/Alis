// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneCoverageTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Coverage tests for untested public methods in <see cref="Scene" />.
    /// </summary>
    public class SceneCoverageTest
    {
        /// <summary>
        ///     Tests that EnterDisallowState prevents structural changes.
        /// </summary>
        [Fact]
        public void Scene_EnterDisallowState_ShouldDisallowStructuralChanges()
        {
            using Scene scene = new Scene();

            Assert.True(scene.AllowStructualChanges);

            scene.EnterDisallowState();

            Assert.False(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that ExitDisallowState with null filter restores structural changes.
        /// </summary>
        [Fact]
        public void Scene_ExitDisallowState_WithNullFilter_ShouldRestoreStructuralChanges()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            Assert.False(scene.AllowStructualChanges);

            scene.ExitDisallowState(null, false);

            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that UpdateArchetypeTable resizes the world archetype table.
        /// </summary>
        [Fact]
        public void Scene_UpdateArchetypeTable_ShouldResizeTable()
        {
            using Scene scene = new Scene();
            int originalSize = scene.WorldArchetypeTable.Length;
            int newSize = originalSize + 50;

            scene.UpdateArchetypeTable(newSize);

            Assert.Equal(newSize, scene.WorldArchetypeTable.Length);
        }

        /// <summary>
        ///     Tests that UpdateArchetypeTable with smaller size shrinks the table.
        /// </summary>
        [Fact]
        public void Scene_UpdateArchetypeTable_WithSmallerSize_ShouldShrinkTable()
        {
            using Scene scene = new Scene();
            int newSize = 10;

            scene.UpdateArchetypeTable(newSize);

            Assert.Equal(newSize, scene.WorldArchetypeTable.Length);
        }

        /// <summary>
        ///     Tests that Update with attribute type on empty scene does not throw.
        /// </summary>
        [Fact]
        public void Scene_UpdateGeneric_OnEmptyScene_DoesNotThrow()
        {
            using Scene scene = new Scene();

            scene.Update<SceneCoverageUpdateAttribute>();
        }

        /// <summary>
        ///     Tests that UpdateComponent with a component type on empty scene does not throw.
        /// </summary>
        [Fact]
        public void Scene_UpdateComponent_OnEmptyScene_DoesNotThrow()
        {
            using Scene scene = new Scene();
            ComponentId componentId = default;

            scene.UpdateComponent(componentId);
        }

        /// <summary>
        ///     Tests that EnterDisallowState can be called multiple times safely.
        /// </summary>
        [Fact]
        public void Scene_EnterDisallowState_MultipleCalls_ShouldStayDisallowed()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            scene.EnterDisallowState();
            scene.EnterDisallowState();

            Assert.False(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that matching EnterDisallowState and ExitDisallowState pairs work correctly.
        /// </summary>
        [Fact]
        public void Scene_DisallowState_PairedCalls_ShouldWorkCorrectly()
        {
            using Scene scene = new Scene();

            scene.EnterDisallowState();
            scene.ExitDisallowState(null, false);
            Assert.True(scene.AllowStructualChanges);

            scene.EnterDisallowState();
            scene.ExitDisallowState(null, false);
            Assert.True(scene.AllowStructualChanges);
        }

        /// <summary>
        ///     Tests that ComponentAdded event can be subscribed and unsubscribed.
        /// </summary>
        [Fact]
        public void Scene_ComponentAdded_Event_ShouldSupportSubscribeAndUnsubscribe()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            Action<GameObject, ComponentId> handler = (_, _) => callCount++;

            scene.ComponentAdded += handler;
            scene.ComponentAdded -= handler;

            Assert.Equal(0, callCount);
        }

        /// <summary>
        ///     Tests that ComponentRemoved event can be subscribed and unsubscribed.
        /// </summary>
        [Fact]
        public void Scene_ComponentRemoved_Event_ShouldSupportSubscribeAndUnsubscribe()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            Action<GameObject, ComponentId> handler = (_, _) => callCount++;

            scene.ComponentRemoved += handler;
            scene.ComponentRemoved -= handler;

            Assert.Equal(0, callCount);
        }

        /// <summary>
        ///     Tests that EntityDeleted event can be subscribed and unsubscribed.
        /// </summary>
        [Fact]
        public void Scene_EntityDeleted_Event_ShouldSupportSubscribeAndUnsubscribe()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            Action<GameObject> handler = _ => callCount++;

            scene.EntityDeleted += handler;
            scene.EntityDeleted -= handler;

            Assert.Equal(0, callCount);
        }

        /// <summary>
        ///     Tests that Update with Type on empty scene does not throw.
        /// </summary>
        [Fact]
        public void Scene_UpdateType_OnEmptyScene_DoesNotThrow()
        {
            using Scene scene = new Scene();

            scene.Update(typeof(SceneCoverageUpdateAttribute));
        }
    }

    /// <summary>
    ///     Attribute used to test Scene.Update&lt;T&gt;() where T : UpdateTypeAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    internal sealed class SceneCoverageUpdateAttribute : UpdateTypeAttribute;
}
