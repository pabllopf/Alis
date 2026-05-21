

using System;
using Alis.Core.Graphic.OpenGL.Enums;
using static Alis.Core.Graphic.OpenGL.Gl;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShader : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GlShader" /> class
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="type">The type</param>
        /// <exception cref="Exception"></exception>
        public GlShader(string source, ShaderType type)
        {
            ShaderType = type;
            ShaderId = GlCreateShader(type);

            ShaderSource(ShaderId, source);
            GlCompileShader(ShaderId);

            if (!GetShaderCompileStatus(ShaderId))
            {
                throw new Exception(ShaderLog);
            }
        }

        /// <summary>
        ///     Gets or sets the value of the shader id
        /// </summary>
        public uint ShaderId { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the shader type
        /// </summary>
        public ShaderType ShaderType { get; private set; }

        /// <summary>
        ///     Gets the value of the shader log
        /// </summary>
        public string ShaderLog => GetShaderInfoLog(ShaderId);

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     /
        /// </summary>
        ~GlShader() => Dispose(false);

        /// <summary>
        ///     Disposes the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        private void Dispose(bool _)
        {
            if (ShaderId != 0)
            {
                GlDeleteShader(ShaderId);
                ShaderId = 0;
            }
        }
    }
}