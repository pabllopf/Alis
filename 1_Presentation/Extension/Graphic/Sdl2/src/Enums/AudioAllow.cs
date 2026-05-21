

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The audio allow enum
    /// </summary>
    public enum AudioAllow : uint
    {
        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        AudioAllowFrequencyChange = 0x00000001,

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        AudioAllowFormatChange = 0x00000002,

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        AudioAllowChannelsChange = 0x00000004,

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        AudioAllowSamplesChange = 0x00000008,

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        AudioAllowAnyChange = AudioAllowFrequencyChange | AudioAllowFormatChange | AudioAllowChannelsChange | AudioAllowSamplesChange
    }
}