using System;
using System.IO;

namespace Alis.Extension.FFMeg.Test.Resources
{
    /// <summary>
    /// The res class
    /// </summary>
    public static class Res 
    {
        /// <summary>
        /// The directory
        /// </summary>
        public const string Directory = "Assets";
            
        /// <summary>
        /// The video mp4
        /// </summary>
        public const string Video_Mp4 = "small.mp4";
        /// <summary>
        /// The video webm
        /// </summary>
        public const string Video_Webm = "small.webm";
        /// <summary>
        /// The video flv
        /// </summary>
        public const string Video_Flv = "small.flv";
        /// <summary>
        /// The audio mp3
        /// </summary>
        public const string Audio_Mp3 = "horse.mp3";
        /// <summary>
        /// The audio ogg
        /// </summary>
        public const string Audio_Ogg = "horse.ogg";

        /// <summary>
        /// Gets the path using the specified resource name
        /// </summary>
        /// <param name="resourceName">The resource name</param>
        /// <returns>The string</returns>
        public static string GetPath(string resourceName) => Path.Combine(Path.Combine(Environment.CurrentDirectory, Directory), resourceName);
    }
}
