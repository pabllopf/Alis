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
using System.Diagnostics;
using System.Numerics;
using static Alis.Core.Graphic.OpenGL.GL;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader program param class
    /// </summary>
    public sealed class GLShaderProgramParam
    {
        /// <summary>
        ///     Specifies the location of the parameter in the OpenGL program.
        /// </summary>
        public int Location;

        /// <summary>
        ///     Specifies the case-sensitive name of the parameter.
        /// </summary>
        public string Name;

        /// <summary>
        ///     Specifies the parameter type (either attribute or uniform).
        /// </summary>
        public ParamType ParamType;

        /// <summary>
        ///     Specifies the OpenGL program ID.
        /// </summary>
        public uint Program;

        /// <summary>
        ///     The program id
        /// </summary>
        public uint ProgramId;

        /// <summary>
        ///     Specifies the C# equivalent of the GLSL data type.
        /// </summary>
        public Type Type;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GLShaderProgramParam" /> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="paramType">The param type</param>
        /// <param name="name">The name</param>
        public GLShaderProgramParam(Type type, ParamType paramType, string name)
        {
            Type = type;
            ParamType = paramType;
            Name = name;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GLShaderProgramParam" /> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="paramType">The param type</param>
        /// <param name="name">The name</param>
        /// <param name="program">The program</param>
        /// <param name="location">The location</param>
        public GLShaderProgramParam(Type type, ParamType paramType, string name, uint program, int location) : this(type, paramType, name)
        {
            ProgramId = Program;
            Location = location;
        }

        /// <summary>
        ///     Gets the location of the parameter in a compiled OpenGL program.
        /// </summary>
        /// <param name="Program">Specifies the shader program that contains this parameter.</param>
        public void GetLocation(GLShaderProgram Program)
        {
            Program.Use();
            if (ProgramId == 0)
            {
                ProgramId = Program.ProgramID;
                Location = ParamType == ParamType.Uniform ? Program.GetUniformLocation(Name) : Program.GetAttributeLocation(Name);
            }
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(bool param)
        {
            EnsureType<bool>();
            glUniform1i(Location, param ? 1 : 0);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(int param)
        {
            EnsureType<int>();
            glUniform1i(Location, param);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(float param)
        {
            EnsureType<float>();
            glUniform1f(Location, param);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Vector2 param)
        {
            EnsureType<Vector2>();
            glUniform2f(Location, param.X, param.Y);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Vector3 param)
        {
            EnsureType<Vector3>();
            glUniform3f(Location, param.X, param.Y, param.Z);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Vector4 param)
        {
            EnsureType<Vector4>();
            glUniform4f(Location, param.X, param.Y, param.Z, param.W);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Matrix4x4 param)
        {
            EnsureType<Matrix4x4>();
            UniformMatrix4fv(Location, param);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        /// <exception cref="ArgumentException">param was an unexpected length. </exception>
        public void SetValue(float[] param)
        {
            if (param.Length == 16)
            {
                EnsureType<Matrix4x4>();
                glUniformMatrix4fv(Location, 1, false, param);
            }
            else if (param.Length == 9)
            {
                EnsureType<Exception>();
                glUniformMatrix3fv(Location, 1, false, param);
            }
            else if (param.Length == 4)
            {
                EnsureType<Vector4>();
                glUniform4f(Location, param[0], param[1], param[2], param[3]);
            }
            else if (param.Length == 3)
            {
                EnsureType<Vector3>();
                glUniform3f(Location, param[0], param[1], param[2]);
            }
            else if (param.Length == 2)
            {
                EnsureType<Vector2>();
                glUniform2f(Location, param[0], param[1]);
            }
            else if (param.Length == 1)
            {
                EnsureType<float>();
                glUniform1f(Location, param[0]);
            }
            else
            {
                throw new ArgumentException("param was an unexpected length.", nameof(param));
            }
        }

        /// <summary>
        ///     Ensures the type
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        [Conditional("DEBUG")]
        private void EnsureType<T>() => Debug.Assert(Type == typeof(T), $"SetValue({Type}) was called with a {typeof(T).Name}");
    }
}