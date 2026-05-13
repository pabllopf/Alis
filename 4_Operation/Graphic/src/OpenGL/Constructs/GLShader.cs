// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GLShader.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Graphic.OpenGL.Enums;
using static Alis.Core.Graphic.OpenGL.Gl;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    /// Represents an OpenGL shader object that encapsulates shader source compilation and lifecycle management.
    /// Implements <see cref="IDisposable"/> for deterministic resource cleanup.
    /// Supports automatic compilation and error checking via the info log.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShader : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlShader" /> class.
        /// Creates a new OpenGL shader from the provided source code, compiles it, and throws on compilation failure.
        /// </summary>
        /// <param name="source">The GLSL source code string to compile.</param>
        /// <param name="type">The type of shader to create (e.g., VertexShader, FragmentShader).</param>
        /// <exception cref="Exception">Thrown when shader compilation fails; the exception message contains the shader info log.</exception>
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
        /// Gets the OpenGL handle (ID) for this shader object.
        /// </summary>
        public uint ShaderId { get; private set; }

        /// <summary>
        /// Gets the type of this shader (e.g., Vertex, Fragment, Geometry).
        /// </summary>
        public ShaderType ShaderType { get; private set; }

        /// <summary>
        /// Gets the compilation info log for this shader, containing any errors or warnings from the last compilation attempt.
        /// </summary>
        public string ShaderLog => GetShaderInfoLog(ShaderId);

        /// <summary>
        /// Releases the OpenGL shader resource and suppresses finalization.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes the shader object, ensuring the OpenGL resource is released.
        /// </summary>
        ~GlShader() => Dispose(false);

        /// <summary>
        /// Releases the underlying OpenGL shader object if it has not been deleted yet.
        /// </summary>
        /// <param name="disposing">True if called from Dispose, false if called from the finalizer.</param>
        private void Dispose(bool disposing)
        {
            if (ShaderId != 0)
            {
                GlDeleteShader(ShaderId);
                ShaderId = 0;
            }
        }
    }
}
