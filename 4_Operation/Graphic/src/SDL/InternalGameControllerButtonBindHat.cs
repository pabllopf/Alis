using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal gamecontrollerbuttonbind hat
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct InternalGameControllerButtonBindHat
    {
        /// <summary>
        ///     The hat
        /// </summary>
        public int hat;

        /// <summary>
        ///     The hat mask
        /// </summary>
        public int hat_mask;
    }
}