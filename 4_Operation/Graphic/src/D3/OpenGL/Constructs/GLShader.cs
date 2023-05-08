using System;
using static OpenGL.GL;

namespace OpenGL
{
	/// <summary>
	/// The gl shader class
	/// </summary>
	/// <seealso cref="IDisposable"/>
	public sealed class GLShader : IDisposable
	{
		// Specifies the OpenGL ShaderID.
		/// <summary>
		/// Gets or sets the value of the shader id
		/// </summary>
		public uint ShaderID { get; private set; }

		// Specifies the type of shader.
		/// <summary>
		/// Gets or sets the value of the shader type
		/// </summary>
		public ShaderType ShaderType { get; private set; }

		// Returns Gl.GetShaderInfoLog(ShaderID), which contains any compilation errors.
		/// <summary>
		/// Gets the value of the shader log
		/// </summary>
		public string ShaderLog => GetShaderInfoLog(ShaderID);

        /// <summary>
        /// /
        /// </summary>
		~GLShader() => Dispose(false);

		/// <summary>
		/// Initializes a new instance of the <see cref="GLShader"/> class
		/// </summary>
		/// <param name="source">The source</param>
		/// <param name="type">The type</param>
		/// <exception cref="Exception"></exception>
		public GLShader(string source, ShaderType type)
		{
			ShaderType = type;
			ShaderID = glCreateShader(type);

			ShaderSource(ShaderID, source);
			glCompileShader(ShaderID);

            if (!GetShaderCompileStatus(ShaderID))
            {
				throw new Exception(ShaderLog);
			}
        }

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
			if (ShaderID != 0)
			{
				glDeleteShader(ShaderID);
				ShaderID = 0;
			}
		}
	}
}
