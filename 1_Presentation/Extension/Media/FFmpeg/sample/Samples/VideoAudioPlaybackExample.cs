

using System;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Media.FFmpeg.Audio;

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Reproduccion de video en la ventana OpenGL junto al audio del mismo asset.
    /// </summary>
    internal class VideoAudioPlaybackExample : VideoExampleBase
    {
        /// <summary>
        /// The audio player
        /// </summary>
        private AudioPlayer audioPlayer;

        /// <summary>
        /// Gets the value of the loop video
        /// </summary>
        protected override bool LoopVideo => false;

        /// <summary>
        /// Called after the video reader and GL resources are initialized
        /// </summary>
        protected override void OnInitialize()
        {
            try
            {
                audioPlayer = new AudioPlayer(VideoPath);
                audioPlayer.PlayInBackground("-autoexit -vn");
            }
            catch (Exception ex)
            {
                Logger.Info($"No se pudo iniciar el audio para '{VideoAssetName}': {ex.Message}");
            }
        }

        /// <summary>
        /// Called during cleanup before releasing base resources
        /// </summary>
        protected override void OnCleanup()
        {
            audioPlayer?.Dispose();
            audioPlayer = null;
        }
    }
}

