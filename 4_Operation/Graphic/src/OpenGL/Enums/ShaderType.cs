namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The shader type enum
    /// </summary>
    public enum ShaderType
    {
        /// <summary>
        ///     The fragment shader shader type
        /// </summary>
        FragmentShader = 0x8B30,

        /// <summary>
        ///     The vertex shader shader type
        /// </summary>
        VertexShader = 0x8B31,

        /// <summary>
        ///     The geometry shader shader type
        /// </summary>
        GeometryShader = 0x8DD9,

        /// <summary>
        ///     The tess control shader shader type
        /// </summary>
        TessControlShader = 0x8E88,

        /// <summary>
        ///     The tess evaluation shader shader type
        /// </summary>
        TessEvaluationShader = 0x8E87,

        /// <summary>
        ///     The compute shader shader type
        /// </summary>
        ComputeShader = 0x91B9
    }
}