namespace Alis.Extension.Graphic.OpenGL
{
    /// <summary>
    ///     The primitive type enum
    /// </summary>
    public enum PrimitiveType
    {
        /// <summary>
        ///     The points primitive type
        /// </summary>
        Points = 0x0000, // GL_POINTS
        
        /// <summary>
        ///     The lines primitive type
        /// </summary>
        Lines = 0x0001, // GL_LINES
        
        /// <summary>
        ///     The line loop primitive type
        /// </summary>
        LineLoop = 0x0002, // GL_LINE_LOOP
        
        /// <summary>
        ///     The line strip primitive type
        /// </summary>
        LineStrip = 0x0003, // GL_LINE_STRIP
        
        /// <summary>
        ///     The triangles primitive type
        /// </summary>
        Triangles = 0x0004, // GL_TRIANGLES
        
        /// <summary>
        ///     The triangle strip primitive type
        /// </summary>
        TriangleStrip = 0x0005, // GL_TRIANGLE_STRIP
        
        /// <summary>
        ///     The triangle fan primitive type
        /// </summary>
        TriangleFan = 0x0006 // GL_TRIANGLE_FAN
    }
}