// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VideoExampleBase.cs
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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Extension.Media.FFmpeg.Video;

namespace Alis.Extension.Media.FFmpeg.Sample.Samples
{
    /// <summary>
    ///     Base OpenGL sample that decodes frames using Alis.Extension.Media.FFmpeg.VideoReader.
    /// </summary>
    internal abstract class VideoExampleBase : IExample
    {
        /// <summary>
        /// The gl viewport
        /// </summary>
        private const int GlViewport = 0x0BA2;

        /// <summary>
        /// The quad vertices
        /// </summary>
        private readonly float[] quadVertices =
        {
            // x, y, z, u, v
            -1.0f, 1.0f, 0.0f, 0.0f, 0.0f,
            1.0f, 1.0f, 0.0f, 1.0f, 0.0f,
            1.0f, -1.0f, 0.0f, 1.0f, 1.0f,
            -1.0f, -1.0f, 0.0f, 0.0f, 1.0f
        };

        /// <summary>
        /// The quad indices
        /// </summary>
        private readonly uint[] quadIndices = {0, 1, 2, 0, 2, 3};

        /// <summary>
        /// The next frame at utc
        /// </summary>
        private DateTime nextFrameAtUtc;
        /// <summary>
        /// The video path
        /// </summary>
        private string videoPath;
        /// <summary>
        /// The video width
        /// </summary>
        private int videoWidth;
        /// <summary>
        /// The video height
        /// </summary>
        private int videoHeight;
        /// <summary>
        /// The vao
        /// </summary>
        private uint vao;
        /// <summary>
        /// The vbo
        /// </summary>
        private uint vbo;
        /// <summary>
        /// The ebo
        /// </summary>
        private uint ebo;
        /// <summary>
        /// The texture
        /// </summary>
        private uint texture;
        /// <summary>
        /// The shader program
        /// </summary>
        private uint shaderProgram;
        /// <summary>
        /// The scale location
        /// </summary>
        private int scaleLocation;
        /// <summary>
        /// The texture location
        /// </summary>
        private int textureLocation;
        /// <summary>
        /// The reader
        /// </summary>
        private VideoReader reader;
        /// <summary>
        /// The frame buffer
        /// </summary>
        private VideoFrame frameBuffer;

        /// <summary>
        /// Gets the value of the video asset name
        /// </summary>
        protected virtual string VideoAssetName => "sample.mp4";

        /// <summary>
        /// Gets the value of the loop video
        /// </summary>
        protected virtual bool LoopVideo => true;

        /// <summary>
        /// Gets the value of the use cover scaling
        /// </summary>
        protected virtual bool UseCoverScaling => false;

        /// <summary>
        /// Gets the value of the playback speed
        /// </summary>
        protected virtual double PlaybackSpeed => 1.0;

        /// <summary>
        /// Gets the value of the shader program
        /// </summary>
        protected uint ShaderProgram => shaderProgram;

        /// <summary>
        /// Gets the value of the resolved video path in the assets system
        /// </summary>
        protected string VideoPath => videoPath;

        /// <summary>
        /// Gets the fragment shader source
        /// </summary>
        /// <returns>The string</returns>
        protected virtual string GetFragmentShaderSource()
        {
            return @"
#version 150 core
in vec2 TexCoord;
out vec4 FragColor;
uniform sampler2D uTexture;
void main() {
    FragColor = texture(uTexture, TexCoord);
}";
        }

        /// <summary>
        /// Sets the per frame uniforms using the specified elapsed seconds
        /// </summary>
        /// <param name="elapsedSeconds">The elapsed seconds</param>
        protected virtual void SetPerFrameUniforms(float elapsedSeconds)
        {
        }

        /// <summary>
        /// Called after the video reader and GL resources are initialized
        /// </summary>
        protected virtual void OnInitialize()
        {
        }

        /// <summary>
        /// Called during cleanup before releasing base resources
        /// </summary>
        protected virtual void OnCleanup()
        {
        }

        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
            videoPath = AssetRegistry.GetResourcePathByName(VideoAssetName);
            OpenVideoReader();
            CreateRenderingResources();
            UploadFrameToTexture();
            nextFrameAtUtc = DateTime.UtcNow;
            OnInitialize();
        }

        /// <summary>
        /// Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            TryAdvanceVideoFrame();

            Gl.GlUseProgram(shaderProgram);
            ApplyAspectScale();
            SetPerFrameUniforms((float) DateTime.UtcNow.TimeOfDay.TotalSeconds);

            Gl.GlActiveTexture(TextureUnit.Texture0);
            Gl.GlBindTexture(TextureTarget.Texture2D, texture);
            Gl.GlBindVertexArray(vao);
            Gl.GlDrawElements(PrimitiveType.Triangles, quadIndices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            OnCleanup();
            frameBuffer?.Dispose();
            reader?.Dispose();

            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.DeleteBuffer(ebo);
            Gl.DeleteTexture(texture);
            Gl.GlDeleteProgram(shaderProgram);
        }

        /// <summary>
        /// Opens the video reader
        /// </summary>
        private void OpenVideoReader()
        {
            reader?.Dispose();

            reader = new VideoReader(videoPath);
            reader.LoadMetadata();
            EnsureMetadataHasDimensions();
            reader.Load();

            videoWidth = reader.Metadata.Width;
            videoHeight = reader.Metadata.Height;

            frameBuffer?.Dispose();
            frameBuffer = new VideoFrame(videoWidth, videoHeight);
        }

        /// <summary>
        /// Ensures the metadata has dimensions
        /// </summary>
        /// <exception cref="InvalidDataException">No se pudo inicializar metadata para '{VideoAssetName}'.</exception>
        /// <exception cref="InvalidDataException">No se pudo obtener metadata valida para '{VideoAssetName}'. Asegura que ffprobe este instalado y que el asset de video sea valido.</exception>
        private void EnsureMetadataHasDimensions()
        {
            if (reader?.Metadata != null && reader.Metadata.Width > 0 && reader.Metadata.Height > 0)
            {
                return;
            }

            if (!TryReadVideoMetadataFromFfprobe(videoPath, out int width, out int height, out double fps))
            {
                throw new InvalidDataException($"No se pudo obtener metadata valida para '{VideoAssetName}'. Asegura que ffprobe este instalado y que el asset de video sea valido.");
            }

            if (reader?.Metadata == null)
            {
                throw new InvalidDataException($"No se pudo inicializar metadata para '{VideoAssetName}'.");
            }

            reader.Metadata.Width = width;
            reader.Metadata.Height = height;
            if (fps > 0)
            {
                reader.Metadata.AvgFramerate = fps;
            }
        }

        /// <summary>
        /// Tries the read video metadata from ffprobe using the specified input path
        /// </summary>
        /// <param name="inputPath">The input path</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="fps">The fps</param>
        /// <returns>The bool</returns>
        private static bool TryReadVideoMetadataFromFfprobe(string inputPath, out int width, out int height, out double fps)
        {
            width = 0;
            height = 0;
            fps = 0;

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "ffprobe",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = $"-v quiet -print_format json=c=1 -show_streams -i \"{inputPath}\""
                };

                using Process process = Process.Start(psi);
                if (process == null)
                {
                    return false;
                }

                string json = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                if (string.IsNullOrWhiteSpace(json))
                {
                    return false;
                }

                using JsonDocument doc = JsonDocument.Parse(json);
                if (!doc.RootElement.TryGetProperty("streams", out JsonElement streams) || streams.ValueKind != JsonValueKind.Array)
                {
                    return false;
                }

                foreach (JsonElement stream in streams.EnumerateArray())
                {
                    if (!stream.TryGetProperty("codec_type", out JsonElement codecTypeElement))
                    {
                        continue;
                    }

                    string codecType = codecTypeElement.GetString();
                    if (!string.Equals(codecType, "video", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (stream.TryGetProperty("width", out JsonElement widthElement) && widthElement.TryGetInt32(out int parsedWidth))
                    {
                        width = parsedWidth;
                    }

                    if (stream.TryGetProperty("height", out JsonElement heightElement) && heightElement.TryGetInt32(out int parsedHeight))
                    {
                        height = parsedHeight;
                    }

                    if (stream.TryGetProperty("avg_frame_rate", out JsonElement fpsElement))
                    {
                        string avg = fpsElement.GetString();
                        fps = ParseFps(avg);
                    }

                    if (width > 0 && height > 0)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        /// <summary>
        /// Parses the fps using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The double</returns>
        private static double ParseFps(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            string[] parts = value.Split('/');
            if (parts.Length == 2 &&
                double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out double num) &&
                double.TryParse(parts[1], NumberStyles.Float, CultureInfo.InvariantCulture, out double den) &&
                den > 0)
            {
                return num / den;
            }

            if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out double fps))
            {
                return fps;
            }

            return 0;
        }

        /// <summary>
        /// Creates the rendering resources
        /// </summary>
        private void CreateRenderingResources()
        {
            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(vao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle vertexHandle = GCHandle.Alloc(quadVertices, GCHandleType.Pinned);
            try
            {
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(quadVertices.Length * sizeof(float)), vertexHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (vertexHandle.IsAllocated)
                {
                    vertexHandle.Free();
                }
            }

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            GCHandle indexHandle = GCHandle.Alloc(quadIndices, GCHandleType.Pinned);
            try
            {
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(quadIndices.Length * sizeof(uint)), indexHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (indexHandle.IsAllocated)
                {
                    indexHandle.Free();
                }
            }

            string vertexShaderSource = @"
#version 150 core
in vec3 aPos;
in vec2 aTex;
out vec2 TexCoord;
uniform vec2 uScale;
void main() {
    gl_Position = vec4(aPos.xy * uScale, aPos.z, 1.0);
    TexCoord = aTex;
}";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            if (!Gl.GetShaderCompileStatus(vertexShader))
            {
                Logger.Info("Video vertex shader error: " + Gl.GetShaderInfoLog(vertexShader));
            }

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, GetFragmentShaderSource());
            Gl.GlCompileShader(fragmentShader);
            if (!Gl.GetShaderCompileStatus(fragmentShader))
            {
                Logger.Info("Video fragment shader error: " + Gl.GetShaderInfoLog(fragmentShader));
            }

            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);
            if (!Gl.GetProgramLinkStatus(shaderProgram))
            {
                Logger.Info("Video program link error: " + Gl.GetProgramInfoLog(shaderProgram));
            }

            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);

            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), IntPtr.Zero);
            Gl.EnableVertexAttribArray(1);
            Gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), new IntPtr(3 * sizeof(float)));

            texture = Gl.GenTexture();
            Gl.GlActiveTexture(TextureUnit.Texture0);
            Gl.GlBindTexture(TextureTarget.Texture2D, texture);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, TextureParameter.ClampToEdge);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, TextureParameter.ClampToEdge);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, videoWidth, videoHeight, 0, PixelFormat.Rgb, PixelType.UnsignedByte, IntPtr.Zero);

            Gl.GlUseProgram(shaderProgram);
            scaleLocation = Gl.GlGetUniformLocation(shaderProgram, "uScale");
            textureLocation = Gl.GlGetUniformLocation(shaderProgram, "uTexture");
            Gl.GlUniform1I(textureLocation, 0);
        }

        /// <summary>
        /// Tries the advance video frame
        /// </summary>
        private void TryAdvanceVideoFrame()
        {
            if (DateTime.UtcNow < nextFrameAtUtc)
            {
                return;
            }

            if (!UploadFrameToTexture())
            {
                return;
            }

            double fps = reader.Metadata.AvgFramerate <= 0 ? 30.0 : reader.Metadata.AvgFramerate;
            double effectiveFps = Math.Max(1.0, fps * PlaybackSpeed);
            nextFrameAtUtc = DateTime.UtcNow.AddSeconds(1.0 / effectiveFps);
        }

        /// <summary>
        /// Uploads the frame to texture
        /// </summary>
        /// <returns>The bool</returns>
        private bool UploadFrameToTexture()
        {
            VideoFrame nextFrame = reader.NextFrame(frameBuffer);
            if (nextFrame == null)
            {
                if (!LoopVideo)
                {
                    return false;
                }

                OpenVideoReader();
                nextFrame = reader.NextFrame(frameBuffer);
                if (nextFrame == null)
                {
                    return false;
                }
            }

            GCHandle frameHandle = GCHandle.Alloc(nextFrame.RawData, GCHandleType.Pinned);
            try
            {
                Gl.GlBindTexture(TextureTarget.Texture2D, texture);
                Gl.GlPixelStorei(StoreParameter.UnpackAlignment, 1);
                Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, videoWidth, videoHeight, 0, PixelFormat.Rgb, PixelType.UnsignedByte, frameHandle.AddrOfPinnedObject());
            }
            finally
            {
                if (frameHandle.IsAllocated)
                {
                    frameHandle.Free();
                }
            }

            return true;
        }

        /// <summary>
        /// Applies the aspect scale
        /// </summary>
        private void ApplyAspectScale()
        {
            int[] viewport = new int[4];
            Gl.GlGetIntegerv(GlViewport, viewport);

            float viewportWidth = Math.Max(1, viewport[2]);
            float viewportHeight = Math.Max(1, viewport[3]);
            float videoAspect = videoWidth / (float) Math.Max(1, videoHeight);
            float viewportAspect = viewportWidth / viewportHeight;

            float scaleX = 1.0f;
            float scaleY = 1.0f;

            if (!UseCoverScaling)
            {
                if (viewportAspect > videoAspect)
                {
                    scaleX = videoAspect / viewportAspect;
                }
                else
                {
                    scaleY = viewportAspect / videoAspect;
                }
            }
            else
            {
                if (viewportAspect > videoAspect)
                {
                    scaleY = viewportAspect / videoAspect;
                }
                else
                {
                    scaleX = videoAspect / viewportAspect;
                }
            }

            Gl.GlUniform2F(scaleLocation, scaleX, scaleY);
        }
    }
}
