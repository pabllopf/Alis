using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Sample.Samples
{
    /// <summary>
    /// The triangle example class
    /// </summary>
    /// <seealso cref="IExample"/>
    class TriangleExample : IExample
    {
        /// <summary>
        /// The shader program
        /// </summary>
        private uint vao, vbo, shaderProgram;
        /// <summary>
        /// The vertices
        /// </summary>
        private float[] vertices = {
            -0.5f, -0.5f, 0.0f,
            0.5f, -0.5f, 0.0f,
            0.0f,  0.5f, 0.0f
        };
        /// <summary>
        /// The vertex shader source
        /// </summary>
        private string vertexShaderSource = @"
#version 150 core
in vec3 aPos;
void main() {
    gl_Position = vec4(aPos, 1.0);
}";
        /// <summary>
        /// The fragment shader source
        /// </summary>
        private string fragmentShaderSource = @"
#version 150 core
out vec4 FragColor;
void main() {
    FragColor = vec4(1.0, 1.0, 1.0, 1.0);
}";
        /// <summary>
        /// Initializes this instance
        /// </summary>
        public void Initialize()
        {
            vao = Gl.GenVertexArray();
            vbo = Gl.GenBuffer();
            Gl.GlBindVertexArray(vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle vHandle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            Gl.GlBufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vHandle.AddrOfPinnedObject(), BufferUsageHint.StaticDraw);
            vHandle.Free();
            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);
            if (!Gl.GetShaderCompileStatus(vertexShader))
                Console.WriteLine("Vertex shader error: " + Gl.GetShaderInfoLog(vertexShader));
            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);
            if (!Gl.GetShaderCompileStatus(fragmentShader))
                Console.WriteLine("Fragment shader error: " + Gl.GetShaderInfoLog(fragmentShader));
            shaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(shaderProgram, vertexShader);
            Gl.GlAttachShader(shaderProgram, fragmentShader);
            Gl.GlLinkProgram(shaderProgram);
            if (!Gl.GetProgramLinkStatus(shaderProgram))
                Console.WriteLine("Program link error: " + Gl.GetProgramInfoLog(shaderProgram));
            Gl.GlDeleteShader(vertexShader);
            Gl.GlDeleteShader(fragmentShader);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        }
        /// <summary>
        /// Draws this instance
        /// </summary>
        public void Draw()
        {
            Gl.GlClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            Gl.GlClear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Gl.GlBindVertexArray(vao);
            Gl.GlUseProgram(shaderProgram);
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3);
        }
        /// <summary>
        /// Cleanups this instance
        /// </summary>
        public void Cleanup()
        {
            Gl.DeleteVertexArray(vao);
            Gl.DeleteBuffer(vbo);
            Gl.GlDeleteProgram(shaderProgram);
        }
    }
}