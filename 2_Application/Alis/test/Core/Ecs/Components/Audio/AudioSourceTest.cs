

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     Tests for the AudioSource component struct
    /// </summary>
    public class AudioSourceTest
    {
        /// <summary>
        ///     Tests that the constructor creates an AudioSource with default values
        /// </summary>
        [Fact]
        public void AudioSource_Constructor_ShouldCreateWithDefaultValues()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            Assert.Equal(context, source.Context);
            Assert.Equal(string.Empty, source.NameFile);
            Assert.Equal(100f, source.Volume);
            Assert.False(source.IsMute);
            Assert.False(source.PlayOnAwake);
            Assert.False(source.IsLooping);
        }

        /// <summary>
        ///     Tests that AudioSource implements IAudioSource interface
        /// </summary>
        [Fact]
        public void AudioSource_ShouldImplementIAudioSourceInterface()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            Assert.IsAssignableFrom<IAudioSource>(source);
        }

        /// <summary>
        ///     Tests that the Play method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_PlayMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Play();
        }

        /// <summary>
        ///     Tests that the Stop method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_StopMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Stop();
        }

        /// <summary>
        ///     Tests that the Resume method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_ResumeMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.Resume();
        }

        /// <summary>
        ///     Tests that the OnStart method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_OnStartMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.OnStart(null!);
        }

        /// <summary>
        ///     Tests that the OnExit method exists and is callable
        /// </summary>
        [Fact]
        public void AudioSource_OnExitMethod_ShouldExistAndBeCallable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.OnExit(null!);
        }

        /// <summary>
        ///     Tests that AudioSource properties are gettable and settable
        /// </summary>
        [Fact]
        public void AudioSource_Properties_ShouldBeGetAndSettable()
        {
            Context context = new Context();

            AudioSource source = new AudioSource(context);

            source.NameFile = "test.wav";
            Assert.Equal("test.wav", source.NameFile);

            source.Volume = 50f;
            Assert.Equal(50f, source.Volume);

            source.IsMute = true;
            Assert.True(source.IsMute);

            source.PlayOnAwake = true;
            Assert.True(source.PlayOnAwake);

            source.IsLooping = true;
            Assert.True(source.IsLooping);
        }
    }
}
