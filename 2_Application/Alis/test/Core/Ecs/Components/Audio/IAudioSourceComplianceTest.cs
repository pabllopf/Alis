using Alis.Core.Ecs.Components.Audio;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    public class IAudioSourceComplianceTest
    {
        [Fact]
        public void Interface_IsImplementedByAudioSource()
        {
            var source = new AudioSource();
            Assert.IsAssignableFrom<IAudioSource>(source);
        }

        [Fact]
        public void AudioSource_ImplementsIOnStart()
        {
            var source = new AudioSource();
            var onStart = source as Alis.Core.Aspect.Fluent.Components.IOnStart;
            Assert.NotNull(onStart);
        }

        [Fact]
        public void AudioSource_ImplementsIOnUpdate()
        {
            var source = new AudioSource();
            var onUpdate = source as Alis.Core.Aspect.Fluent.Components.IOnUpdate;
            Assert.NotNull(onUpdate);
        }

        [Fact]
        public void AudioSource_ImplementsIOnExit()
        {
            var source = new AudioSource();
            var onExit = source as Alis.Core.Aspect.Fluent.Components.IOnExit;
            Assert.NotNull(onExit);
        }

        [Fact]
        public void AudioSource_HasContextProperty()
        {
            var source = new AudioSource();
            var context = source.Context;
            Assert.Null(context);
        }
    }
}
