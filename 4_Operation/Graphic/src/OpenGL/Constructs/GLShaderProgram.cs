using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using static Alis.Core.Graphic.OpenGL.GL;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
	/// <summary>
	/// The gl shader program class
	/// </summary>
	/// <seealso cref="IDisposable"/>
	public sealed class GLShaderProgram : IDisposable
	{
		/// <summary>
		/// Specifies the OpenGL shader program ID.
		/// </summary>
		public uint ProgramID;

		/// <summary>
		/// Specifies the vertex shader used in this program.
		/// </summary>
		public GLShader VertexShader;

		/// <summary>
		/// Specifies the fragment shader used in this program.
		/// </summary>
		public GLShader FragmentShader;

		/// <summary>
		/// Specifies whether this program will dispose of the child
		/// vertex/fragment programs when the IDisposable method is called.
		/// </summary>
		public bool DisposeChildren;

		/// <summary>
		/// The shader params
		/// </summary>
		Dictionary<string, GLShaderProgramParam> shaderParams;

		/// <summary>
		/// Queries the shader parameter hashtable to find a matching attribute/uniform.
		/// </summary>
		/// <param name="name">Specifies the case-sensitive name of the shader attribute/uniform.</param>
		/// <returns>The requested attribute/uniform, or null on a failure.</returns>
		public GLShaderProgramParam this[string name] => shaderParams.ContainsKey(name) ? shaderParams[name] : null;

		/// <summary>
		/// Gets the value of the program log
		/// </summary>
		public string ProgramLog => GetProgramInfoLog(ProgramID);

		/// <summary>
		/// Links a vertex and fragment shader together to create a shader program.
		/// </summary>
		/// <param name="vertexShader">Specifies the vertex shader.</param>
		/// <param name="fragmentShader">Specifies the fragment shader.</param>
		public GLShaderProgram(GLShader vertexShader, GLShader fragmentShader)
		{
			VertexShader = vertexShader;
			FragmentShader = fragmentShader;
			ProgramID = glCreateProgram();
			DisposeChildren = false;

			glAttachShader(ProgramID, vertexShader.ShaderID);
			glAttachShader(ProgramID, fragmentShader.ShaderID);
			glLinkProgram(ProgramID);

			//Check whether the program linked successfully.
			//If not then throw an error with the linking error.
			if (!GetProgramLinkStatus(ProgramID))
				throw new Exception(ProgramLog);

			GetParams();
		}

		/// <summary>
		/// Creates two shaders and then links them together to create a shader program.
		/// </summary>
		/// <param name="vertexShaderSource">Specifies the source code of the vertex shader.</param>
		/// <param name="fragmentShaderSource">Specifies the source code of the fragment shader.</param>
		public GLShaderProgram(string vertexShaderSource, string fragmentShaderSource)
			: this(new GLShader(vertexShaderSource, ShaderType.VertexShader), new GLShader(fragmentShaderSource, ShaderType.FragmentShader))
		{
			DisposeChildren = true;
		}

		/// <summary>
		/// Parses all of the parameters (attributes/uniforms) from the two attached shaders
		/// and then loads their location by passing this shader program into the parameter object.
		/// </summary>
		void GetParams()
		{
			shaderParams = new Dictionary<string, GLShaderProgramParam>();

			var resources = new int[1];
			var actualLength = new int[1];
			var arraySize = new int[1];

			glGetProgramiv(ProgramID, ProgramParameter.ActiveAttributes, resources);

			for (uint i = 0; i < resources[0]; i++)
			{
				var type = new ActiveAttribType[1];
				var sb = new StringBuilder(256);
				glGetActiveAttrib(ProgramID, i, 256, actualLength, arraySize, type, sb);

				if (!shaderParams.ContainsKey(sb.ToString()))
				{
					var param = new GLShaderProgramParam(TypeFromAttributeType(type[0]), ParamType.Attribute, sb.ToString());
					shaderParams.Add(param.Name, param);
					param.GetLocation(this);
				}
			}

			glGetProgramiv(ProgramID, ProgramParameter.ActiveUniforms, resources);

			for (uint i = 0; i < resources[0]; i++)
			{
				var type = new ActiveUniformType[1];
				System.Text.StringBuilder sb = new System.Text.StringBuilder(256);
				glGetActiveUniform(ProgramID, i, 256, actualLength, arraySize, type, sb);

				if (!shaderParams.ContainsKey(sb.ToString()))
				{
					var param = new GLShaderProgramParam(TypeFromUniformType(type[0]), ParamType.Uniform, sb.ToString());
					shaderParams.Add(param.Name, param);
					param.GetLocation(this);
				}
			}
		}

		/// <summary>
		/// Types the from attribute type using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <exception cref="Exception"></exception>
		/// <returns>The type</returns>
		Type TypeFromAttributeType(ActiveAttribType type)
		{
			switch (type)
			{
				case ActiveAttribType.Float: return typeof(float);
				case ActiveAttribType.FloatMat2: return typeof(float[]);
				case ActiveAttribType.FloatMat3: throw new Exception();
				case ActiveAttribType.FloatMat4: return typeof(Matrix4x4);
				case ActiveAttribType.FloatVec2: return typeof(Vector2);
				case ActiveAttribType.FloatVec3: return typeof(Vector3);
				case ActiveAttribType.FloatVec4: return typeof(Vector4);
				default: return typeof(object);
			}
		}

		/// <summary>
		/// Types the from uniform type using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <exception cref="Exception"></exception>
		/// <returns>The type</returns>
		Type TypeFromUniformType(ActiveUniformType type)
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
				case ActiveUniformType.FloatMat4: return typeof(Matrix4x4);
				case ActiveUniformType.Sampler1D:
				case ActiveUniformType.Sampler2D:
				case ActiveUniformType.Sampler3D:
				case ActiveUniformType.SamplerCube:
				case ActiveUniformType.Sampler1DShadow:
				case ActiveUniformType.Sampler2DShadow:
				case ActiveUniformType.Sampler2DRect:
				case ActiveUniformType.Sampler2DRectShadow: return typeof(int);
				case ActiveUniformType.FloatMat2x3:
				case ActiveUniformType.FloatMat2x4:
				case ActiveUniformType.FloatMat3x2:
				case ActiveUniformType.FloatMat3x4:
				case ActiveUniformType.FloatMat4x2:
				case ActiveUniformType.FloatMat4x3: return typeof(float[]);
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
		/// Uses this instance
		/// </summary>
		public void Use() => glUseProgram(ProgramID);

		/// <summary>
		/// Gets the uniform location using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The int</returns>
		public int GetUniformLocation(string name)
		{
			Use();
			return glGetUniformLocation(ProgramID, name);
		}

		/// <summary>
		/// Gets the attribute location using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The int</returns>
		public int GetAttributeLocation(string name)
		{
			Use();
			return glGetAttribLocation(ProgramID, name);
		}

        /// <summary>
        /// 
        /// </summary>
		~GLShaderProgram() => Dispose(false);

		/// <summary>
		/// Disposes this instance
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Disposes the disposing
		/// </summary>
		/// <param name="disposing">The disposing</param>
		void Dispose(bool disposing)
		{
			if (ProgramID != 0)
			{
				glUseProgram(0);

				glDetachShader(ProgramID, VertexShader.ShaderID);
				glDetachShader(ProgramID, FragmentShader.ShaderID);
				glDeleteProgram(ProgramID);

				if (DisposeChildren)
				{
					VertexShader.Dispose();
					FragmentShader.Dispose();
				}

				ProgramID = 0;
			}
		}
	}
}
