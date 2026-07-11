using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    public class GraphicManagerEventProcessingTest
    {
        private static GameObject CreateGameObjectWithComponent<T>(T component) where T : class
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            GameObject go = scene.Create();
            go.Add(component);
            return go;
        }

        [Fact]
        public void OnStart_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            manager.OnStart();
        }

        [Fact]
        public void OnBeforeDraw_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            manager.OnBeforeDraw();
        }

        [Fact]
        public void OnDraw_WithPreviewMode_ThrowsException()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            context.SceneManager.LoadedScenes.Add(scene);
            context.SceneManager.CurrentWorld = scene;
            GraphicManager manager = new GraphicManager(context);

            Assert.ThrowsAny<Exception>(() => manager.OnDraw());
        }

        [Fact]
        public void RenderPreview_WithoutScene_ThrowsException()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            GraphicManager manager = new GraphicManager(context);

            Assert.ThrowsAny<Exception>(() =>
            {
                var method = typeof(GraphicManager).GetMethod("RenderPreview",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                method.Invoke(manager, null);
            });
        }

        [Fact]
        public void OnInit_WithPreviewMode_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            GraphicManager manager = new GraphicManager(context);

            manager.OnInit();
        }

        [Fact]
        public void ProcessKeyEventForComponent_WithOnPressKey_CallsOnPressKey()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);
            bool wasCalled = false;

            TestPressKeyComponent component = new TestPressKeyComponent();
            component.OnPressKeyAction = (info) => wasCalled = true;

            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>();

            GameObject go = CreateGameObjectWithComponent(component);

            manager.ProcessKeyEventForComponent(typeof(TestPressKeyComponent), go, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.True(wasCalled);
        }

        [Fact]
        public void ProcessKeyEventForComponent_WithOnHoldKey_CallsOnHoldKey()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);
            bool wasCalled = false;

            TestHoldKeyComponent component = new TestHoldKeyComponent();
            component.OnHoldKeyAction = (info) => wasCalled = true;

            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>();

            GameObject go = CreateGameObjectWithComponent(component);

            manager.ProcessKeyEventForComponent(typeof(TestHoldKeyComponent), go, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.True(wasCalled);
        }

        [Fact]
        public void ProcessKeyEventForComponent_WithOnReleaseKey_CallsOnReleaseKey()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);
            bool wasCalled = false;

            TestReleaseKeyComponent component = new TestReleaseKeyComponent();
            component.OnReleaseKeyAction = (info) => wasCalled = true;

            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey> { ConsoleKey.A };

            GameObject go = CreateGameObjectWithComponent(component);

            manager.ProcessKeyEventForComponent(typeof(TestReleaseKeyComponent), go, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.True(wasCalled);
        }
    }

    public class TestPressKeyComponent : IOnPressKey
    {
        public Action<KeyEventInfo> OnPressKeyAction { get; set; }
        public void OnPressKey(KeyEventInfo keyEventInfo) => OnPressKeyAction(keyEventInfo);
    }

    public class TestHoldKeyComponent : IOnHoldKey
    {
        public Action<KeyEventInfo> OnHoldKeyAction { get; set; }
        public void OnHoldKey(KeyEventInfo keyEventInfo) => OnHoldKeyAction(keyEventInfo);
    }

    public class TestReleaseKeyComponent : IOnReleaseKey
    {
        public Action<KeyEventInfo> OnReleaseKeyAction { get; set; }
        public void OnReleaseKey(KeyEventInfo keyEventInfo) => OnReleaseKeyAction(keyEventInfo);
    }
}
