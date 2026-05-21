

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Reproduccion en modo cover y velocidad lenta.
    /// </summary>
    internal class VideoCoverSlowMotionExample : VideoExampleBase
    {
        /// <summary>
        /// Gets the value of the use cover scaling
        /// </summary>
        protected override bool UseCoverScaling => true;

        /// <summary>
        /// Gets the value of the playback speed
        /// </summary>
        protected override double PlaybackSpeed => 0.5;
    }
}

