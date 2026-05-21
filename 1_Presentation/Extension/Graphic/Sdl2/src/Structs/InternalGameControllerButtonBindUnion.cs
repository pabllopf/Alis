

using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal game controller button bind union
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct InternalGameControllerButtonBindUnion
    {
        /// <summary>
        ///     The button
        /// </summary>
        [FieldOffset(0)] public readonly int button;

        /// <summary>
        ///     The axis
        /// </summary>
        [FieldOffset(0)] public readonly int axis;

        /// <summary>
        ///     The hat
        /// </summary>
        [FieldOffset(0)] public InternalGameControllerButtonBindHat hat;
    }
}