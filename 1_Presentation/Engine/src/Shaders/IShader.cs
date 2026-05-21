

namespace Alis.App.Engine.Shaders
{
    /// <summary>
    ///     The shader interface
    /// </summary>
    public interface IShader
    {
        /// <summary>
        ///     Gets the value of the shader code
        /// </summary>
        string ShaderCode { get; }
    }
}