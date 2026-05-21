

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Alis.Extension.Graphic.Ui.Test.Assets
{
    /// <summary>
    ///     The res class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ResTest
    {
        /// <summary>
        ///     The directory
        /// </summary>
        public const string Directory = "Assets";

        /// <summary>
        ///     The video mp4
        /// </summary>
        public const string VideoMp4 = "small.mp4";

        /// <summary>
        ///     The video webm
        /// </summary>
        public const string VideoWebm = "small.webm";

        /// <summary>
        ///     The video flv
        /// </summary>
        public const string VideoFlv = "small.flv";

        /// <summary>
        ///     The audio mp3
        /// </summary>
        public const string AudioMp3 = "horse.wav";

        /// <summary>
        ///     The audio ogg
        /// </summary>
        public const string AudioOgg = "horse.ogg";

        /// <summary>
        ///     Gets the path using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The string</returns>
        public static string GetPath(string resourceName) => Path.Combine(Path.Combine(Environment.CurrentDirectory, Directory), resourceName);
    }
}