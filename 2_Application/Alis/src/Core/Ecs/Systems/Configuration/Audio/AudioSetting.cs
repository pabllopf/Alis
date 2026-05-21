

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems.Configuration.Audio
{
    /// <summary>
    ///     The audio setting
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AudioSetting(int volume, bool mute) : IAudioSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AudioSetting" /> class with default values.
        /// </summary>
        public AudioSetting() : this(100, false)
        {
        }

        /// <summary>
        ///     Gets or sets the value of the volume
        /// </summary>
        public int Volume { get; set; } = volume;

        /// <summary>
        ///     Gets or sets the value of the mute
        /// </summary>
        public bool Mute { get; set; } = mute;
    }
}