using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    /// Provides tests for the friction and restitution mixing laws in SettingEnv.
    /// </summary>
    public class SettingEnvMixingTest
    {
        /// <summary>
        /// Tests the MixFriction method returns the geometric mean.
        /// </summary>
        [Fact]
        public void MixFriction_ReturnsGeometricMean()
        {
            float f1 = 0.5f;
            float f2 = 0.8f;
            float expected = (float)System.Math.Sqrt(f1 * f2);
            float actual = global::Alis.Core.Physic.SettingEnv.MixFriction(f1, f2);
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Tests the MixRestitution method returns the maximum value.
        /// </summary>
        [Fact]
        public void MixRestitution_ReturnsMaximum()
        {
            float r1 = 0.3f;
            float r2 = 0.7f;
            float expected = r2;
            float actual = global::Alis.Core.Physic.SettingEnv.MixRestitution(r1, r2);
            Assert.Equal(expected, actual);
        }
    }
}
