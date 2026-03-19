using Xunit;

namespace Alis.Core.Physic.Test
{
    public class SettingEnvTest
    {
        [Fact]
        public void SettingEnv_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(global::Alis.Core.Physic.SettingEnv));
            Assert.True(global::Alis.Core.Physic.SettingEnv.MaxFloat > 0.0f);
        }
    }
}

