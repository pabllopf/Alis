// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: GLShaderProgramParam.cs
// 
//  Author: Pablo Perdomo Falcón
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using static Alis.App.Engine.OpenGL.Gl;

namespace Alis.App.Engine.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader program param class
    /// </summary>
    public sealed class GlShaderProgramParam
    {
        /// <summary>
        ///     Specifies the case-sensitive name of the parameter.
        /// </summary>
        public readonly string Name;

        /// <summary>
        ///     Specifies the parameter type (either attribute or uniform).
        /// </summary>
        public readonly ParamType ParamType;

        /// <summary>
        ///     Specifies the C# equivalent of the GLSL data type.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        ///     Specifies the location of the parameter in the OpenGL program.
        /// </summary>
        public int Location;

        /// <summary>
        ///     Specifies the OpenGL program ID.
        /// </summary>
        public uint Program;

        /// <summary>
        ///     The program id
        /// </summary>
        public uint ProgramId;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GlShaderProgramParam" /> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="paramType">The param type</param>
        /// <param name="name">The name</param>
        public GlShaderProgramParam(Type type, ParamType paramType, string name)
        {
            Type = type;
            ParamType = paramType;
            Name = name;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GlShaderProgramParam" /> class
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="paramType">The param type</param>
        /// <param name="name">The name</param>
        /// <param name="program">The program</param>
        /// <param name="location">The location</param>
        public GlShaderProgramParam(Type type, ParamType paramType, string name, uint program, int location) : this(type, paramType, name)
        {
            ProgramId = Program;
            Location = location;
        }

        /// <summary>
        ///     Gets the location of the parameter in a compiled OpenGL program.
        /// </summary>
        /// <param name="program">Specifies the shader program that contains this parameter.</param>
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
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(bool param)
        {
            EnsureType<bool>();
            GlUniform1I(Location, param ? 1 : 0);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(int param)
        {
            EnsureType<int>();
            GlUniform1I(Location, param);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(float param)
        {
            EnsureType<float>();
            GlUniform1F(Location, param);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Vector2 param)
        {
            EnsureType<Vector2>();
            GlUniform2F(Location, param.X, param.Y);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Vector3 param)
        {
            EnsureType<Vector3>();
            GlUniform3F(Location, param.X, param.Y, param.Z);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Vector4 param)
        {
            EnsureType<Vector4>();
            GlUniform4F(Location, param.X, param.Y, param.Z, param.W);
        }

        /// <summary>
        ///     Sets the value using the specified param
        /// </summary>
        /// <param name="param">The param</param>
        public void SetValue(Matrix4X4 param)
        {
            EnsureType<Matrix4X4>();
            UniformMatrix4Fv(Location, param);
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
                EnsureType<Matrix4X4>();
                GlUniformMatrix4Fv(Location, 1, false, param);
            }
            else if (param.Length == 9)
            {
                EnsureType<Exception>();
                GlUniformMatrix3Fv(Location, 1, false, param);
            }
            else if (param.Length == 4)
            {
                EnsureType<Vector4>();
                GlUniform4F(Location, param[0], param[1], param[2], param[3]);
            }
            else if (param.Length == 3)
            {
                EnsureType<Vector3>();
                GlUniform3F(Location, param[0], param[1], param[2]);
            }
            else if (param.Length == 2)
            {
                EnsureType<Vector2>();
                GlUniform2F(Location, param[0], param[1]);
            }
            else if (param.Length == 1)
            {
                EnsureType<float>();
                GlUniform1F(Location, param[0]);
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