

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IVolume interface.
    ///     Tests the Volume method for volume control.
    /// </summary>
    public class IVolumeTest
    {
        /// <summary>
        ///     Tests that IVolume can be implemented.
        /// </summary>
        [Fact]
        public void IVolume_CanBeImplemented()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IVolume<VolumeBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Volume sets level correctly.
        /// </summary>
        [Fact]
        public void Volume_SetsLevelCorrectly()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder result = builder.Volume(0.5f);
            Assert.Equal(0.5f, result.VolumeLevel);
        }

        /// <summary>
        ///     Tests that Volume returns builder.
        /// </summary>
        [Fact]
        public void Volume_ReturnsBuilder()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder result = builder.Volume(0.8f);
            Assert.NotNull(result);
            Assert.IsType<VolumeBuilder>(result);
        }

        /// <summary>
        ///     Tests Volume with valid range (0 to 1).
        /// </summary>
        [Theory, InlineData(0f), InlineData(0.25f), InlineData(0.5f), InlineData(0.75f), InlineData(1f)]
        public void Volume_WithValidRange(float level)
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder result = builder.Volume(level);
            Assert.Equal(level, result.VolumeLevel);
        }

        /// <summary>
        ///     Tests Volume with extreme values.
        /// </summary>
        [Fact]
        public void Volume_WithExtremeValues()
        {
            VolumeBuilderImpl builder = new VolumeBuilderImpl();
            VolumeBuilder resultMin = builder.Volume(0f);
            Assert.Equal(0f, resultMin.VolumeLevel);
            VolumeBuilder resultMax = builder.Volume(1f);
            Assert.Equal(1f, resultMax.VolumeLevel);
        }

        /// <summary>
        ///     Helper builder class for volume.
        /// </summary>
        private class VolumeBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the volume level
            /// </summary>
            public float VolumeLevel { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IVolume.
        /// </summary>
        private class VolumeBuilderImpl : IVolume<VolumeBuilder, float>
        {
            /// <summary>
            ///     The volume builder
            /// </summary>
            private readonly VolumeBuilder _builder = new VolumeBuilder();

            /// <summary>
            ///     Volumes the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public VolumeBuilder Volume(float value)
            {
                _builder.VolumeLevel = value;
                return _builder;
            }
        }
    }
}