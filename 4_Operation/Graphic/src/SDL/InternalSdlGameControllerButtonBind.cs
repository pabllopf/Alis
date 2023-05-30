using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal sdl gamecontrollerbuttonbind
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct InternalSdlGameControllerButtonBind
    {
        /// <summary>
        ///     The bind type
        /// </summary>
        public int bindType;

        /* Largest data type in the union is two ints in size */
        /// <summary>
        ///     The union val
        /// </summary>
        public int unionVal0;

        /// <summary>
        ///     The union val
        /// </summary>
        public int unionVal1;
    }
}