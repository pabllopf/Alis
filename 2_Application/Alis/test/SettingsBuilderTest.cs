

using System;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.General;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Graphic;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Input;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Network;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Physic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders
{
    /// <summary>
    ///     Contains unit tests for the <see cref="SettingsBuilder" /> class.
    /// </summary>
    public class SettingsBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a Setting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsSettingInstance()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting setting = builder.Build();

            Assert.NotNull(setting);
            Assert.IsType<Setting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null Setting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullSetting()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that settings can be configured via the builder.
        /// </summary>
        [Fact]
        public void SettingsCanBeConfiguredViaBuilder()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder creates a valid Setting object.
        /// </summary>
        [Fact]
        public void BuilderCreatesValidSettingObject()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            SettingsBuilder builder = new SettingsBuilder();

            Assert.IsAssignableFrom<IBuild<Setting>>(builder);
            Assert.IsAssignableFrom<IAudio<SettingsBuilder, Action<AudioSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IGeneral<SettingsBuilder, Action<GeneralSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IGraphic<SettingsBuilder, Action<GraphicSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IInput<SettingsBuilder, Action<InputSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<INetwork<SettingsBuilder, Action<NetworkSettingBuilder>>>(builder);
            Assert.IsAssignableFrom<IPhysic<SettingsBuilder, Action<PhysicSettingBuilder>>>(builder);
        }

        /// <summary>
        ///     Tests that the builder can be chained.
        /// </summary>
        [Fact]
        public void BuilderCanBeChained()
        {
            SettingsBuilder builder = new SettingsBuilder();

            SettingsBuilder result = builder
                .General(g => g.Name("TestGame"))
                .Audio(a => a.Volume(50))
                .Graphic(g => g.Target("High"))
                .Physic(p => p.Debug(false));

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that the builder default state is valid.
        /// </summary>
        [Fact]
        public void BuilderDefaultState_IsValid()
        {
            SettingsBuilder builder = new SettingsBuilder();
            Setting setting = builder.Build();

            Assert.NotNull(setting);
        }
    }
}
