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
using Alis.Core.Graphic.OpenGL.Enums;
using Type = System.Type;

namespace Alis.Core.Graphic.OpenGL.Constructs
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
            ProgramId = Gl.GlCreateProgram();
            DisposeChildren = false;

            Gl.GlAttachShader(ProgramId, vertexShader.ShaderId);
            Gl.GlAttachShader(ProgramId, fragmentShader.ShaderId);
            Gl.GlLinkProgram(ProgramId);

            if (!Gl.GetProgramLinkStatus(ProgramId))
            {
                throw new InvalidOperationException(ProgramLog);
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
        ///     Specifies the OpenGL shader program ID.
        /// </summary>
        public uint ProgramId { get; set; }

        /// <summary>
        ///     Queries the shader parameter hashtable to find a matching attribute/uniform.
        /// </summary>
        /// <param name="name">Specifies the case-sensitive name of the shader attribute/uniform.</param>
        /// <returns>The requested attribute/uniform, or null on a failure.</returns>
        public GlShaderProgramParam this[string name] => shaderParams.ContainsKey(name) ? shaderParams[name] : null;

        /// <summary>
        ///     Gets the value of the program log
        /// </summary>
        public string ProgramLog => Gl.GetProgramInfoLog(ProgramId);

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Releases the resources used by this instance.
        /// </summary>
        /// <param name="disposing">Whether this is called from Dispose() (true) or the finalizer (false).</param>
        internal void Dispose(bool disposing)
        {
            if (ProgramId != 0)
            {
                Gl.GlUseProgram(0);

                Gl.GlDetachShader(ProgramId, VertexShader.ShaderId);
                Gl.GlDetachShader(ProgramId, FragmentShader.ShaderId);
                Gl.GlDeleteProgram(ProgramId);

                if (disposing && DisposeChildren)
                {
                    VertexShader.Dispose();
                    FragmentShader.Dispose();
                }

                ProgramId = 0;
            }
        }

        /// <summary>
        ///     Finalizer
        /// </summary>
        ~GlShaderProgram()
        {
            try
            {
                Dispose(false);
            }
            catch
            {
            }
        }

        /// <summary>
        ///     Parses all of the parameters (attributes/uniforms) from the two attached shaders
        ///     and then loads their location by passing this shader program into the parameter object.
        /// </summary>
        internal void GetParams()
        {
            shaderParams = new Dictionary<string, GlShaderProgramParam>();

            int[] resources = new int[1];
            int[] actualLength = new int[1];
            int[] arraySize = new int[1];

            Gl.GlGetProgramiv(ProgramId, ProgramParameter.ActiveAttributes, resources);

            for (uint i = 0; i < resources[0]; i++)
            {
                ActiveAttribType[] type = new ActiveAttribType[1];
                StringBuilder sb = new StringBuilder(256);
                Gl.GlGetActiveAttrib(ProgramId, i, 256, actualLength, arraySize, type, sb);

                if (!shaderParams.ContainsKey(sb.ToString()))
                {
                    GlShaderProgramParam param = new GlShaderProgramParam(TypeFromAttributeType(type[0]), ParamType.Attribute, sb.ToString());
                    shaderParams.Add(param.Name, param);
                    param.GetLocation(this);
                }
            }

            Gl.GlGetProgramiv(ProgramId, ProgramParameter.ActiveUniforms, resources);

            for (uint i = 0; i < resources[0]; i++)
            {
                ActiveUniformType[] type = new ActiveUniformType[1];
                StringBuilder sb = new StringBuilder(256);
                Gl.GlGetActiveUniform(ProgramId, i, 256, actualLength, arraySize, type, sb);

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
        private static Type TypeFromAttributeType(ActiveAttribType type)
        {
            switch (type)
            {
                case ActiveAttribType.Float: return typeof(float);
                case ActiveAttribType.FloatMat2: return typeof(float[]);
                case ActiveAttribType.FloatMat3: throw new InvalidOperationException($"ActiveAttribType {type} is not supported.");
                case ActiveAttribType.FloatMat4: return typeof(Matrix4X4);
                case ActiveAttribType.FloatVec2: return typeof(Vector2F);
                case ActiveAttribType.FloatVec3: return typeof(Vector3F);
                case ActiveAttribType.FloatVec4: return typeof(Vector4F);
                default: return typeof(object);
            }
        }

        /// <summary>
        ///     The uniform type map
        /// </summary>
        private static readonly Dictionary<ActiveUniformType, Type> UniformTypeMap = new Dictionary<ActiveUniformType, Type>
        {
            { ActiveUniformType.Int, typeof(int) },
            { ActiveUniformType.Float, typeof(float) },
            { ActiveUniformType.FloatVec2, typeof(Vector2F) },
            { ActiveUniformType.FloatVec3, typeof(Vector3F) },
            { ActiveUniformType.FloatVec4, typeof(Vector4F) },
            { ActiveUniformType.IntVec2, typeof(int[]) },
            { ActiveUniformType.IntVec3, typeof(int[]) },
            { ActiveUniformType.IntVec4, typeof(int[]) },
            { ActiveUniformType.Bool, typeof(bool) },
            { ActiveUniformType.BoolVec2, typeof(bool[]) },
            { ActiveUniformType.BoolVec3, typeof(bool[]) },
            { ActiveUniformType.BoolVec4, typeof(bool[]) },
            { ActiveUniformType.FloatMat2, typeof(float[]) },
            { ActiveUniformType.FloatMat4, typeof(Matrix4X4) },
            { ActiveUniformType.Sampler1D, typeof(int) },
            { ActiveUniformType.Sampler2D, typeof(int) },
            { ActiveUniformType.Sampler3D, typeof(int) },
            { ActiveUniformType.SamplerCube, typeof(int) },
            { ActiveUniformType.Sampler1DShadow, typeof(int) },
            { ActiveUniformType.Sampler2DShadow, typeof(int) },
            { ActiveUniformType.Sampler2DRect, typeof(int) },
            { ActiveUniformType.Sampler2DRectShadow, typeof(int) },
            { ActiveUniformType.FloatMat2X3, typeof(float[]) },
            { ActiveUniformType.FloatMat2X4, typeof(float[]) },
            { ActiveUniformType.FloatMat3X2, typeof(float[]) },
            { ActiveUniformType.FloatMat3X4, typeof(float[]) },
            { ActiveUniformType.FloatMat4X2, typeof(float[]) },
            { ActiveUniformType.FloatMat4X3, typeof(float[]) },
            { ActiveUniformType.Sampler1DArray, typeof(int) },
            { ActiveUniformType.Sampler2DArray, typeof(int) },
            { ActiveUniformType.SamplerBuffer, typeof(int) },
            { ActiveUniformType.Sampler1DArrayShadow, typeof(int) },
            { ActiveUniformType.Sampler2DArrayShadow, typeof(int) },
            { ActiveUniformType.SamplerCubeShadow, typeof(int) },
            { ActiveUniformType.UnsignedIntVec2, typeof(uint[]) },
            { ActiveUniformType.UnsignedIntVec3, typeof(uint[]) },
            { ActiveUniformType.UnsignedIntVec4, typeof(uint[]) },
            { ActiveUniformType.IntSampler1D, typeof(int) },
            { ActiveUniformType.IntSampler2D, typeof(int) },
            { ActiveUniformType.IntSampler3D, typeof(int) },
            { ActiveUniformType.IntSamplerCube, typeof(int) },
            { ActiveUniformType.IntSampler2DRect, typeof(int) },
            { ActiveUniformType.IntSampler1DArray, typeof(int) },
            { ActiveUniformType.IntSampler2DArray, typeof(int) },
            { ActiveUniformType.IntSamplerBuffer, typeof(int) },
            { ActiveUniformType.UnsignedIntSampler1D, typeof(uint) },
            { ActiveUniformType.UnsignedIntSampler2D, typeof(uint) },
            { ActiveUniformType.UnsignedIntSampler3D, typeof(uint) },
            { ActiveUniformType.UnsignedIntSamplerCube, typeof(uint) },
            { ActiveUniformType.UnsignedIntSampler2DRect, typeof(uint) },
            { ActiveUniformType.UnsignedIntSampler1DArray, typeof(uint) },
            { ActiveUniformType.UnsignedIntSampler2DArray, typeof(uint) },
            { ActiveUniformType.UnsignedIntSamplerBuffer, typeof(uint) },
            { ActiveUniformType.Sampler2DMultisample, typeof(int) },
            { ActiveUniformType.IntSampler2DMultisample, typeof(int) },
            { ActiveUniformType.UnsignedIntSampler2DMultisample, typeof(uint) },
            { ActiveUniformType.Sampler2DMultisampleArray, typeof(int) },
            { ActiveUniformType.IntSampler2DMultisampleArray, typeof(int) },
            { ActiveUniformType.UnsignedIntSampler2DMultisampleArray, typeof(uint) }
        };

        /// <summary>
        ///     Types the from uniform type using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <exception cref="Exception"></exception>
        /// <returns>The type</returns>
        private static Type TypeFromUniformType(ActiveUniformType type)
        {
            if (type == ActiveUniformType.FloatMat3)
            {
                throw new InvalidOperationException($"ActiveUniformType {type} is not supported.");
            }

            return UniformTypeMap.TryGetValue(type, out Type result) ? result : typeof(object);
        }

        /// <summary>
        ///     Uses this instance
        /// </summary>
        public void Use() => Gl.GlUseProgram(ProgramId);

        /// <summary>
        ///     Gets the uniform location using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        public int GetUniformLocation(string name)
        {
            Use();
            return Gl.GlGetUniformLocation(ProgramId, name);
        }

        /// <summary>
        ///     Gets the attribute location using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        public int GetAttributeLocation(string name)
        {
            Use();
            return Gl.GlGetAttribLocation(ProgramId, name);
        }
    }
}