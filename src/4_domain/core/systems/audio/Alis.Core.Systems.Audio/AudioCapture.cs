using System;
using System.Runtime.InteropServices;
using Alis.Core.Systems.Audio.OpenAl;

namespace Alis.Core.Systems.Audio
{
    /// <summary>
    /// Represents an abstract audio capture device, capable of creating device resources and executing commands.
    /// </summary>
    public abstract class AudioCapture : IDisposable
    {
        /// <summary>
        /// Gets a value identifying the specific graphics API used by this instance.
        /// </summary>
        public abstract AudioBackend BackendType { get; }

        /// <summary>
        /// Creates a new <see cref="AudioCapture"/> using OpenAL.
        /// </summary>
        /// <returns>A new <see cref="AudioCapture"/> using the OpenAL API.</returns>
        public static AudioCapture CreateOpenAL()
        {
            return CreateOpenAL(new AudioCaptureOptions());
        }

        /// <summary>
        /// Creates a new <see cref="AudioCapture"/> using OpenAL.
        /// </summary>
        /// <param name="options">the settings for this audio capture device</param>
        /// <returns>A new <see cref="AudioCapture"/> using the OpenAL API. If not possible returns null</returns>
        public static AudioCapture CreateOpenAL(AudioCaptureOptions options)
        {
            try
            {
                return new ALCapture(options);
            }
            catch (TypeInitializationException)
            {
                return null;
            }
        }

        /// <summary>
        /// Creates a new <see cref="AudioCapture"/> using OpenAL.
        /// </summary>
        /// <returns>A new <see cref="AudioCapture"/> using the openal API.</returns>
        public static AudioCapture CreateDefault()
        {
            return CreateDefault(new AudioCaptureOptions());
        }

        /// <summary>
        /// Create the default backend for the current operating system
        /// </summary>
        /// <param name="options">the settings for this audio capture device</param>
        /// <returns></returns>
        public static AudioCapture CreateDefault(AudioCaptureOptions options)
        {
            return CreateOpenAL(options);
        }

        /// <summary>
        /// Performs API-specific disposal of resources controlled by this instance.
        /// </summary>
        protected abstract void PlatformDispose();

        /// <summary>
        /// Free this instance
        /// </summary>
        public void Dispose()
        {
            PlatformDispose();
        }
    }
}
