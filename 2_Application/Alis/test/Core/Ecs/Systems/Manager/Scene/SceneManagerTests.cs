// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManagerTests.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Components.Body;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Scene
{
    public class SceneManagerTests
    {
        internal static int OnAwakeCallCount;
        internal static int OnStartCallCount;
        internal static int OnPhysicUpdateCallCount;
        internal static int OnBeforeUpdateCallCount;
        internal static int OnAfterUpdateCallCount;
        internal static int OnBeforeFixedUpdateCallCount;
        internal static int OnFixedUpdateCallCount;
        internal static int OnAfterFixedUpdateCallCount;
        internal static int OnProcessPendingChangesCallCount;
        internal static int OnBeforeDrawCallCount;
        internal static int OnDrawCallCount;
        internal static int OnAfterDrawCallCount;
        internal static int OnExitCallCount;
        internal static Context AssignedContext;

        private struct TestHasContextComponent : IHasContext<Context>
        {
            public Context Context { get => null; set => AssignedContext = value; }
        }

        private struct TestOnAwakeComponent : IOnAwake
        {
            public void OnAwake(IGameObject self) => OnAwakeCallCount++;
        }

        private struct TestOnStartComponent : IOnStart
        {
            public void OnStart(IGameObject self) => OnStartCallCount++;
        }

        private struct TestOnPhysicUpdateComponent : IOnPhysicUpdate
        {
            public void OnPhysicUpdate(IGameObject self) => OnPhysicUpdateCallCount++;
        }

        private struct TestOnBeforeUpdateComponent : IOnBeforeUpdate
        {
            public void OnBeforeUpdate(IGameObject self) => OnBeforeUpdateCallCount++;
        }

        private struct TestOnAfterUpdateComponent : IOnAfterUpdate
        {
            public void OnAfterUpdate(IGameObject self) => OnAfterUpdateCallCount++;
        }

        private struct TestOnBeforeFixedUpdateComponent : IOnBeforeFixedUpdate
        {
            public void OnBeforeFixedUpdate(IGameObject self) => OnBeforeFixedUpdateCallCount++;
        }

        private struct TestOnFixedUpdateComponent : IOnFixedUpdate
        {
            public void OnFixedUpdate(IGameObject self) => OnFixedUpdateCallCount++;
        }

        private struct TestOnAfterFixedUpdateComponent : IOnAfterFixedUpdate
        {
            public void OnAfterFixedUpdate(IGameObject self) => OnAfterFixedUpdateCallCount++;
        }

        private struct TestOnProcessPendingChangesComponent : IOnProcessPendingChanges
        {
            public void OnProcessPendingChanges(IGameObject self) => OnProcessPendingChangesCallCount++;
        }

        private struct TestOnBeforeDrawComponent : IOnBeforeDraw
        {
            public void OnBeforeDraw(IGameObject self) => OnBeforeDrawCallCount++;
        }

        private struct TestOnDrawComponent : IOnDraw
        {
            public void OnDraw(IGameObject self) => OnDrawCallCount++;
        }

        private struct TestOnAfterDrawComponent : IOnAfterDraw
        {
            public void OnAfterDraw(IGameObject self) => OnAfterDrawCallCount++;
        }

        private struct TestOnExitComponent : IOnExit
        {
            public void OnExit(IGameObject self) => OnExitCallCount++;
        }

        [Fact]
        public void OnInit_WithLoadedScene_SetsCurrentWorldToFirstScene()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);

            manager.OnInit();

            Assert.Equal(scene, manager.CurrentWorld);
        }

        [Fact]
        public void OnInit_WithEntitiesHavingHasContext_AssignsContext()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestHasContextComponent());
            AssignedContext = null;

            manager.OnInit();

            Assert.NotNull(AssignedContext);
            Assert.Equal(context, AssignedContext);
        }

        [Fact]
        public void OnAwake_WithMatchingComponent_CallsOnAwake()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnAwakeComponent());
            OnAwakeCallCount = 0;

            manager.OnAwake();

            Assert.Equal(1, OnAwakeCallCount);
        }

        [Fact]
        public void OnStart_WithMatchingComponent_CallsOnStart()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnStartComponent());
            OnStartCallCount = 0;

            manager.OnStart();

            Assert.Equal(1, OnStartCallCount);
        }

        [Fact]
        public void OnPhysicUpdate_WithMatchingComponent_CallsOnPhysicUpdate()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnPhysicUpdateComponent());
            OnPhysicUpdateCallCount = 0;

            manager.OnPhysicUpdate();

            Assert.Equal(1, OnPhysicUpdateCallCount);
        }

        [Fact]
        public void OnBeforeUpdate_WithMatchingComponent_CallsOnBeforeUpdate()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnBeforeUpdateComponent());
            OnBeforeUpdateCallCount = 0;

            manager.OnBeforeUpdate();

            Assert.Equal(1, OnBeforeUpdateCallCount);
        }

        [Fact]
        public void OnAfterUpdate_WithMatchingComponent_CallsOnAfterUpdate()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnAfterUpdateComponent());
            OnAfterUpdateCallCount = 0;

            manager.OnAfterUpdate();

            Assert.Equal(1, OnAfterUpdateCallCount);
        }

        [Fact]
        public void OnBeforeFixedUpdate_WithMatchingComponent_CallsOnBeforeFixedUpdate()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnBeforeFixedUpdateComponent());
            OnBeforeFixedUpdateCallCount = 0;

            manager.OnBeforeFixedUpdate();

            Assert.Equal(1, OnBeforeFixedUpdateCallCount);
        }

        [Fact]
        public void OnFixedUpdate_WithMatchingComponent_CallsOnFixedUpdate()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnFixedUpdateComponent());
            OnFixedUpdateCallCount = 0;

            manager.OnFixedUpdate();

            Assert.Equal(1, OnFixedUpdateCallCount);
        }

        [Fact]
        public void OnAfterFixedUpdate_WithMatchingComponent_CallsOnAfterFixedUpdate()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnAfterFixedUpdateComponent());
            OnAfterFixedUpdateCallCount = 0;

            manager.OnAfterFixedUpdate();

            Assert.Equal(1, OnAfterFixedUpdateCallCount);
        }

        [Fact]
        public void OnProcessPendingChanges_WithMatchingComponent_CallsOnProcessPendingChanges()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnProcessPendingChangesComponent());
            OnProcessPendingChangesCallCount = 0;

            manager.OnProcessPendingChanges();

            Assert.Equal(1, OnProcessPendingChangesCallCount);
        }

        [Fact]
        public void OnBeforeDraw_WithMatchingComponent_CallsOnBeforeDraw()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnBeforeDrawComponent());
            OnBeforeDrawCallCount = 0;

            manager.OnBeforeDraw();

            Assert.Equal(1, OnBeforeDrawCallCount);
        }

        [Fact]
        public void OnDraw_WithMatchingComponent_CallsOnDraw()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnDrawComponent());
            OnDrawCallCount = 0;

            manager.OnDraw();

            Assert.Equal(1, OnDrawCallCount);
        }

        [Fact]
        public void OnAfterDraw_WithMatchingComponent_CallsOnAfterDraw()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnAfterDrawComponent());
            OnAfterDrawCallCount = 0;

            manager.OnAfterDraw();

            Assert.Equal(1, OnAfterDrawCallCount);
        }

        [Fact]
        public void OnExit_WithMatchingComponent_CallsOnExit()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new TestOnExitComponent());
            OnExitCallCount = 0;

            manager.OnExit();

            Assert.Equal(1, OnExitCallCount);
        }

        [Fact]
        public void LoadScene_ByIndex_AssignsContextAndCallsOnStart()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene0 = new Alis.Core.Ecs.Scene();
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene0);
            manager.LoadedScenes.Add(scene1);
            manager.CurrentWorld = scene0;
            scene1.Create(new TestHasContextComponent());
            scene1.Create(new TestOnStartComponent());
            AssignedContext = null;
            OnStartCallCount = 0;

            manager.LoadScene(1);

            Assert.Equal(scene1, manager.CurrentWorld);
            Assert.NotNull(AssignedContext);
            Assert.Equal(context, AssignedContext);
            Assert.Equal(1, OnStartCallCount);
        }

        [Fact]
        public void LoadScene_ByStringValidIndex_SwitchesScene()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene0 = new Alis.Core.Ecs.Scene();
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene0);
            manager.LoadedScenes.Add(scene1);
            manager.CurrentWorld = scene0;

            manager.LoadScene("1");

            Assert.Equal(scene1, manager.CurrentWorld);
        }

        [Fact]
        public void LoadScene_WithNonMatchingComponent_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;
            scene.Create(new RigidBody());

            manager.LoadScene(0);
        }

        [Fact]
        public void OnUpdate_WithCurrentWorld_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.CurrentWorld = scene;

            manager.OnUpdate();
        }

        [Fact]
        public void OnInit_NoLoadedScenes_ThrowsNullReference()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);

            Assert.Throws<System.NullReferenceException>(() => manager.OnInit());
        }
    }
}
