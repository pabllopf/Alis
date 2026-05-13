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
    /// Represents a linked OpenGL shader program that combines vertex and fragment shaders.
    /// Provides automatic parameter (attribute/uniform) discovery, location resolution,
    /// and typed value setting. Implements <see cref="IDisposable"/> for deterministic cleanup.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShaderProgram : IDisposable
    {
        /// <summary>
        /// Specifies whether this program will automatically dispose of the child
        /// vertex/fragment shaders when the program is disposed.
        /// </summary>
        public readonly bool DisposeChildren;

        /// <summary>
        /// Specifies the fragment shader object used in this program.
        /// </summary>
        public readonly GlShader FragmentShader;

        /// <summary>
        /// Specifies the vertex shader object used in this program.
        /// </summary>
        public readonly GlShader VertexShader;

        /// <summary>
        /// Internal dictionary mapping parameter names to their shader program parameter objects.
        /// </summary>
        private Dictionary<string, GlShaderProgramParam> shaderParams;

        /// <summary>
        /// Links a vertex and fragment shader together to create a shader program.
        /// After linking, automatically discovers all active attributes and uniforms.
        /// </summary>
        /// <param name="vertexShader">The compiled vertex shader to attach.</param>
        /// <param name="fragmentShader">The compiled fragment shader to attach.</param>
        /// <exception cref="Exception">Thrown when program linking fails; the message contains the program info log.</exception>
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
                throw new Exception(ProgramLog);
            }

            GetParams();
        }

        /// <summary>
        /// Creates two shaders from the provided source strings and links them together.
        /// The created vertex and fragment shaders will be automatically disposed when the program is disposed.
        /// </summary>
        /// <param name="vertexShaderSource">The GLSL source code of the vertex shader.</param>
        /// <param name="fragmentShaderSource">The GLSL source code of the fragment shader.</param>
        public GlShaderProgram(string vertexShaderSource, string fragmentShaderSource)
            : this(new GlShader(vertexShaderSource, ShaderType.VertexShader), new GlShader(fragmentShaderSource, ShaderType.FragmentShader))
            => DisposeChildren = true;

        /// <summary>
        /// Gets or sets the OpenGL program object ID (handle).
        /// </summary>
        public uint ProgramId { get; set; }

        /// <summary>
        /// Gets the shader parameter with the specified case-sensitive name.
        /// Returns null if the parameter is not found in the program.
        /// </summary>
        /// <param name="name">The case-sensitive name of the shader attribute or uniform.</param>
        /// <returns>The <see cref="GlShaderProgramParam"/> for the requested name, or null.</returns>
        public GlShaderProgramParam this[string name] => shaderParams.ContainsKey(name) ? shaderParams[name] : null;

        /// <summary>
        /// Gets the program info log, containing any linking or validation messages.
        /// </summary>
        public string ProgramLog => Gl.GetProgramInfoLog(ProgramId);

        /// <summary>
        /// Releases the program resources, detaching and optionally disposing shaders.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Parses all active vertex attributes and uniforms from the compiled and linked program,
        /// resolves their locations, and stores them in the internal parameter dictionary.
        /// </summary>
        private void GetParams()
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
        /// Maps an <see cref="ActiveAttribType"/> to its corresponding managed <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The OpenGL attribute type from glGetActiveAttrib.</param>
        /// <returns>The managed type that corresponds to the OpenGL attribute type.</returns>
        /// <exception cref="Exception">Thrown when the type FloatMat3 is encountered (unsupported).</exception>
        private Type TypeFromAttributeType(ActiveAttribType type)
        {
            switch (type)
            {
                case ActiveAttribType.Float: return typeof(float);
                case ActiveAttribType.FloatMat2: return typeof(float[]);
                case ActiveAttribType.FloatMat3: throw new Exception();
                case ActiveAttribType.FloatMat4: return typeof(Matrix4X4);
                case ActiveAttribType.FloatVec2: return typeof(Vector2F);
                case ActiveAttribType.FloatVec3: return typeof(Vector3F);
                case ActiveAttribType.FloatVec4: return typeof(Vector4F);
                default: return typeof(object);
            }
        }

        /// <summary>
        /// Maps an <see cref="ActiveUniformType"/> to its corresponding managed <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The OpenGL uniform type from glGetActiveUniform.</param>
        /// <returns>The managed type that corresponds to the OpenGL uniform type.</returns>
        /// <exception cref="Exception">Thrown when the type FloatMat3 is encountered (unsupported).</exception>
        private Type TypeFromUniformType(ActiveUniformType type)
        {
            switch (type)
            {
                case ActiveUniformType.Int: return typeof(int);
                case ActiveUniformType.Float: return typeof(float);
                case ActiveUniformType.FloatVec2: return typeof(Vector2F);
                case ActiveUniformType.FloatVec3: return typeof(Vector3F);
                case ActiveUniformType.FloatVec4: return typeof(Vector4F);
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
        /// Activates this shader program for rendering via glUseProgram.
        /// </summary>
        public void Use() => Gl.GlUseProgram(ProgramId);

        /// <summary>
        /// Gets the location of a uniform variable in this program.
        /// </summary>
        /// <param name="name">The name of the uniform variable.</param>
        /// <returns>The integer location of the uniform, or -1 if not found.</returns>
        public int GetUniformLocation(string name)
        {
            Use();
            return Gl.GlGetUniformLocation(ProgramId, name);
        }

        /// <summary>
        /// Gets the location of a vertex attribute in this program.
        /// </summary>
        /// <param name="name">The name of the vertex attribute.</param>
        /// <returns>The integer location of the attribute, or -1 if not found.</returns>
        public int GetAttributeLocation(string name)
        {
            Use();
            return Gl.GlGetAttribLocation(ProgramId, name);
        }

        /// <summary>
        /// Finalizes the shader program, ensuring OpenGL resources are released.
        /// </summary>
        ~GlShaderProgram() => Dispose(false);

        /// <summary>
        /// Releases the program and associated resources.
        /// Detaches shaders, deletes the program, and optionally disposes child shaders.
        /// </summary>
        /// <param name="disposing">True if called from Dispose, false if called from the finalizer.</param>
        private void Dispose(bool disposing)
        {
            if (ProgramId != 0)
            {
                Gl.GlUseProgram(0);

                Gl.GlDetachShader(ProgramId, VertexShader.ShaderId);
                Gl.GlDetachShader(ProgramId, FragmentShader.ShaderId);
                Gl.GlDeleteProgram(ProgramId);

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
