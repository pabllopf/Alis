

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl sensor event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SensorEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The which
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float0;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float1;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float2;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float3;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float4;

        /// <summary>
        ///     The data
        /// </summary>
        public readonly float float5;
    }
}