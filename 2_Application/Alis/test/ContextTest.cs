

using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Execution;
using Alis.Core.Ecs.Systems.Manager.Audio;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Manager.Input;
using Alis.Core.Ecs.Systems.Manager.Network;
using Alis.Core.Ecs.Systems.Manager.Physic;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Manager.Time;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Tests for Context class constructors, properties, and lifecycle behavior
    /// </summary>
    public class ContextTest
    {
        /// <summary>
        ///     Tests that default constructor sets IsRunning to true
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldSetIsRunningToTrue()
        {
            Context context = new Context();

            Assert.True(context.IsRunning);
        }

        /// <summary>
        ///     Tests that default constructor creates Setting with defaults
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateSettingWithDefaults()
        {
            Context context = new Context();

            Assert.NotNull(context.Setting);
            Assert.Equal("Default Name", context.Setting.General.Name);
        }

        /// <summary>
        ///     Tests that default constructor creates InternalRuntime with 7 managers
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateInternalRuntimeWithSevenManagers()
        {
            Context context = new Context();

            Assert.NotNull(context.InternalRuntime);
            Assert.NotNull(context.AudioManager);
            Assert.NotNull(context.GraphicManager);
            Assert.NotNull(context.InputManager);
            Assert.NotNull(context.NetworkManager);
            Assert.NotNull(context.PhysicManager);
            Assert.NotNull(context.SceneManager);
            Assert.NotNull(context.TimeManager);
        }

        /// <summary>
        ///     Tests that default constructor creates AudioManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateAudioManager()
        {
            Context context = new Context();

            Assert.NotNull(context.AudioManager);
            Assert.IsType<AudioManager>(context.AudioManager);
        }

        /// <summary>
        ///     Tests that default constructor creates GraphicManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateGraphicManager()
        {
            Context context = new Context();

            Assert.NotNull(context.GraphicManager);
            Assert.IsType<GraphicManager>(context.GraphicManager);
        }

        /// <summary>
        ///     Tests that default constructor creates InputManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateInputManager()
        {
            Context context = new Context();

            Assert.NotNull(context.InputManager);
            Assert.IsType<InputManager>(context.InputManager);
        }

        /// <summary>
        ///     Tests that default constructor creates NetworkManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateNetworkManager()
        {
            Context context = new Context();

            Assert.NotNull(context.NetworkManager);
            Assert.IsType<NetworkManager>(context.NetworkManager);
        }

        /// <summary>
        ///     Tests that default constructor creates PhysicManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreatePhysicManager()
        {
            Context context = new Context();

            Assert.NotNull(context.PhysicManager);
            Assert.IsType<PhysicManager>(context.PhysicManager);
        }

        /// <summary>
        ///     Tests that default constructor creates SceneManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateSceneManager()
        {
            Context context = new Context();

            Assert.NotNull(context.SceneManager);
            Assert.IsType<SceneManager>(context.SceneManager);
        }

        /// <summary>
        ///     Tests that default constructor creates TimeManager
        /// </summary>
        [Fact]
        public void Context_DefaultConstructor_ShouldCreateTimeManager()
        {
            Context context = new Context();

            Assert.NotNull(context.TimeManager);
            Assert.IsType<TimeManager>(context.TimeManager);
        }

        /// <summary>
        ///     Tests that constructor with Setting uses provided setting
        /// </summary>
        [Fact]
        public void Context_SettingConstructor_ShouldUseProvidedSetting()
        {
            Setting customSetting = new Setting();
            customSetting.General = customSetting.General with {Name = "CustomGame"};

            Context context = new Context(customSetting);

            Assert.Same(customSetting, context.Setting);
            Assert.Equal("CustomGame", context.Setting.General.Name);
            Assert.True(context.IsRunning);
        }

        /// <summary>
        ///     Tests that constructor with Setting and SceneManager uses both
        /// </summary>
        [Fact]
        public void Context_SettingAndSceneManagerConstructor_ShouldUseBothParameters()
        {
            Setting customSetting = new Setting();
            customSetting.General = customSetting.General with {Name = "CustomGame"};
            SceneManager customSceneManager = new SceneManager(null);

            Context context = new Context(customSetting, customSceneManager);

            Assert.Same(customSetting, context.Setting);
            Assert.Same(customSceneManager, context.SceneManager);
            Assert.True(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Exit sets IsRunning to false
        /// </summary>
        [Fact]
        public void Context_Exit_ShouldSetIsRunningToFalse()
        {
            Context context = new Context();

            context.Exit();

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that AudioManager returns from InternalRuntime
        /// </summary>
        [Fact]
        public void Context_AudioManagerProperty_ShouldReturnFromInternalRuntime()
        {
            Context context = new Context();

            AudioManager fromProperty = context.AudioManager;
            AudioManager fromRuntime = context.InternalRuntime.Get<AudioManager>();

            Assert.Same(fromRuntime, fromProperty);
        }

        /// <summary>
        ///     Tests that SceneManager returns from InternalRuntime
        /// </summary>
        [Fact]
        public void Context_SceneManagerProperty_ShouldReturnFromInternalRuntime()
        {
            Context context = new Context();

            SceneManager fromProperty = context.SceneManager;
            SceneManager fromRuntime = context.InternalRuntime.Get<SceneManager>();

            Assert.Same(fromRuntime, fromProperty);
        }
    }
}
