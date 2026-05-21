

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal game controller button bind hat
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalGameControllerButtonBindHat
    {
        /// <summary>
        ///     The hat
        /// </summary>
        public int Hat { get; set; }

        /// <summary>
        ///     The hat mask
        /// </summary>
        public int HatMask { get; set; }
    }
}