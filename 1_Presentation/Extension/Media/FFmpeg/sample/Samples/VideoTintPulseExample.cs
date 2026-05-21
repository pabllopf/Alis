

using Alis.Core.Graphic.OpenGL;

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Reproduccion de video con tinte animado por tiempo.
    /// </summary>
    internal class VideoTintPulseExample : VideoExampleBase
    {
        /// <summary>
        /// The time location
        /// </summary>
        private int timeLocation = -1;

        /// <summary>
        /// Gets the fragment shader source
        /// </summary>
        /// <returns>The string</returns>
        protected override string GetFragmentShaderSource()
        {
            return @"
#version 150 core
in vec2 TexCoord;
out vec4 FragColor;
uniform sampler2D uTexture;
uniform float uTime;
void main() {
    vec4 c = texture(uTexture, TexCoord);
    float pulse = 0.5 + 0.5 * sin(uTime * 2.0);
    vec3 tint = vec3(0.5 + pulse * 0.5, 0.8, 1.0);
    FragColor = vec4(c.rgb * tint, c.a);
}";
        }

        /// <summary>
        /// Sets the per frame uniforms using the specified elapsed seconds
        /// </summary>
        /// <param name="elapsedSeconds">The elapsed seconds</param>
        protected override void SetPerFrameUniforms(float elapsedSeconds)
        {
            if (timeLocation < 0)
            {
                timeLocation = Gl.GlGetUniformLocation(ShaderProgram, "uTime");
            }

            Gl.GlUniform1F(timeLocation, elapsedSeconds);
        }
    }
}
