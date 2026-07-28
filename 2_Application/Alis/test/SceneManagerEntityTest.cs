using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The scene manager entity test class
    /// </summary>
    public class SceneManagerEntityTest
    {
        /// <summary>
        /// The counter
        /// </summary>
        private static int _counter;

        /// <summary>
        /// The context component
        /// </summary>
        private struct ContextComponent : IHasContext<Context>
        {
            /// <summary>
            /// Gets or sets the value of the context
            /// </summary>
            public Context Context { get; set; }
        }

        /// <summary>
        /// The awake component
        /// </summary>
        private struct AwakeComponent : IOnAwake
        {
            /// <summary>
            /// Ons the awake using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAwake(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The start component
        /// </summary>
        private struct StartComponent : IOnStart
        {
            /// <summary>
            /// Ons the start using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnStart(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The before update component
        /// </summary>
        private struct BeforeUpdateComponent : IOnBeforeUpdate
        {
            /// <summary>
            /// Ons the before update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnBeforeUpdate(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The after update component
        /// </summary>
        private struct AfterUpdateComponent : IOnAfterUpdate
        {
            /// <summary>
            /// Ons the after update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAfterUpdate(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The before fixed update component
        /// </summary>
        private struct BeforeFixedUpdateComponent : IOnBeforeFixedUpdate
        {
            /// <summary>
            /// Ons the before fixed update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnBeforeFixedUpdate(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The fixed update component
        /// </summary>
        private struct FixedUpdateComponent : IOnFixedUpdate
        {
            /// <summary>
            /// Ons the fixed update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnFixedUpdate(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The after fixed update component
        /// </summary>
        private struct AfterFixedUpdateComponent : IOnAfterFixedUpdate
        {
            /// <summary>
            /// Ons the after fixed update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAfterFixedUpdate(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The physic update component
        /// </summary>
        private struct PhysicUpdateComponent : IOnPhysicUpdate
        {
            /// <summary>
            /// Ons the physic update using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnPhysicUpdate(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The process pending changes component
        /// </summary>
        private struct ProcessPendingChangesComponent : IOnProcessPendingChanges
        {
            /// <summary>
            /// Ons the process pending changes using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnProcessPendingChanges(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The before draw component
        /// </summary>
        private struct BeforeDrawComponent : IOnBeforeDraw
        {
            /// <summary>
            /// Ons the before draw using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnBeforeDraw(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The draw component
        /// </summary>
        private struct DrawComponent : IOnDraw
        {
            /// <summary>
            /// Ons the draw using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnDraw(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The after draw component
        /// </summary>
        private struct AfterDrawComponent : IOnAfterDraw
        {
            /// <summary>
            /// Ons the after draw using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnAfterDraw(IGameObject self) => _counter++;
        }

        /// <summary>
        /// The exit component
        /// </summary>
        private struct ExitComponent : IOnExit
        {
            /// <summary>
            /// Ons the exit using the specified self
            /// </summary>
            /// <param name="self">The self</param>
            public void OnExit(IGameObject self) => _counter++;
        }

        /// <summary>
        /// Creates the manager with entity using the specified scene
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="scene">The scene</param>
        /// <param name="context">The context</param>
        /// <returns>The manager</returns>
        private static SceneManager CreateManagerWithEntity<T>(out Scene scene, out Context context) where T : struct
        {
            _counter = 0;
            context = new Context();
            scene = new Scene();
            Component.RegisterComponent<T>();
            scene.CreateFromObjects(new object[] { default(T) });

            SceneManager manager = new SceneManager(context);
            manager.AddScene(scene);
            manager.CurrentWorld = scene;
            return manager;
        }

        /// <summary>
        /// Tests that on init with context component sets context
        /// </summary>
        [Fact]
        public void OnInit_WithContextComponent_SetsContext()
        {
            _counter = 0;
            Context context = new Context();
            Scene scene = new Scene();
            Component.RegisterComponent<ContextComponent>();
            scene.CreateFromObjects(new object[] { new ContextComponent() });

            SceneManager manager = new SceneManager(context);
            manager.AddScene(scene);

            manager.OnInit();

            Assert.NotNull(manager.CurrentWorld);
        }

        /// <summary>
        /// Tests that on awake with entity calls on awake
        /// </summary>
        [Fact]
        public void OnAwake_WithEntity_CallsOnAwake()
        {
            SceneManager manager = CreateManagerWithEntity<AwakeComponent>(out _, out _);
            manager.OnAwake();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on start with entity calls on start
        /// </summary>
        [Fact]
        public void OnStart_WithEntity_CallsOnStart()
        {
            SceneManager manager = CreateManagerWithEntity<StartComponent>(out _, out _);
            manager.OnStart();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on before update with entity calls on before update
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_WithEntity_CallsOnBeforeUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<BeforeUpdateComponent>(out _, out _);
            manager.OnBeforeUpdate();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on after update with entity calls on after update
        /// </summary>
        [Fact]
        public void OnAfterUpdate_WithEntity_CallsOnAfterUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<AfterUpdateComponent>(out _, out _);
            manager.OnAfterUpdate();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on before fixed update with entity calls on before fixed update
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_WithEntity_CallsOnBeforeFixedUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<BeforeFixedUpdateComponent>(out _, out _);
            manager.OnBeforeFixedUpdate();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on fixed update with entity calls on fixed update
        /// </summary>
        [Fact]
        public void OnFixedUpdate_WithEntity_CallsOnFixedUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<FixedUpdateComponent>(out _, out _);
            manager.OnFixedUpdate();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on after fixed update with entity calls on after fixed update
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_WithEntity_CallsOnAfterFixedUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<AfterFixedUpdateComponent>(out _, out _);
            manager.OnAfterFixedUpdate();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on physic update with entity calls on physic update
        /// </summary>
        [Fact]
        public void OnPhysicUpdate_WithEntity_CallsOnPhysicUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<PhysicUpdateComponent>(out _, out _);
            manager.OnPhysicUpdate();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on process pending changes with entity calls on process pending changes
        /// </summary>
        [Fact]
        public void OnProcessPendingChanges_WithEntity_CallsOnProcessPendingChanges()
        {
            SceneManager manager = CreateManagerWithEntity<ProcessPendingChangesComponent>(out _, out _);
            manager.OnProcessPendingChanges();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on before draw with entity calls on before draw
        /// </summary>
        [Fact]
        public void OnBeforeDraw_WithEntity_CallsOnBeforeDraw()
        {
            SceneManager manager = CreateManagerWithEntity<BeforeDrawComponent>(out _, out _);
            manager.OnBeforeDraw();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on draw with entity calls on draw
        /// </summary>
        [Fact]
        public void OnDraw_WithEntity_CallsOnDraw()
        {
            SceneManager manager = CreateManagerWithEntity<DrawComponent>(out _, out _);
            manager.OnDraw();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on after draw with entity calls on after draw
        /// </summary>
        [Fact]
        public void OnAfterDraw_WithEntity_CallsOnAfterDraw()
        {
            SceneManager manager = CreateManagerWithEntity<AfterDrawComponent>(out _, out _);
            manager.OnAfterDraw();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that on exit with entity calls on exit
        /// </summary>
        [Fact]
        public void OnExit_WithEntity_CallsOnExit()
        {
            SceneManager manager = CreateManagerWithEntity<ExitComponent>(out _, out _);
            manager.OnExit();
            Assert.Equal(1, _counter);
        }

        /// <summary>
        /// Tests that load scene with int exits old scene and starts new scene
        /// </summary>
        [Fact]
        public void LoadScene_WithInt_ExitsOldSceneAndStartsNewScene()
        {
            _counter = 0;
            Context context = new Context();
            Scene oldScene = new Scene();
            Scene newScene = new Scene();
            Component.RegisterComponent<ExitComponent>();
            Component.RegisterComponent<StartComponent>();

            oldScene.CreateFromObjects(new object[] { new ExitComponent() });
            newScene.CreateFromObjects(new object[] { new StartComponent() });

            SceneManager manager = new SceneManager(context);
            manager.AddScene(oldScene);
            manager.AddScene(newScene);
            manager.CurrentWorld = oldScene;

            manager.LoadScene(1);

            Assert.Same(newScene, manager.CurrentWorld);
            Assert.Equal(2, _counter);
        }

        /// <summary>
        /// Tests that load scene with string valid int exits old scene and starts new scene
        /// </summary>
        [Fact]
        public void LoadScene_WithStringValidInt_ExitsOldSceneAndStartsNewScene()
        {
            _counter = 0;
            Context context = new Context();
            Scene oldScene = new Scene();
            Scene newScene = new Scene();
            Component.RegisterComponent<ExitComponent>();
            Component.RegisterComponent<StartComponent>();

            oldScene.CreateFromObjects(new object[] { new ExitComponent() });
            newScene.CreateFromObjects(new object[] { new StartComponent() });

            SceneManager manager = new SceneManager(context);
            manager.AddScene(oldScene);
            manager.AddScene(newScene);
            manager.CurrentWorld = oldScene;

            manager.LoadScene("1");

            Assert.Same(newScene, manager.CurrentWorld);
            Assert.Equal(2, _counter);
        }

        /// <summary>
        /// Tests that multiple entities all receive lifecycle call
        /// </summary>
        [Fact]
        public void MultipleEntities_AllReceiveLifecycleCall()
        {
            _counter = 0;
            Context context = new Context();
            Scene scene = new Scene();
            Component.RegisterComponent<AwakeComponent>();

            scene.CreateFromObjects(new object[] { new AwakeComponent() });
            scene.CreateFromObjects(new object[] { new AwakeComponent() });
            scene.CreateFromObjects(new object[] { new AwakeComponent() });

            SceneManager manager = new SceneManager(context);
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnAwake();

            Assert.Equal(3, _counter);
        }
    }
}
