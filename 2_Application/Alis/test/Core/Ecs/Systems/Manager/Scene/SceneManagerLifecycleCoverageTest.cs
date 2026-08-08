using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Scene
{
    /// <summary>
    /// The scene manager lifecycle coverage test class
    /// </summary>
    public class SceneManagerLifecycleCoverageTest
    {

        /// <summary>
        /// Tests that on init with loaded scene sets current world
        /// </summary>
        [Fact]
        public void OnInit_WithLoadedScene_SetsCurrentWorld()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);

            manager.OnInit();

            Assert.NotNull(manager.CurrentWorld);
        }

        /// <summary>
        /// Tests that on awake with scene does not throw
        /// </summary>
        [Fact]
        public void OnAwake_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnAwake();
        }

        /// <summary>
        /// Tests that on start with scene does not throw
        /// </summary>
        [Fact]
        public void OnStart_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnStart();
        }

        /// <summary>
        /// Tests that on physic update with scene does not throw
        /// </summary>
        [Fact]
        public void OnPhysicUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnPhysicUpdate();
        }

        /// <summary>
        /// Tests that on before update with scene does not throw
        /// </summary>
        [Fact]
        public void OnBeforeUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnBeforeUpdate();
        }

        /// <summary>
        /// Tests that on after update with scene does not throw
        /// </summary>
        [Fact]
        public void OnAfterUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnAfterUpdate();
        }

        /// <summary>
        /// Tests that on before fixed update with scene does not throw
        /// </summary>
        [Fact]
        public void OnBeforeFixedUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnBeforeFixedUpdate();
        }

        /// <summary>
        /// Tests that on fixed update with scene does not throw
        /// </summary>
        [Fact]
        public void OnFixedUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnFixedUpdate();
        }

        /// <summary>
        /// Tests that on after fixed update with scene does not throw
        /// </summary>
        [Fact]
        public void OnAfterFixedUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnAfterFixedUpdate();
        }

        /// <summary>
        /// Tests that on process pending changes with scene does not throw
        /// </summary>
        [Fact]
        public void OnProcessPendingChanges_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnProcessPendingChanges();
        }

        /// <summary>
        /// Tests that on before draw with scene does not throw
        /// </summary>
        [Fact]
        public void OnBeforeDraw_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnBeforeDraw();
        }

        /// <summary>
        /// Tests that on draw with scene does not throw
        /// </summary>
        [Fact]
        public void OnDraw_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnDraw();
        }

        /// <summary>
        /// Tests that on after draw with scene does not throw
        /// </summary>
        [Fact]
        public void OnAfterDraw_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnAfterDraw();
        }

        /// <summary>
        /// Tests that on exit with scene does not throw
        /// </summary>
        [Fact]
        public void OnExit_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene);
            manager.CurrentWorld = scene;

            manager.OnExit();
        }

        /// <summary>
        /// Tests that load scene with int should switch current world
        /// </summary>
        [Fact]
        public void LoadScene_WithInt_ShouldSwitchCurrentWorld()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            Alis.Core.Ecs.Scene scene2 = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene1);
            manager.AddScene(scene2);
            manager.CurrentWorld = scene1;

            manager.LoadScene(1);

            Assert.Equal(scene2, manager.CurrentWorld);
        }

        /// <summary>
        /// Tests that load scene with string valid int should call load scene with int
        /// </summary>
        [Fact]
        public void LoadScene_WithStringValidInt_ShouldCallLoadSceneWithInt()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            Alis.Core.Ecs.Scene scene2 = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene1);
            manager.AddScene(scene2);
            manager.CurrentWorld = scene1;

            manager.LoadScene("1");

            Assert.Equal(scene2, manager.CurrentWorld);
        }

        /// <summary>
        /// Tests that load scene with string invalid should not change current world
        /// </summary>
        [Fact]
        public void LoadScene_WithStringInvalid_ShouldNotChangeCurrentWorld()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            manager.AddScene(scene1);
            manager.CurrentWorld = scene1;

            manager.LoadScene("invalid");

            Assert.Equal(scene1, manager.CurrentWorld);
        }
    }
}
