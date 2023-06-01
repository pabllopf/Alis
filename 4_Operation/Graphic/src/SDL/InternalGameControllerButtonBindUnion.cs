using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal gamecontrollerbuttonbind union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct InternalGameControllerButtonBindUnion
    {
        /// <summary>
        ///     The button
        /// </summary>
        [FieldOffset(0)] public int button;

        /// <summary>
        ///     The axis
        /// </summary>
        [FieldOffset(0)] public int axis;

        /// <summary>
        ///     The hat
        /// </summary>
        [FieldOffset(0)] public InternalGameControllerButtonBindHat hat;
    }
}