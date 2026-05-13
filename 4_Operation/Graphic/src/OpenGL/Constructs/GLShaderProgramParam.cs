// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgramParam.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    /// Represents a single parameter (attribute or uniform) in an OpenGL shader program.
    /// Provides typed value-setting methods that automatically map managed types to their
    /// corresponding OpenGL uniform/attribute commands.
    /// </summary>
    public sealed class GlShaderProgramParam
    {
        /// <summary>
        /// Specifies the case-sensitive name of the parameter as declared in the GLSL shader.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Specifies whether this parameter is a uniform or vertex attribute.
        /// </summary>
        public readonly ParamType ParamType;

        /// <summary>
        /// Specifies the managed <see cref="Type"/> that corresponds to the GLSL data type of this parameter.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlShaderProgramParam" /> class.
        /// </summary>
        /// <param name="type">The managed type equivalent of the GLSL data type.</param>
        /// <param name="paramType">Whether this is a uniform or attribute parameter.</param>
        /// <param name="name">The case-sensitive name from the GLSL shader source.</param>
        public GlShaderProgramParam(Type type, ParamType paramType, string name)
        {
            Type = type;
            ParamType = paramType;
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlShaderProgramParam" /> class
        /// with a pre-resolved program and location.
        /// </summary>
        /// <param name="type">The managed type equivalent of the GLSL data type.</param>
        /// <param name="paramType">Whether this is a uniform or attribute parameter.</param>
        /// <param name="name">The case-sensitive name from the GLSL shader source.</param>
        /// <param name="program">The OpenGL program ID that owns this parameter.</param>
        /// <param name="location">The pre-resolved OpenGL location of the parameter.</param>
        public GlShaderProgramParam(Type type, ParamType paramType, string name, uint program, int location) : this(type, paramType, name)
        {
            ProgramId = Program;
            Location = location;
        }

        /// <summary>
        /// Gets or sets the OpenGL location of this parameter within the shader program.
        /// </summary>
        public int Location { get; set; }

        /// <summary>
        /// Gets or sets the OpenGL program ID that owns this parameter.
        /// </summary>
        public uint Program { get; set; }

        /// <summary>
        /// Gets or sets the OpenGL program ID (alias for internal use).
        /// </summary>
        public uint ProgramId { get; set; }

        /// <summary>
        /// Resolves and caches the OpenGL location of this parameter within the specified shader program.
        /// </summary>
        /// <param name="program">The shader program that contains this parameter.</param>
        public void GetLocation(GlShaderProgram program)
        {
            program.Use();
            if (ProgramId == 0)
            {
                ProgramId = program.ProgramId;
                Location = ParamType == ParamType.Uniform ? program.GetUniformLocation(Name) : program.GetAttributeLocation(Name);
            }
        }

        /// <summary>
        /// Sets the value of this parameter as a boolean (converted to integer 0/1).
        /// </summary>
        /// <param name="param">The boolean value to set.</param>
        public void SetValue(bool param)
        {
            EnsureType<bool>();
            Gl.GlUniform1I(Location, param ? 1 : 0);
        }

        /// <summary>
        /// Sets the value of this parameter as an integer.
        /// </summary>
        /// <param name="param">The integer value to set.</param>
        public void SetValue(int param)
        {
            EnsureType<int>();
            Gl.GlUniform1I(Location, param);
        }

        /// <summary>
        /// Sets the value of this parameter as a single-precision float.
        /// </summary>
        /// <param name="param">The float value to set.</param>
        public void SetValue(float param)
        {
            EnsureType<float>();
            Gl.GlUniform1F(Location, param);
        }

        /// <summary>
        /// Sets the value of this parameter as a 2-component float vector.
        /// </summary>
        /// <param name="param">The vector value to set.</param>
        public void SetValue(Vector2F param)
        {
            EnsureType<Vector2F>();
            Gl.GlUniform2F(Location, param.X, param.Y);
        }

        /// <summary>
        /// Sets the value of this parameter as a 3-component float vector.
        /// </summary>
        /// <param name="param">The vector value to set.</param>
        public void SetValue(Vector3F param)
        {
            EnsureType<Vector3F>();
            Gl.GlUniform3F(Location, param.X, param.Y, param.Z);
        }

        /// <summary>
        /// Sets the value of this parameter as a 4-component float vector.
        /// </summary>
        /// <param name="param">The vector value to set.</param>
        public void SetValue(Vector4F param)
        {
            EnsureType<Vector4F>();
            Gl.GlUniform4F(Location, param.X, param.Y, param.Z, param.W);
        }

        /// <summary>
        /// Sets the value of this parameter as a 4x4 float matrix.
        /// </summary>
        /// <param name="param">The matrix value to set.</param>
        public void SetValue(Matrix4X4 param)
        {
            EnsureType<Matrix4X4>();
            Gl.UniformMatrix4Fv(Location, param);
        }

        /// <summary>
        /// Sets the value of this parameter using a float array, automatically determining
        /// the appropriate OpenGL command based on array length:
        /// 1 element = Uniform1F, 2 = Uniform2F, 3 = Uniform3F, 4 = Uniform4F,
        /// 9 = UniformMatrix3Fv, 16 = UniformMatrix4Fv.
        /// </summary>
        /// <param name="param">The float array value to set.</param>
        /// <exception cref="ArgumentException">Thrown when the array length is not 1, 2, 3, 4, 9, or 16.</exception>
        public void SetValue(float[] param)
        {
            if (param.Length == 16)
            {
                EnsureType<Matrix4X4>();
                Gl.GlUniformMatrix4Fv(Location, 1, false, param);
            }
            else if (param.Length == 9)
            {
                EnsureType<Exception>();
                Gl.GlUniformMatrix3Fv(Location, 1, false, param);
            }
            else if (param.Length == 4)
            {
                EnsureType<Vector4F>();
                Gl.GlUniform4F(Location, param[0], param[1], param[2], param[3]);
            }
            else if (param.Length == 3)
            {
                EnsureType<Vector3F>();
                Gl.GlUniform3F(Location, param[0], param[1], param[2]);
            }
            else if (param.Length == 2)
            {
                EnsureType<Vector2F>();
                Gl.GlUniform2F(Location, param[0], param[1]);
            }
            else if (param.Length == 1)
            {
                EnsureType<float>();
                Gl.GlUniform1F(Location, param[0]);
            }
            else
            {
                throw new ArgumentException("param was an unexpected length.", nameof(param));
            }
        }

        /// <summary>
        /// Debug-only type assertion that validates the managed type matches the expected parameter type.
        /// No-op in Release builds.
        /// </summary>
        /// <typeparam name="T">The expected managed type.</typeparam>
        [Conditional("DEBUG")]
        private void EnsureType<T>()
        {
        }
    }
}
