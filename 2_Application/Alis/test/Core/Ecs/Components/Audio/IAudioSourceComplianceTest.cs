using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
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
            AudioSource source = new AudioSource();
            Assert.IsAssignableFrom<IAudioSource>(source);
        }

        /// <summary>
        /// Tests that audio source implements i on start
        /// </summary>
        [Fact]
        public void AudioSource_ImplementsIOnStart()
        {
            AudioSource source = new AudioSource();
            IOnStart onStart = source as Alis.Core.Aspect.Fluent.Components.IOnStart;
            Assert.NotNull(onStart);
        }

        /// <summary>
        /// Tests that audio source implements i on update
        /// </summary>
        [Fact]
        public void AudioSource_ImplementsIOnUpdate()
        {
            AudioSource source = new AudioSource();
            IOnUpdate onUpdate = source as Alis.Core.Aspect.Fluent.Components.IOnUpdate;
            Assert.NotNull(onUpdate);
        }

        /// <summary>
        /// Tests that audio source implements i on exit
        /// </summary>
        [Fact]
        public void AudioSource_ImplementsIOnExit()
        {
            AudioSource source = new AudioSource();
            IOnExit onExit = source as Alis.Core.Aspect.Fluent.Components.IOnExit;
            Assert.NotNull(onExit);
        }

        /// <summary>
        /// Tests that audio source has context property
        /// </summary>
        [Fact]
        public void AudioSource_HasContextProperty()
        {
            AudioSource source = new AudioSource();
            Context context = source.Context;
            Assert.Null(context);
        }
    }
}
