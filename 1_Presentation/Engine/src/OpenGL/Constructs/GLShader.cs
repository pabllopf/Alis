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
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.App.Engine.OpenGL.Enums;
using static Alis.App.Engine.OpenGL.Gl;

namespace Alis.App.Engine.OpenGL.Constructs
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

        // Specifies the OpenGL ShaderID.
        /// <summary>
        ///     Gets or sets the value of the shader id
        /// </summary>
        public uint ShaderId { get; private set; }

        // Specifies the type of shader.
        /// <summary>
        ///     Gets or sets the value of the shader type
        /// </summary>
        public ShaderType ShaderType { get; private set; }

        // Returns Gl.GetShaderInfoLog(ShaderID), which contains any compilation errors.
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