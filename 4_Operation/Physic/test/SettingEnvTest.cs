using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    /// The setting env test class
    /// </summary>
    public class SettingEnvTest
    {
        /// <summary>
        /// Tests that setting env type should be accessible
        /// </summary>
        [Fact]
        public void SettingEnv_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.SettingEnv));
            Assert.True(global::Alis.Core.Physic.SettingEnv.MaxFloat > 0.0f);
        }
    }
}

