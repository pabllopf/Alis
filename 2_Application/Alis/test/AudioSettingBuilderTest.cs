

using Alis.Builder.Core.Ecs.System.ConfigurationBuilders.Audio;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Ecs.Systems.Configuration.Audio;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.System.ConfigurationBuilders.Audio
{
    /// <summary>
    ///     Contains unit tests for the <see cref="AudioSettingBuilder" /> class.
    /// </summary>
    public class AudioSettingBuilderTest
    {
        /// <summary>
        ///     Tests that the default constructor creates a builder.
        /// </summary>
        [Fact]
        public void DefaultConstructor_CreatesBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();

            Assert.NotNull(builder);
        }

        /// <summary>
        ///     Tests that the Build method returns an AudioSetting instance.
        /// </summary>
        [Fact]
        public void Build_ReturnsAudioSettingInstance()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSetting setting = builder.Build();

            Assert.NotNull(setting);
            Assert.IsType<AudioSetting>(setting);
        }

        /// <summary>
        ///     Tests that the Build method returns a non-null AudioSetting.
        /// </summary>
        [Fact]
        public void Build_ReturnsNonNullAudioSetting()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();
            AudioSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that AudioSetting can be configured via the builder.
        /// </summary>
        [Fact]
        public void AudioSettingCanBeConfiguredViaBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();

            AudioSetting setting = builder.Volume(80).IsMute(false).Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder creates a valid AudioSetting object.
        /// </summary>
        [Fact]
        public void BuilderCreatesValidAudioSettingObject()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();

            AudioSetting setting = builder.Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that the builder implements expected interfaces.
        /// </summary>
        [Fact]
        public void BuilderImplementsExpectedInterfaces()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();

            Assert.IsAssignableFrom<IBuild<AudioSetting>>(builder);
        }

        /// <summary>
        ///     Tests that volume can be set via the builder.
        /// </summary>
        [Fact]
        public void VolumeCanBeSetViaBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();

            AudioSetting setting = builder.Volume(100).Build();

            Assert.NotNull(setting);
        }

        /// <summary>
        ///     Tests that mute can be set via the builder.
        /// </summary>
        [Fact]
        public void MuteCanBeSetViaBuilder()
        {
            AudioSettingBuilder builder = new AudioSettingBuilder();

            AudioSetting setting = builder.IsMute(true).Build();

            Assert.NotNull(setting);
        }
    }
}
