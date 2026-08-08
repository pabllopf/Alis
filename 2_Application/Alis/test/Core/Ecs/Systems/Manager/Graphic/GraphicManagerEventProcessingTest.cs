using System;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    /// The graphic manager event processing test class
    /// </summary>
    public class GraphicManagerEventProcessingTest
    {
        /// <summary>
        /// Creates the game object with component using the specified component
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="component">The component</param>
        /// <returns>The go</returns>
        private static GameObject CreateGameObjectWithComponent<T>(T component) where T : class
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            GameObject go = scene.Create();
            go.Add(component);
            return go;
        }

        /// <summary>
        /// Tests that on start does not throw
        /// </summary>
        [Fact]
        public void OnStart_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            manager.OnStart();
        }

        /// <summary>
        /// Tests that on before draw does not throw
        /// </summary>
        [Fact]
        public void OnBeforeDraw_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            manager.OnBeforeDraw();
        }

        /// <summary>
        /// Tests that on draw with preview mode throws exception
        /// </summary>
        [Fact]
        public void OnDraw_WithPreviewMode_ThrowsException()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            GraphicManager manager = new GraphicManager(context);

            Assert.ThrowsAny<Exception>(() => manager.OnDraw());
        }

        /// <summary>
        /// Tests that render preview without scene throws exception
        /// </summary>
        [Fact]
        public void RenderPreview_WithoutScene_ThrowsException()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            GraphicManager manager = new GraphicManager(context);

            Assert.ThrowsAny<Exception>(() =>
            {
                MethodInfo method = typeof(GraphicManager).GetMethod("RenderPreview",
                    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                method.Invoke(manager, null);
            });
        }

        /// <summary>
        /// Tests that on init with preview mode does not throw
        /// </summary>
        [Fact]
        public void OnInit_WithPreviewMode_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            GraphicManager manager = new GraphicManager(context);

            manager.OnInit();
        }

        /// <summary>
        /// Tests that process key event for component with on press key calls on press key
        /// </summary>
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

        /// <summary>
        /// Tests that process key event for component with on hold key calls on hold key
        /// </summary>
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

        /// <summary>
        /// Tests that process key event for component with on release key calls on release key
        /// </summary>
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

    /// <summary>
    /// The test press key component class
    /// </summary>
    /// <seealso cref="IOnPressKey"/>
    public class TestPressKeyComponent : IOnPressKey
    {
        /// <summary>
        /// Gets or sets the value of the on press key action
        /// </summary>
        public Action<KeyEventInfo> OnPressKeyAction { get; set; }
        /// <summary>
        /// Ons the press key using the specified key event info
        /// </summary>
        /// <param name="keyEventInfo">The key event info</param>
        public void OnPressKey(KeyEventInfo keyEventInfo) => OnPressKeyAction(keyEventInfo);
    }

    /// <summary>
    /// The test hold key component class
    /// </summary>
    /// <seealso cref="IOnHoldKey"/>
    public class TestHoldKeyComponent : IOnHoldKey
    {
        /// <summary>
        /// Gets or sets the value of the on hold key action
        /// </summary>
        public Action<KeyEventInfo> OnHoldKeyAction { get; set; }
        /// <summary>
        /// Ons the hold key using the specified key event info
        /// </summary>
        /// <param name="keyEventInfo">The key event info</param>
        public void OnHoldKey(KeyEventInfo keyEventInfo) => OnHoldKeyAction(keyEventInfo);
    }

    /// <summary>
    /// The test release key component class
    /// </summary>
    /// <seealso cref="IOnReleaseKey"/>
    public class TestReleaseKeyComponent : IOnReleaseKey
    {
        /// <summary>
        /// Gets or sets the value of the on release key action
        /// </summary>
        public Action<KeyEventInfo> OnReleaseKeyAction { get; set; }
        /// <summary>
        /// Ons the release key using the specified key event info
        /// </summary>
        /// <param name="keyEventInfo">The key event info</param>
        public void OnReleaseKey(KeyEventInfo keyEventInfo) => OnReleaseKeyAction(keyEventInfo);
    }
}
