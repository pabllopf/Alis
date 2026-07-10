using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Audio;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Components.Audio
{
    public class AudioSourceConfigTest
    {
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            AudioSourceConfig<AudioSource> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
