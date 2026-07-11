using System;
using System.Reflection;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Scene
{
    public class SceneManagerLifecycleCoverageTest
    {
        static SceneManagerLifecycleCoverageTest() => EnsureEcsInitialized();

        private static void EnsureEcsInitialized()
        {
            Type globalWorldTables = Type.GetType("Alis.Core.Ecs.Kernel.Archetypes.GlobalWorldTables, Alis.Core.Ecs");
            if (globalWorldTables == null) return;

            FieldInfo tableField = globalWorldTables.GetField("ComponentTagLocationTable",
                BindingFlags.Public | BindingFlags.Static);
            if (tableField == null) return;

            byte[][] table = (byte[][])tableField.GetValue(null);
            if (table == null || table.Length < 64)
            {
                tableField.SetValue(null, new byte[64][]);
            }

            PropertyInfo bufferProp = globalWorldTables.GetProperty("ComponentTagTableBufferSize",
                BindingFlags.NonPublic | BindingFlags.Static);
            if (bufferProp != null && (int)(bufferProp.GetValue(null) ?? 0) < 64)
            {
                bufferProp.SetValue(null, 64);
            }
        }

        [Fact]
        public void OnInit_WithLoadedScene_SetsCurrentWorld()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);

            manager.OnInit();

            Assert.NotNull(manager.CurrentWorld);
        }

        [Fact]
        public void OnAwake_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnAwake();
        }

        [Fact]
        public void OnStart_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnStart();
        }

        [Fact]
        public void OnPhysicUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnPhysicUpdate();
        }

        [Fact]
        public void OnBeforeUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnBeforeUpdate();
        }

        [Fact]
        public void OnAfterUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnAfterUpdate();
        }

        [Fact]
        public void OnBeforeFixedUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnBeforeFixedUpdate();
        }

        [Fact]
        public void OnFixedUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnFixedUpdate();
        }

        [Fact]
        public void OnAfterFixedUpdate_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnAfterFixedUpdate();
        }

        [Fact]
        public void OnProcessPendingChanges_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnProcessPendingChanges();
        }

        [Fact]
        public void OnBeforeDraw_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnBeforeDraw();
        }

        [Fact]
        public void OnDraw_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnDraw();
        }

        [Fact]
        public void OnAfterDraw_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnAfterDraw();
        }

        [Fact]
        public void OnExit_WithScene_DoesNotThrow()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene);
            manager.CurrentWorld = scene;

            manager.OnExit();
        }

        [Fact]
        public void LoadScene_WithInt_ShouldSwitchCurrentWorld()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            Alis.Core.Ecs.Scene scene2 = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene1);
            manager.LoadedScenes.Add(scene2);
            manager.CurrentWorld = scene1;

            manager.LoadScene(1);

            Assert.Equal(scene2, manager.CurrentWorld);
        }

        [Fact]
        public void LoadScene_WithStringValidInt_ShouldCallLoadSceneWithInt()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            Alis.Core.Ecs.Scene scene2 = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene1);
            manager.LoadedScenes.Add(scene2);
            manager.CurrentWorld = scene1;

            manager.LoadScene("1");

            Assert.Equal(scene2, manager.CurrentWorld);
        }

        [Fact]
        public void LoadScene_WithStringInvalid_ShouldNotChangeCurrentWorld()
        {
            Context context = new Context();
            SceneManager manager = new SceneManager(context);
            Alis.Core.Ecs.Scene scene1 = new Alis.Core.Ecs.Scene();
            manager.LoadedScenes.Add(scene1);
            manager.CurrentWorld = scene1;

            manager.LoadScene("invalid");

            Assert.Equal(scene1, manager.CurrentWorld);
        }
    }
}
