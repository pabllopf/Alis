// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgram.cs
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
using System.Collections.Generic;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.OpenGL.Enums;
using static Alis.Extension.Graphic.OpenGL.Gl;
using Type = System.Type;

namespace Alis.Extension.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader program class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShaderProgram : IDisposable
    {
        /// <summary>
        ///     Specifies whether this program will dispose of the child
        ///     vertex/fragment programs when the IDisposable method is called.
        /// </summary>
        public readonly bool DisposeChildren;

        /// <summary>
        ///     Specifies the fragment shader used in this program.
        /// </summary>
        public readonly GlShader FragmentShader;

        /// <summary>
        ///     Specifies the vertex shader used in this program.
        /// </summary>
        public readonly GlShader VertexShader;

        /// <summary>
        ///     Specifies the OpenGL shader program ID.
        /// </summary>
        public uint ProgramId;

        /// <summary>
        ///     The shader params
        /// </summary>
        private Dictionary<string, GlShaderProgramParam> shaderParams;

        /// <summary>
        ///     Links a vertex and fragment shader together to create a shader program.
        /// </summary>
        /// <param name="vertexShader">Specifies the vertex shader.</param>
        /// <param name="fragmentShader">Specifies the fragment shader.</param>
        public GlShaderProgram(GlShader vertexShader, GlShader fragmentShader)
        {
            VertexShader = vertexShader;
            FragmentShader = fragmentShader;
            ProgramId = GlCreateProgram();
            DisposeChildren = false;

            GlAttachShader(ProgramId, vertexShader.ShaderId);
            GlAttachShader(ProgramId, fragmentShader.ShaderId);
            GlLinkProgram(ProgramId);

            //Check whether the program linked successfully.
            //If not then throw an error with the linking error.
            if (!GetProgramLinkStatus(ProgramId))
            {
                throw new Exception(ProgramLog);
            }

            GetParams();
        }

        /// <summary>
        ///     Creates two shaders and then links them together to create a shader program.
        /// </summary>
        /// <param name="vertexShaderSource">Specifies the source code of the vertex shader.</param>
        /// <param name="fragmentShaderSource">Specifies the source code of the fragment shader.</param>
        public GlShaderProgram(string vertexShaderSource, string fragmentShaderSource)
            : this(new GlShader(vertexShaderSource, ShaderType.VertexShader), new GlShader(fragmentShaderSource, ShaderType.FragmentShader))
            => DisposeChildren = true;

        /// <summary>
        ///     Queries the shader parameter hashtable to find a matching attribute/uniform.
        /// </summary>
        /// <param name="name">Specifies the case-sensitive name of the shader attribute/uniform.</param>
        /// <returns>The requested attribute/uniform, or null on a failure.</returns>
        public GlShaderProgramParam this[string name] => shaderParams.ContainsKey(name) ? shaderParams[name] : null;

        /// <summary>
        ///     Gets the value of the program log
        /// </summary>
        public string ProgramLog => GetProgramInfoLog(ProgramId);

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Parses all of the parameters (attributes/uniforms) from the two attached shaders
        ///     and then loads their location by passing this shader program into the parameter object.
        /// </summary>
        private void GetParams()
        {
            shaderParams = new Dictionary<string, GlShaderProgramParam>();

            int[] resources = new int[1];
            int[] actualLength = new int[1];
            int[] arraySize = new int[1];

            GlGetProgramiv(ProgramId, ProgramParameter.ActiveAttributes, resources);

            for (uint i = 0; i < resources[0]; i++)
            {
                ActiveAttribType[] type = new ActiveAttribType[1];
                StringBuilder sb = new StringBuilder(256);
                GlGetActiveAttrib(ProgramId, i, 256, actualLength, arraySize, type, sb);

                if (!shaderParams.ContainsKey(sb.ToString()))
                {
                    GlShaderProgramParam param = new GlShaderProgramParam(TypeFromAttributeType(type[0]), ParamType.Attribute, sb.ToString());
                    shaderParams.Add(param.Name, param);
                    param.GetLocation(this);
                }
            }

            GlGetProgramiv(ProgramId, ProgramParameter.ActiveUniforms, resources);

            for (uint i = 0; i < resources[0]; i++)
            {
                ActiveUniformType[] type = new ActiveUniformType[1];
                StringBuilder sb = new StringBuilder(256);
                GlGetActiveUniform(ProgramId, i, 256, actualLength, arraySize, type, sb);

                if (!shaderParams.ContainsKey(sb.ToString()))
                {
                    GlShaderProgramParam param = new GlShaderProgramParam(TypeFromUniformType(type[0]), ParamType.Uniform, sb.ToString());
                    shaderParams.Add(param.Name, param);
                    param.GetLocation(this);
                }
            }
        }

        /// <summary>
        ///     Types the from attribute type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The type</returns>
        private Type TypeFromAttributeType(ActiveAttribType type)
        {
            switch (type)
            {
                case ActiveAttribType.Float: return typeof(float);
                case ActiveAttribType.FloatMat2: return typeof(float[]);
                case ActiveAttribType.FloatMat3: throw new Exception();
                case ActiveAttribType.FloatMat4: return typeof(Matrix4X4);
                case ActiveAttribType.FloatVec2: return typeof(Vector2);
                case ActiveAttribType.FloatVec3: return typeof(Vector3);
                case ActiveAttribType.FloatVec4: return typeof(Vector4);
                default: return typeof(object);
            }
        }

        /// <summary>
        ///     Types the from uniform type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The type</returns>
        private Type TypeFromUniformType(ActiveUniformType type)
        {
            switch (type)
            {
                case ActiveUniformType.Int: return typeof(int);
                case ActiveUniformType.Float: return typeof(float);
                case ActiveUniformType.FloatVec2: return typeof(Vector2);
                case ActiveUniformType.FloatVec3: return typeof(Vector3);
                case ActiveUniformType.FloatVec4: return typeof(Vector4);
                case ActiveUniformType.IntVec2: return typeof(int[]);
                case ActiveUniformType.IntVec3: return typeof(int[]);
                case ActiveUniformType.IntVec4: return typeof(int[]);
                case ActiveUniformType.Bool: return typeof(bool);
                case ActiveUniformType.BoolVec2: return typeof(bool[]);
                case ActiveUniformType.BoolVec3: return typeof(bool[]);
                case ActiveUniformType.BoolVec4: return typeof(bool[]);
                case ActiveUniformType.FloatMat2: return typeof(float[]);
                case ActiveUniformType.FloatMat3: throw new Exception();
                case ActiveUniformType.FloatMat4: return typeof(Matrix4X4);
                case ActiveUniformType.Sampler1D:
                case ActiveUniformType.Sampler2D:
                case ActiveUniformType.Sampler3D:
                case ActiveUniformType.SamplerCube:
                case ActiveUniformType.Sampler1DShadow:
                case ActiveUniformType.Sampler2DShadow:
                case ActiveUniformType.Sampler2DRect:
                case ActiveUniformType.Sampler2DRectShadow: return typeof(int);
                case ActiveUniformType.FloatMat2X3:
                case ActiveUniformType.FloatMat2X4:
                case ActiveUniformType.FloatMat3X2:
                case ActiveUniformType.FloatMat3X4:
                case ActiveUniformType.FloatMat4X2:
                case ActiveUniformType.FloatMat4X3: return typeof(float[]);
                case ActiveUniformType.Sampler1DArray:
                case ActiveUniformType.Sampler2DArray:
                case ActiveUniformType.SamplerBuffer:
                case ActiveUniformType.Sampler1DArrayShadow:
                case ActiveUniformType.Sampler2DArrayShadow:
                case ActiveUniformType.SamplerCubeShadow: return typeof(int);
                case ActiveUniformType.UnsignedIntVec2: return typeof(uint[]);
                case ActiveUniformType.UnsignedIntVec3: return typeof(uint[]);
                case ActiveUniformType.UnsignedIntVec4: return typeof(uint[]);
                case ActiveUniformType.IntSampler1D:
                case ActiveUniformType.IntSampler2D:
                case ActiveUniformType.IntSampler3D:
                case ActiveUniformType.IntSamplerCube:
                case ActiveUniformType.IntSampler2DRect:
                case ActiveUniformType.IntSampler1DArray:
                case ActiveUniformType.IntSampler2DArray:
                case ActiveUniformType.IntSamplerBuffer: return typeof(int);
                case ActiveUniformType.UnsignedIntSampler1D:
                case ActiveUniformType.UnsignedIntSampler2D:
                case ActiveUniformType.UnsignedIntSampler3D:
                case ActiveUniformType.UnsignedIntSamplerCube:
                case ActiveUniformType.UnsignedIntSampler2DRect:
                case ActiveUniformType.UnsignedIntSampler1DArray:
                case ActiveUniformType.UnsignedIntSampler2DArray:
                case ActiveUniformType.UnsignedIntSamplerBuffer: return typeof(uint);
                case ActiveUniformType.Sampler2DMultisample: return typeof(int);
                case ActiveUniformType.IntSampler2DMultisample: return typeof(int);
                case ActiveUniformType.UnsignedIntSampler2DMultisample: return typeof(uint);
                case ActiveUniformType.Sampler2DMultisampleArray: return typeof(int);
                case ActiveUniformType.IntSampler2DMultisampleArray: return typeof(int);
                case ActiveUniformType.UnsignedIntSampler2DMultisampleArray: return typeof(uint);
                default: return typeof(object);
            }
        }

        /// <summary>
        ///     Uses this instance
        /// </summary>
        public void Use() => GlUseProgram(ProgramId);

        /// <summary>
        ///     Gets the uniform location using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        public int GetUniformLocation(string name)
        {
            Use();
            return GlGetUniformLocation(ProgramId, name);
        }

        /// <summary>
        ///     Gets the attribute location using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        public int GetAttributeLocation(string name)
        {
            Use();
            return GlGetAttribLocation(ProgramId, name);
        }

        /// <summary>
        /// </summary>
        ~GlShaderProgram() => Dispose(false);

        /// <summary>
        ///     Disposes the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        private void Dispose(bool disposing)
        {
            if (ProgramId != 0)
            {
                GlUseProgram(0);

                GlDetachShader(ProgramId, VertexShader.ShaderId);
                GlDetachShader(ProgramId, FragmentShader.ShaderId);
                GlDeleteProgram(ProgramId);

                if (DisposeChildren)
                {
                    VertexShader.Dispose();
                    FragmentShader.Dispose();
                }

                ProgramId = 0;
            }
        }
    }
}