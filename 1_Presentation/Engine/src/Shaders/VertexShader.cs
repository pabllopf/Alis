//  --------------------------------------------------------------------------

namespace Alis.App.Engine.Shaders
{
    /// <summary>
    ///     The vertex shader
    /// </summary>
    public readonly struct VertexShader : IShader
    {
        /// <summary>
        ///     Gets the value of the shader code
        /// </summary>
        public string ShaderCode => @"
			#version 330
			
			precision mediump float;
			layout (location = 0) in vec2 Position;
			layout (location = 1) in vec2 UV;
			layout (location = 2) in vec4 Color;
			uniform mat4 ProjMtx;
			out vec2 Frag_UV;
			out vec4 Frag_Color;
			void main()
			{
			    Frag_UV = UV;
			    Frag_Color = Color;
			    gl_Position = ProjMtx * vec4(Position.xy, 0, 1);
			}";
    }
}