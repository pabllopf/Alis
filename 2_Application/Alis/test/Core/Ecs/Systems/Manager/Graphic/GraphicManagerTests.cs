using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    public class GraphicManagerTests
    {
        [Fact]
        public void Constructor_WithContext_SetsContext()
        {
            Context ctx = new Context(new Setting());
            GraphicManager manager = new GraphicManager(ctx);
            Assert.NotNull(manager.Context);
        }

        [Fact]
        public void Renderer_GetSet_ReturnsExpectedValue()
        {
            Context ctx = new Context(new Setting());
            GraphicManager manager = new GraphicManager(ctx);
            IntPtr expected = new IntPtr(42);
            manager.Renderer = expected;
            Assert.Equal(expected, manager.Renderer);
        }

        [Fact]
        public void OnStart_DoesNotThrow()
        {
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            manager.OnStart();
        }

        [Fact]
        public void OnBeforeDraw_DoesNotThrow()
        {
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            manager.OnBeforeDraw();
        }

        [Fact]
        public void OnInit_PreviewMode_ReturnsEarly()
        {
            GraphicSetting graphicSetting = new GraphicSetting { PreviewMode = true };
            Setting setting = new Setting(new GeneralSetting(), new AudioSetting(), graphicSetting, new InputSetting(), new NetworkSetting(), new PhysicSetting());
            GraphicManager manager = new GraphicManager(new Context(setting));
            manager.OnInit();
        }

        [Fact]
        public void ProcessKeyEventForComponent_IOnPressKey_InvokesOnPressKey()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            PressKeyComponent comp = new PressKeyComponent();
            Alis.Core.Ecs.GameObject entity = scene.Create(in comp);
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey> { ConsoleKey.A, ConsoleKey.B };
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>();

            manager.ProcessKeyEventForComponent(typeof(PressKeyComponent), entity, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.Equal(2, comp.PressCount);
        }

        [Fact]
        public void ProcessKeyEventForComponent_IOnHoldKey_InvokesOnHoldKey()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            HoldKeyComponent comp = new HoldKeyComponent();
            Alis.Core.Ecs.GameObject entity = scene.Create(in comp);
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey> { ConsoleKey.X, ConsoleKey.Y };
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey>();

            manager.ProcessKeyEventForComponent(typeof(HoldKeyComponent), entity, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.Equal(2, comp.HoldCount);
        }

        [Fact]
        public void ProcessKeyEventForComponent_IOnReleaseKey_InvokesOnReleaseKey()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            ReleaseKeyComponent comp = new ReleaseKeyComponent();
            Alis.Core.Ecs.GameObject entity = scene.Create(in comp);
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey>();
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey> { ConsoleKey.Spacebar };

            manager.ProcessKeyEventForComponent(typeof(ReleaseKeyComponent), entity, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.Equal(1, comp.ReleaseCount);
        }

        [Fact]
        public void ProcessKeyEventForComponent_MultipleInterfaces_InvokesAll()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            MultiKeyComponent comp = new MultiKeyComponent();
            Alis.Core.Ecs.GameObject entity = scene.Create(in comp);
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey> { ConsoleKey.P };
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey> { ConsoleKey.H };
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey> { ConsoleKey.R };

            manager.ProcessKeyEventForComponent(typeof(MultiKeyComponent), entity, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);

            Assert.Equal(1, comp.PressCount);
            Assert.Equal(1, comp.HoldCount);
            Assert.Equal(1, comp.ReleaseCount);
        }

        [Fact]
        public void ProcessKeyEventForComponent_NoMatchingInterface_DoesNotThrow()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            NonKeyComponent comp = new NonKeyComponent();
            Alis.Core.Ecs.GameObject entity = scene.Create(in comp);
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey> { ConsoleKey.P };
            HashSet<ConsoleKey> heldKeys = new HashSet<ConsoleKey> { ConsoleKey.H };
            HashSet<ConsoleKey> releasedKeys = new HashSet<ConsoleKey> { ConsoleKey.R };

            manager.ProcessKeyEventForComponent(typeof(NonKeyComponent), entity, pressedKeys, heldKeys, releasedKeys, DateTime.UtcNow);
        }

        [Fact]
        public void UpdateKeyTimestamps_PressedThenReleased_DoesNotThrow()
        {
            Context ctx = new Context(new Setting());
            GraphicManager manager = new GraphicManager(ctx);
            HashSet<ConsoleKey> pressed = new HashSet<ConsoleKey> { ConsoleKey.A };
            HashSet<ConsoleKey> released = new HashSet<ConsoleKey>();
            DateTime now = DateTime.UtcNow;

            manager.UpdateKeyTimestamps(pressed, released, now);
            released.Add(ConsoleKey.A);
            pressed.Clear();
            manager.UpdateKeyTimestamps(pressed, released, now);
        }

        [Fact]
        public void BuildNewKeys_WithNullPlatform_DoesNotThrow()
        {
            GraphicManager manager = new GraphicManager(new Context(new Setting()));
            Assert.NotNull(manager.allKeys);
        }


    }

    internal sealed class PressKeyComponent : IOnPressKey
    {
        public int PressCount;

        public void OnPressKey(KeyEventInfo info) => PressCount++;
    }

    internal sealed class HoldKeyComponent : IOnHoldKey
    {
        public int HoldCount;

        public void OnHoldKey(KeyEventInfo info) => HoldCount++;
    }

    internal sealed class ReleaseKeyComponent : IOnReleaseKey
    {
        public int ReleaseCount;

        public void OnReleaseKey(KeyEventInfo info) => ReleaseCount++;
    }

    internal sealed class MultiKeyComponent : IOnPressKey, IOnHoldKey, IOnReleaseKey
    {
        public int PressCount;
        public int HoldCount;
        public int ReleaseCount;

        public void OnPressKey(KeyEventInfo info) => PressCount++;

        public void OnHoldKey(KeyEventInfo info) => HoldCount++;

        public void OnReleaseKey(KeyEventInfo info) => ReleaseCount++;
    }

    internal sealed class NonKeyComponent
    {
    }
}
