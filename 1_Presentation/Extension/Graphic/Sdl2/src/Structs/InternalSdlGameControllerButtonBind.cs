

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal sdl game controller button bind
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct InternalSdlGameControllerButtonBind
    {
        /// <summary>
        ///     The bind type
        /// </summary>
        public readonly int bindType;

        /// <summary>
        ///     The union val
        /// </summary>
        public readonly int unionVal0;

        /// <summary>
        ///     The union val
        /// </summary>
        public readonly int unionVal1;
    }
}