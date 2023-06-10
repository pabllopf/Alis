using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl messageboxcolorscheme
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlMessageBoxColorScheme
    {
        /// <summary>
        ///     The colors
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int) SdlMessageBoxColorType.SdlMessageboxColorMax)]
        public SdlMessageBoxColor[] colors;
    }
}