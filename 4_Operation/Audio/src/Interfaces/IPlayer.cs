

using System;
using System.Threading.Tasks;

namespace Alis.Core.Audio.Interfaces
{
    /// <summary>
    ///     The player interface
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        ///     Gets the value of the playing
        /// </summary>
        bool Playing { get; }

        /// <summary>
        ///     Gets the value of the paused
        /// </summary>
        bool Paused { get; }

        /// <summary>
        ///     playback
        /// </summary>
        event EventHandler PlaybackFinished;

        /// <summary>
        ///     Plays the file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        Task Play(string fileName);

        /// <summary>
        ///     Plays the loop using the specified file name
        /// </summary>
        /// <param name="fileName">The file name</param>
        /// <param name="loop">The loop</param>
        Task PlayLoop(string fileName, bool loop);

        /// <summary>
        ///     Pauses this instance
        /// </summary>
        Task Pause();

        /// <summary>
        ///     Resumes this instance
        /// </summary>
        Task Resume();

        /// <summary>
        ///     Stops this instance
        /// </summary>
        Task Stop();

        /// <summary>
        ///     Sets the volume using the specified percent
        /// </summary>
        /// <param name="percent">The percent</param>
        Task SetVolume(byte percent);
    }
}