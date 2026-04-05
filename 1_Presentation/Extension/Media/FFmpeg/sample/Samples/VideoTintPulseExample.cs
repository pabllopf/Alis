// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoTintPulseExample.cs
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
