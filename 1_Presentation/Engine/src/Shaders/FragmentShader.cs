

namespace Alis.App.Engine.Shaders
{
    /// <summary>
    ///     The fragment shader
    /// </summary>
    public readonly struct FragmentShader : IShader
    {
        /// <summary>
        ///     Gets the value of the shader code
        /// </summary>
        public string ShaderCode => @"
			#version 330
			
			precision mediump float;
			uniform sampler2D Texture;
			in vec2 Frag_UV;
			in vec4 Frag_Color;
			layout (location = 0) out vec4 Out_Color;
			
			void main()
			{
			    Out_Color = Frag_Color * texture(Texture, Frag_UV.st);
			}";
    }
}