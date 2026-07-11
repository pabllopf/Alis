using Alis.Core.Ecs.Components.Audio;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    /// <summary>
    /// The audio source compliance test class
    /// </summary>
    public class IAudioSourceComplianceTest
    {
        /// <summary>
        /// Tests that interface is implemented by audio source
        /// </summary>
        [Fact]
        public void Interface_IsImplementedByAudioSource()
        {
            var source = new AudioSource();
            Assert.IsAssignableFrom<IAudioSource>(source);
        }

        /// <summary>
        /// Tests that audio source implements i on start
        /// </summary>
        [Fact]
        public void AudioSource_ImplementsIOnStart()
        {
            var source = new AudioSource();
            var onStart = source as Alis.Core.Aspect.Fluent.Components.IOnStart;
            Assert.NotNull(onStart);
        }

        /// <summary>
        /// Tests that audio source implements i on update
        /// </summary>
        [Fact]
        public void AudioSource_ImplementsIOnUpdate()
        {
            var source = new AudioSource();
            var onUpdate = source as Alis.Core.Aspect.Fluent.Components.IOnUpdate;
            Assert.NotNull(onUpdate);
        }

        /// <summary>
        /// Tests that audio source implements i on exit
        /// </summary>
        [Fact]
        public void AudioSource_ImplementsIOnExit()
        {
            var source = new AudioSource();
            var onExit = source as Alis.Core.Aspect.Fluent.Components.IOnExit;
            Assert.NotNull(onExit);
        }

        /// <summary>
        /// Tests that audio source has context property
        /// </summary>
        [Fact]
        public void AudioSource_HasContextProperty()
        {
            var source = new AudioSource();
            var context = source.Context;
            Assert.Null(context);
        }
    }
}
