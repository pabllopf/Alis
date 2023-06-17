namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The buffer usage hint enum
    /// </summary>
    public enum BufferUsageHint
    {
        /// <summary>
        ///     The stream draw buffer usage hint
        /// </summary>
        StreamDraw = 0x88E0,

        /// <summary>
        ///     The stream read buffer usage hint
        /// </summary>
        StreamRead = 0x88E1,

        /// <summary>
        ///     The stream copy buffer usage hint
        /// </summary>
        StreamCopy = 0x88E2,

        /// <summary>
        ///     The static draw buffer usage hint
        /// </summary>
        StaticDraw = 0x88E4,

        /// <summary>
        ///     The static read buffer usage hint
        /// </summary>
        StaticRead = 0x88E5,

        /// <summary>
        ///     The static copy buffer usage hint
        /// </summary>
        StaticCopy = 0x88E6,

        /// <summary>
        ///     The dynamic draw buffer usage hint
        /// </summary>
        DynamicDraw = 0x88E8,

        /// <summary>
        ///     The dynamic read buffer usage hint
        /// </summary>
        DynamicRead = 0x88E9,

        /// <summary>
        ///     The dynamic copy buffer usage hint
        /// </summary>
        DynamicCopy = 0x88EA
    }
}