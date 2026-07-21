using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    public class SceneManagerEntityTest
    {
        private static int _counter;

        private struct ContextComponent : IHasContext<Context>
        {
            public Context Context { get; set; }
        }

        private struct AwakeComponent : IOnAwake
        {
            public void OnAwake(IGameObject self) => _counter++;
        }

        private struct StartComponent : IOnStart
        {
            public void OnStart(IGameObject self) => _counter++;
        }

        private struct BeforeUpdateComponent : IOnBeforeUpdate
        {
            public void OnBeforeUpdate(IGameObject self) => _counter++;
        }

        private struct AfterUpdateComponent : IOnAfterUpdate
        {
            public void OnAfterUpdate(IGameObject self) => _counter++;
        }

        private struct BeforeFixedUpdateComponent : IOnBeforeFixedUpdate
        {
            public void OnBeforeFixedUpdate(IGameObject self) => _counter++;
        }

        private struct FixedUpdateComponent : IOnFixedUpdate
        {
            public void OnFixedUpdate(IGameObject self) => _counter++;
        }

        private struct AfterFixedUpdateComponent : IOnAfterFixedUpdate
        {
            public void OnAfterFixedUpdate(IGameObject self) => _counter++;
        }

        private struct PhysicUpdateComponent : IOnPhysicUpdate
        {
            public void OnPhysicUpdate(IGameObject self) => _counter++;
        }

        private struct ProcessPendingChangesComponent : IOnProcessPendingChanges
        {
            public void OnProcessPendingChanges(IGameObject self) => _counter++;
        }

        private struct BeforeDrawComponent : IOnBeforeDraw
        {
            public void OnBeforeDraw(IGameObject self) => _counter++;
        }

        private struct DrawComponent : IOnDraw
        {
            public void OnDraw(IGameObject self) => _counter++;
        }

        private struct AfterDrawComponent : IOnAfterDraw
        {
            public void OnAfterDraw(IGameObject self) => _counter++;
        }

        private struct ExitComponent : IOnExit
        {
            public void OnExit(IGameObject self) => _counter++;
        }

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

        [Fact]
        public void OnAwake_WithEntity_CallsOnAwake()
        {
            SceneManager manager = CreateManagerWithEntity<AwakeComponent>(out _, out _);
            manager.OnAwake();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnStart_WithEntity_CallsOnStart()
        {
            SceneManager manager = CreateManagerWithEntity<StartComponent>(out _, out _);
            manager.OnStart();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnBeforeUpdate_WithEntity_CallsOnBeforeUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<BeforeUpdateComponent>(out _, out _);
            manager.OnBeforeUpdate();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnAfterUpdate_WithEntity_CallsOnAfterUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<AfterUpdateComponent>(out _, out _);
            manager.OnAfterUpdate();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnBeforeFixedUpdate_WithEntity_CallsOnBeforeFixedUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<BeforeFixedUpdateComponent>(out _, out _);
            manager.OnBeforeFixedUpdate();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnFixedUpdate_WithEntity_CallsOnFixedUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<FixedUpdateComponent>(out _, out _);
            manager.OnFixedUpdate();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnAfterFixedUpdate_WithEntity_CallsOnAfterFixedUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<AfterFixedUpdateComponent>(out _, out _);
            manager.OnAfterFixedUpdate();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnPhysicUpdate_WithEntity_CallsOnPhysicUpdate()
        {
            SceneManager manager = CreateManagerWithEntity<PhysicUpdateComponent>(out _, out _);
            manager.OnPhysicUpdate();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnProcessPendingChanges_WithEntity_CallsOnProcessPendingChanges()
        {
            SceneManager manager = CreateManagerWithEntity<ProcessPendingChangesComponent>(out _, out _);
            manager.OnProcessPendingChanges();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnBeforeDraw_WithEntity_CallsOnBeforeDraw()
        {
            SceneManager manager = CreateManagerWithEntity<BeforeDrawComponent>(out _, out _);
            manager.OnBeforeDraw();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnDraw_WithEntity_CallsOnDraw()
        {
            SceneManager manager = CreateManagerWithEntity<DrawComponent>(out _, out _);
            manager.OnDraw();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnAfterDraw_WithEntity_CallsOnAfterDraw()
        {
            SceneManager manager = CreateManagerWithEntity<AfterDrawComponent>(out _, out _);
            manager.OnAfterDraw();
            Assert.Equal(1, _counter);
        }

        [Fact]
        public void OnExit_WithEntity_CallsOnExit()
        {
            SceneManager manager = CreateManagerWithEntity<ExitComponent>(out _, out _);
            manager.OnExit();
            Assert.Equal(1, _counter);
        }

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
