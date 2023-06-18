using System;

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The begin mode enum
    /// </summary>
    public enum BeginMode
    {
        /// <summary>
        ///     The points begin mode
        /// </summary>
        Points = 0x0000,

        /// <summary>
        ///     The lines begin mode
        /// </summary>
        Lines = 0x0001,

        /// <summary>
        ///     The line loop begin mode
        /// </summary>
        LineLoop = 0x0002,

        /// <summary>
        ///     The line strip begin mode
        /// </summary>
        LineStrip = 0x0003,

        /// <summary>
        ///     The triangles begin mode
        /// </summary>
        Triangles = 0x0004,

        /// <summary>
        ///     The triangle strip begin mode
        /// </summary>
        TriangleStrip = 0x0005,

        /// <summary>
        ///     The triangle fan begin mode
        /// </summary>
        TriangleFan = 0x0006,

        /// <summary>
        ///     The lines adjacency begin mode
        /// </summary>
        LinesAdjacency = 0xA,

        /// <summary>
        ///     The line strip adjacency begin mode
        /// </summary>
        LineStripAdjacency = 0xB,

        /// <summary>
        ///     The triangles adjacency begin mode
        /// </summary>
        TrianglesAdjacency = 0xC,

        /// <summary>
        ///     The triangle strip adjacency begin mode
        /// </summary>
        TriangleStripAdjacency = 0xD,

        /// <summary>
        ///     The patches begin mode
        /// </summary>
        Patches = 0xE
    }
}