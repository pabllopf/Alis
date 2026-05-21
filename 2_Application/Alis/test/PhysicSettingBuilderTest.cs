

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Physic;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders.Physic
{
    /// <summary>
    ///     Contains unit tests for the <see cref="PhysicSettingBuilder" /> class.
    /// </summary>
    public class PhysicSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns a PhysicSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsPhysicSettingInstance()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSetting setting = builder.Build();

            Assert.NotNull(setting);
            Assert.IsType<PhysicSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null PhysicSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullPhysicSetting()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();
            PhysicSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that PhysicSetting can be configured via the builder.
        /// </summary>
        [Fact]
        public void PhysicSettingCanBeConfiguredViaBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            PhysicSetting setting = builder.Gravity(0f, -9.81f).Debug(true).Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder creates a valid PhysicSetting object.
        /// </summary>
        [Fact]
        public void BuilderCreatesValidPhysicSettingObject()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            PhysicSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            Assert.IsAssignableFrom<IBuild<PhysicSetting>>(builder);
            Assert.IsAssignableFrom<IGravity<PhysicSettingBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that gravity can be set via the builder.
        /// </summary>
        [Fact]
        public void GravityCanBeSetViaBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            PhysicSetting setting = builder.Gravity(0f, -15f).Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that debug mode can be set via the builder.
        /// </summary>
        [Fact]
        public void DebugCanBeSetViaBuilder()
        {
            PhysicSettingBuilder builder = new PhysicSettingBuilder();

            PhysicSetting setting = builder.Debug(true).Build();

            Assert.NotNull(setting);
        }
    }
}
