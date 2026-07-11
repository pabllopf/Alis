using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Audio;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Components.Audio
{
    /// <summary>
    /// The audio source config test class
    /// </summary>
    public class AudioSourceConfigTest
    {
        /// <summary>
        /// Tests that delegate can be invoked
        /// </summary>
        [Fact]
        public void Delegate_CanBeInvoked()
        {
            AudioSourceConfig<AudioSource> config = builder => { };
            Assert.NotNull(config);
        }
    }
}
