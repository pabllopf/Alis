

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Core.Ecs.Components.Audio
{
    /// <summary>
    ///     The audio source interface
    /// </summary>
    public interface IAudioSource :
        IOnStart,
        IOnUpdate,
        IHasContext<Context>,
        IOnExit
    {
        /// <summary>
        ///     Plays this instance
        /// </summary>
        void Play();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        void Stop();

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        void Resume();
    }
}