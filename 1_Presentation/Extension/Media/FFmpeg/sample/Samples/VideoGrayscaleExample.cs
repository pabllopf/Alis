

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Reproduccion de video en escala de grises.
    /// </summary>
    internal class VideoGrayscaleExample : VideoExampleBase
    {
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
void main() {
    vec4 c = texture(uTexture, TexCoord);
    float luma = dot(c.rgb, vec3(0.2126, 0.7152, 0.0722));
    FragColor = vec4(vec3(luma), c.a);
}";
        }
    }
}

