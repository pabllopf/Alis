// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SettingsAndManagerComprehensiveTest.cs
// 
//  Author:Pablo Perdomo Falcon
//  Web:https://www.pabllopf.dev/
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Alis.Core.Ecs.Systems.Configuration.General;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Configuration.Input;
using Alis.Core.Ecs.Systems.Configuration.Network;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Comprehensive deterministic coverage for additional setting structs and AManager base behavior.
    /// </summary>
    public class SettingsAndManagerComprehensiveTest
    {
        [Fact]
        public void AudioSetting_DefaultConstructor_ShouldUseExpectedDefaults()
        {
            AudioSetting setting = new AudioSetting();

            Assert.Equal(100, setting.Volume);
            Assert.False(setting.Mute);
        }

        [Fact]
        public void AudioSetting_CustomConstructor_ShouldStoreProvidedValues()
        {
            AudioSetting setting = new AudioSetting(25, true);

            Assert.Equal(25, setting.Volume);
            Assert.True(setting.Mute);
        }

        [Fact]
        public void InputSetting_DefaultConstructor_ShouldUseExpectedDefaults()
        {
            InputSetting setting = new InputSetting();

            Assert.Equal(0.1f, setting.MouseSensitivity);
        }

        [Fact]
        public void InputSetting_CustomConstructor_ShouldStoreProvidedValues()
        {
            InputSetting setting = new InputSetting(1.75f);

            Assert.Equal(1.75f, setting.MouseSensitivity);
        }

        [Fact]
        public void GraphicSetting_DefaultConstructor_ShouldUseExpectedValues()
        {
            GraphicSetting setting = new GraphicSetting();

            Assert.Equal(60.0, setting.TargetFrames);
            Assert.Equal("OpenGL", setting.Target);
            Assert.False(setting.PreviewMode);
            Assert.False(setting.HasGrid);
            Assert.Equal(new Vector2F(800, 600), setting.WindowSize);
            Assert.True(setting.IsResizable);
        }

        [Fact]
        public void GraphicSetting_CustomConstructor_ShouldStoreProvidedValues()
        {
            GraphicSetting setting = new GraphicSetting(
                144.0,
                "Vulkan",
                true,
                Color.Green,
                true,
                Color.Black,
                new Vector2F(1920, 1080),
                false);

            Assert.Equal(144.0, setting.TargetFrames);
            Assert.Equal("Vulkan", setting.Target);
            Assert.True(setting.PreviewMode);
            Assert.True(setting.HasGrid);
            Assert.Equal(Color.Green, setting.GridColor);
            Assert.Equal(Color.Black, setting.BackgroundColor);
            Assert.Equal(new Vector2F(1920, 1080), setting.WindowSize);
            Assert.False(setting.IsResizable);
        }

        [Fact]
        public void PhysicSetting_DefaultConstructor_ShouldUseExpectedValues()
        {
            PhysicSetting setting = new PhysicSetting();

            Assert.Equal(new Vector2F(0, -9.81f), setting.Gravity);
            Assert.False(setting.Debug);
            Assert.Equal(new Color(0, 0, 0, 1), setting.DebugColor);
        }

        [Fact]
        public void PhysicSetting_CustomConstructor_ShouldStoreProvidedValues()
        {
            PhysicSetting setting = new PhysicSetting(new Vector2F(0, -1.0f), true, Color.Red);

            Assert.Equal(new Vector2F(0, -1.0f), setting.Gravity);
            Assert.True(setting.Debug);
            Assert.Equal(Color.Red, setting.DebugColor);
        }

        [Fact]
        public void SettingsStructs_ShouldImplementExpectedInterfaces()
        {
            Assert.IsAssignableFrom<IAudioSetting>(new AudioSetting());
            Assert.IsAssignableFrom<IInputSetting>(new InputSetting());
            Assert.IsAssignableFrom<IGraphicSetting>(new GraphicSetting());
            Assert.IsAssignableFrom<IPhysicSetting>(new PhysicSetting());
        }

        [Fact]
        public void SettingsStructs_ShouldUseSequentialStructLayoutWithPack1()
        {
            AssertStructLayout(typeof(AudioSetting));
            AssertStructLayout(typeof(InputSetting));
            AssertStructLayout(typeof(GraphicSetting));
            AssertStructLayout(typeof(PhysicSetting));
        }

        [Fact]
        public void Setting_DefaultConstructor_ShouldCreateNestedSettings()
        {
            Setting setting = new Setting();

            Assert.NotNull(setting.General);
            Assert.NotNull(setting.Audio);
            Assert.NotNull(setting.Graphic);
            Assert.NotNull(setting.Input);
            Assert.NotNull(setting.Network);
            Assert.NotNull(setting.Physic);

            Assert.Equal(100, setting.Audio.Volume);
            Assert.Equal("OpenGL", setting.Graphic.Target);
            Assert.Equal(8080, setting.Network.Port);
            Assert.Equal(new Vector2F(0, -9.81f), setting.Physic.Gravity);
        }

        [Fact]
        public void Setting_CustomConstructor_ShouldUseProvidedValues()
        {
            GeneralSetting general = new GeneralSetting(true, "Name", "Desc", "1.0", "Author", "MIT", "icon.png");
            AudioSetting audio = new AudioSetting(20, true);
            GraphicSetting graphic = new GraphicSetting(120, "OpenGL", false, Color.White, true, Color.Black, new Vector2F(1280, 720), true);
            InputSetting input = new InputSetting(0.5f);
            NetworkSetting network = new NetworkSetting(7777, "10.0.0.1", "host", "udp");
            PhysicSetting physic = new PhysicSetting(new Vector2F(1, 2), true, Color.Blue);

            Setting setting = new Setting(general, audio, graphic, input, network, physic);

            Assert.Equal(general.Name, setting.General.Name);
            Assert.Equal(20, setting.Audio.Volume);
            Assert.Equal(120, setting.Graphic.TargetFrames);
            Assert.Equal(0.5f, setting.Input.MouseSensitivity);
            Assert.Equal(7777, setting.Network.Port);
            Assert.Equal(new Vector2F(1, 2), setting.Physic.Gravity);
        }

        [Fact]
        public void AManager_DefaultProtectedConstructor_ShouldSetExpectedDefaults()
        {
            TestManager manager = new TestManager(null);

            Assert.True(manager.IsEnable);
            Assert.Equal("Manager", manager.Name);
            Assert.Equal("Untagged", manager.Tag);
            Assert.False(string.IsNullOrWhiteSpace(manager.Id));
            Assert.Null(manager.Context);
            Assert.IsAssignableFrom<IManager>(manager);
        }

        [Fact]
        public void AManager_ProtectedConstructorWithValues_ShouldStoreProvidedValues()
        {
            TestManager manager = new TestManager("id-1", "Audio", "Core", false, null);

            Assert.Equal("id-1", manager.Id);
            Assert.Equal("Audio", manager.Name);
            Assert.Equal("Core", manager.Tag);
            Assert.False(manager.IsEnable);
            Assert.Null(manager.Context);
        }

        [Fact]
        public void AManager_AllVirtualLifecycleMethods_ShouldBeNoOpByDefault()
        {
            TestManager manager = new TestManager(null);

            manager.OnEnable();
            manager.OnInit();
            manager.OnAwake();
            manager.OnStart();
            manager.OnBeforeUpdate();
            manager.OnUpdate();
            manager.OnAfterUpdate();
            manager.OnProcessPendingChanges();
            manager.OnBeforeFixedUpdate();
            manager.OnFixedUpdate();
            manager.OnAfterFixedUpdate();
            manager.OnDispatchEvents();
            manager.OnCalculate();
            manager.OnBeforeDraw();
            manager.OnDraw();
            manager.OnAfterDraw();
            manager.OnGui();
            manager.OnRenderPresent();
            manager.OnDisable();
            manager.OnReset();
            manager.OnStop();
            manager.OnExit();
            manager.OnDestroy();
            manager.OnSave();
            manager.OnLoad();
            manager.OnSave("path");
            manager.OnLoad("path");
            manager.OnPhysicUpdate();

            Assert.True(true);
        }

        private static void AssertStructLayout(Type type)
        {
            StructLayoutAttribute layout = type.StructLayoutAttribute;
            Assert.NotNull(layout);
            Assert.Equal(LayoutKind.Sequential, layout.Value);
            Assert.Equal(1, layout.Pack);
        }

        private sealed class TestManager : AManager
        {
            public TestManager(Context context) : base(context)
            {
            }

            public TestManager(string id, string name, string tag, bool isEnable, Context context)
                : base(id, name, tag, isEnable, context)
            {
            }
        }
    }
}

