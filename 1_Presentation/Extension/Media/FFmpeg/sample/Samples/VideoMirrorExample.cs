

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Reproduccion de video con espejo horizontal.
    /// </summary>
    internal class VideoMirrorExample : VideoExampleBase
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
    vec2 mirroredUv = vec2(1.0 - TexCoord.x, TexCoord.y);
    FragColor = texture(uTexture, mirroredUv);
}";
        }
    }
}

